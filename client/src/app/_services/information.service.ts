import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InformationService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
   }

   getCountriesCount(){
     return this.http.get<number>(this.baseUrl + 'information/countries');
   }
   getOffersCount(){
    return this.http.get<number>(this.baseUrl + 'information/offers');
  }
  getOffersRunningCount(){
    return this.http.get<number>(this.baseUrl + 'information/offers-running');
  }
  getOffersCompleteCount(){
    return this.http.get<number>(this.baseUrl + 'information/offers-complete');
  }
  getCompaniesCount(){
    return this.http.get<number>(this.baseUrl + 'information/companies');
  }
  getUsersCount(){
    return this.http.get<number>(this.baseUrl + 'information/users');
  }
}
