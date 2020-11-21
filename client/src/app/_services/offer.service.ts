import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Offer } from '../_models/offer';

@Injectable({
  providedIn: 'root'
})
export class OfferService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  addProspect(model: any){
    return this.http.post(this.baseUrl + 'prospect/add-prospect', model);
  }

  getOffers(){
    return this.http.get<Offer[]>(this.baseUrl + 'offers');
  }

  getOffer(id){
    return this.http.get<Offer>(this.baseUrl + 'offers/' + id);
  }
}
