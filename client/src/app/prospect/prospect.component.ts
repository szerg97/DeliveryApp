import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';
import { OfferService } from '../_services/offer.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-prospect',
  templateUrl: './prospect.component.html',
  styleUrls: ['./prospect.component.css']
})
export class ProspectComponent implements OnInit {
  model: any = {};
  prospectMode: number;
  currentUser: User;

  constructor(private router: Router,
    private offerService: OfferService,
    private accountService : AccountService) { }

  ngOnInit(): void {
    this.getCurrentUser();
    this.prospectMode = 0;
  }

  private getCurrentUser(){
    this.accountService.currentUser$.pipe(take(1)).subscribe(response => {
      console.log(response);
      this.currentUser = response;
      this.model.creatorId = this.currentUser.id;
    });
  }

  addProspect(){
    this.offerService.addProspect(this.model).subscribe(response => {
      console.log(response);
      this.router.navigateByUrl('/offers');
    }, error => {
      console.log(error);
    })
  }

  incProspectMode(){
    this.prospectMode++; 
  }

  decProspectMode(){
    this.prospectMode--; 
  }

}
