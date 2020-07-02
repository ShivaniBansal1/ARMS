import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
    name: 'pascalToTitle',
    pure: true
})
export class PascalToTitle implements PipeTransform {

    // result : string = ""

    transform(value: string, args?: any): any {
        let array = value.split("")
        value = ""
        array.map((c, index)=>{
            if (index != 0 && c==c.toUpperCase()){
                value += ` ${c}`
            }
            else{
                value += c;
            }
        });
        return value;
    }

}