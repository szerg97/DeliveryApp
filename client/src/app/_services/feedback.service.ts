import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Feedback } from '../_models/feedback';

@Injectable({
  providedIn: 'root'
})
export class FeedbackService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {
   }

   getFeedbacks(){
     return this.http.get<Feedback[]>(this.baseUrl + 'feedbacks');
   }

   addFeedback(model: any){
    return this.http.post(this.baseUrl + 'feedbacks/add-feedback', model);
   }
}
