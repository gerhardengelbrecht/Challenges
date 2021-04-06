import { Pipe, PipeTransform } from '@angular/core';
import { SummarizedProduct } from '../../pages/home/models/models';
@Pipe({
  name: 'provider'
})
export class ProviderPipe implements PipeTransform {

  transform(value: Array<SummarizedProduct>, args: any): unknown {
    if (args.length == 0) {
      return value;
    } else {
      return value.filter( p => args.includes(p.provider) );
    }
  }

}
