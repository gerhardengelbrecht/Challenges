import { Component, OnInit } from '@angular/core';
import { FiberService } from '../service/fiber.service';
import { Compaigns, PromoCodeProducts, SummarizedProduct } from '../models/models';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  compaigns: Compaigns[] = [];
  compaignLoading: boolean = true;
  promocodes: Array<string>[];
  promoProducts: PromoCodeProducts[] = [];
  summarizedProducts: SummarizedProduct[] = [];
  providers : Array<string> = [];
  productsLoading: boolean = false;
  selectedProvide = [];
  priceRange = [{min: 0, max: 699, label: 'R0 - R699'}, {min: 700, max: 999, label: 'R700 - R999'}, {min: 1000, max: 9999, label: 'R1000+'}];
  // speedRange = [{min: 0, max: 699, label: 'R0 - R699'}, {min: 700, max: 999, label: 'R700 - R999'}, {min: 1000, max: 9999, label: 'R1000+'}];
  selectedPrice;
  constructor(private fiberService: FiberService) { }

  ngOnInit(): void {
    this.compaignLoading = true;
    this.fiberService.getFiberCompaign().subscribe((resp: any)=> {
      this.compaigns = resp.campaigns;
      this.compaignLoading = false;
    });
  }

  selectCompaign(index){
    this.productsLoading = true;
    this.promoProducts = [];
    this.summarizedProducts = [];
    this.providers = [];
    this.promocodes = this.compaigns[index].promocodes;
    this.fiberService.getPromoCodeProducts(this.promocodes).subscribe((resp)=>{
      this.promoProducts = resp;
      this.promoProductToSummarized();
    });
  }

  promoProductToSummarized(){
    this.promoProducts.forEach(promoProducts => {
      let provider = promoProducts.products[0].subcategory.replace('Uncapped', '').replace('Capped', '').trim();
      if (!this.providers.includes(provider)) {
        this.providers.push(provider); 
      }
      promoProducts.products.forEach(product => {
        this.summarizedProducts.push({
          productCode: product.productCode,
          productName: product.productName,
          productRate: product.productRate,
          provider: provider
        });
      });
    });
    this.selectedProvide[0] = this.providers[0];
    this.productsLoading = false;
  }

  setAll(event){
    console.log(event);
  }

  checking(){
    // console.log(this.selectedProvide);
  }

}
