import { Pipe, PipeTransform } from '@angular/core';
import { ITrailer } from 'src/app/modules/home/interfaces/trailer';
import { ITraillerActor } from 'src/app/modules/home/interfaces/trailler-actor';

@Pipe({
  name: 'pipefirst'
})
export class PipefirstPipe implements PipeTransform {

  transform(value: any[] | any, args: any): any {

   const resul = [];
   for(const elemento of value){
     if (elemento.trailler.title.toLowerCase().indexOf(args.toLowerCase()) > -1){
       resul.push(elemento);
     }
   }

    return resul;
  }

}
