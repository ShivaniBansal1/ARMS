import { Component, OnInit } from "@angular/core";
import { CandidateService } from './services/candidate.service';
import { IResponse } from '../models/response.interface';
import { IModelForPagination } from '../models/modelPagination.interface';
import { ICandidate } from '../models/candidate.interface';
import { HttpErrorResponse } from '@angular/common/http';
import { BufferToPdf } from '../utils/bufferToPdf';

@Component({
    selector: 'app-candidate',
    templateUrl: 'candidate.component.html',
    styleUrls: ['candidate.component.scss'],
    providers: [BufferToPdf]
})
export class CandidateComponent implements OnInit {
    candidates: ICandidate[];
    columns: Array<string>;
    pager: IPager;

    constructor(private candidateService: CandidateService, private bufferToPdf: BufferToPdf) { }

    ngOnInit(): void {
        this.searchCandidate({ page: 1, character: '' });
    }

    searchCandidate(event: IModelForPagination) {
        this.candidateService.searchCandidate(event.page, event.character).subscribe((res: IResponse) => {
            this.candidates = res.payload.data.dataList;
            this.candidates.forEach((candidate: any) => {
                candidate.pdf = this.bufferToPdf.bufferToPdf(candidate.cv.data);
            });
            this.columns = ["name", "email", "appliedFor", "experience"];
            this.pager = res.payload.data.pager;
        }, (error: HttpErrorResponse) => {

        });
    }

    downloadPdf(cv: string): void {
        let newPdfWindow = window.open("", "Print");

        let iframe = `<\iframe width='100%' height='100%' src="${cv}"><\/iframe>`;

        newPdfWindow.document.write(iframe);
    }
}