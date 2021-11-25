import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'pipefirst'
})
export class PipefirstPipe implements PipeTransform {

  transform(value: unknown, ...args: unknown[]): unknown {
    return null;
  }

}
