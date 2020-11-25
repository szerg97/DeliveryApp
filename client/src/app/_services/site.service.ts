import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Site } from '../_models/site';

@Injectable({
  providedIn: 'root'
})
export class SiteService {

  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getSites(){
    return this.http.get<Site[]>(this.baseUrl + 'sites');
  }
}
