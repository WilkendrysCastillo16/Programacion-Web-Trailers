import { Pipe, PipeTransform } from '@angular/core';
import { ITrailer } from 'src/app/modules/home/interfaces/trailer';

@Pipe({
  name: 'pipefirst'
})
export class PipefirstPipe implements PipeTransform {

  transform(trailer: ITrailer[], ...args: unknown[]): ITrailer[] {


    console.log(trailer)
    return [];
  }

}
