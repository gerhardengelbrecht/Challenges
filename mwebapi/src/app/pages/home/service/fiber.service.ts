import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WebapiService } from '../../../service/webapi.service';
import { Compaigns, PromoCodeProducts } from '../models/models';

@Injectable({
  providedIn: 'root'
})
export class FiberService {

  constructor(private webApi: WebapiService) { }

  getFiberCompaign(): Observable<Compaigns[]>{
    return this.webApi.get<Compaigns[]>('campaigns/fibre?channels=120&visibility=public');
  }

  getPromoCodeProducts(promocodes): Observable<PromoCodeProducts[]>{
    return this.webApi.get<PromoCodeProducts[]>(`products/promos/${promocodes.join(',')}`);
  }
}
