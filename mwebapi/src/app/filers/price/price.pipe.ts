import { Pipe, PipeTransform } from '@angular/core';
import { SummarizedProduct } from '../../pages/home/models/models';

@Pipe({
  name: 'price'
})
export class PricePipe implements PipeTransform {

  transform(value: Array<SummarizedProduct>, ...args: Array<any>): unknown {
    console.log(args)
    if (args[0] == undefined) {
      return value;
    } else {
      return value.filter((product) => {
        return product.productRate >=args[0].min && product.productRate<=args[0].max; 
      });
    }
  }

}
