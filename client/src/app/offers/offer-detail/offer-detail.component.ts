import { ViewChild } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs/operators';
import { Offer } from 'src/app/_models/offer';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { OfferService } from 'src/app/_services/offer.service';

@Component({
  selector: 'app-offer-detail',
  templateUrl: './offer-detail.component.html',
  styleUrls: ['./offer-detail.component.css']
})
export class OfferDetailComponent implements OnInit {
  @ViewChild('editForm') editForm: NgForm;
  offer: Offer;
  currentUser: any;

  constructor(private offerService: OfferService, private route: ActivatedRoute,
    private accountService: AccountService, private toastrService: ToastrService) { }

  ngOnInit(): void {
    this.getCurrentUser();
    this.loadOffer();
  }

  loadOffer(){
    this.offerService.getOffer(this.route.snapshot.paramMap.get('offerId')).subscribe(offer => {
      this.offer = offer;
      console.log(offer);
    })
  }

  getCurrentUser(){
    this.accountService.currentUser$.pipe(take(1)).subscribe(user =>{
      this.currentUser = user;
    })
  }

  updateOffer(){
    this.offerService.updateOffer(this.offer).subscribe(() =>{
      this.toastrService.success('Offer updated succesfully');
      this.editForm.reset(this.offer);
    });
  }

}
