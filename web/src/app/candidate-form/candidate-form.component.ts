import { ICandidate } from './../models/candidate.interface';
import { AppServicesService } from "./../services/app-services.service";
import { Component, OnInit } from "@angular/core";
import { FileUploader } from "ng2-file-upload";


const URL = 'http://localhost:3000/api/candidate'

@Component({
  selector: "app-candidate-form",
  templateUrl: "./candidate-form.component.html",
  styleUrls: ["./candidate-form.component.scss"],
})
export class CandidateFormComponent implements OnInit {
  isSubmitted: Boolean = false;

  constructor(private service: AppServicesService) { }

  public uploader: FileUploader = new FileUploader({
    url: URL,
    itemAlias: "file",
    allowedMimeType: ["application/msword",
                      "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                      "application/pdf"]

  });

  ngOnInit() {
    this.uploader.onAfterAddingFile = (file) => {
      file.withCredentials = false;
    };
    this.uploader.onCompleteItem = (item: any, status: any) => {};


    
  }

  model: any = {};

  createCandidate(candidateObj: ICandidate) {
    if (
      candidateObj.name &&
      candidateObj.email &&
      candidateObj.aadhar&&
      candidateObj.file &&
      candidateObj.skills&&
      candidateObj.appliedFor
    ) {
      if (this.uploader.getNotUploadedItems().length != 0) {
        this.uploader.onBuildItemForm = (item, form) => {
          form.append("name", candidateObj.name);
          form.append("experience", candidateObj.experience);
          form.append("email", candidateObj.email);
          form.append("aadhar", candidateObj.aadhar);
          form.append("skills", candidateObj.skills);
          form.append("appliedFor", candidateObj.appliedFor);
          item.formData = candidateObj.name;
          item.formData = candidateObj.experience;
          item.formData = candidateObj.email;
          item.formData = candidateObj.aadhar;
          item.formData = candidateObj.skills;
          item.formData = candidateObj.appliedFor;
        };
        this.uploader.uploadAll();
      }
    }
  }
}
