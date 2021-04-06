import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeComponent } from './home/home.component';
import { SharedModule } from '../../shared/shared.module';
import { FormsModule } from '@angular/forms';
import { ProviderPipe } from '../../filers/provider/provider.pipe';
import { PricePipe } from '../../filers/price/price.pipe';

@NgModule({
  declarations: [HomeComponent, ProviderPipe, PricePipe],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule,
    FormsModule
  ]
})
export class HomeModule { }
