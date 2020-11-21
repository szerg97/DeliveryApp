import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Offer } from 'src/app/_models/offer';
import { OfferService } from 'src/app/_services/offer.service';

@Component({
  selector: 'app-offer-detail',
  templateUrl: './offer-detail.component.html',
  styleUrls: ['./offer-detail.component.css']
})
export class OfferDetailComponent implements OnInit {
  offer: Offer;

  constructor(private offerService: OfferService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.loadOffer();
  }

  loadOffer(){
    this.offerService.getOffer(this.route.snapshot.paramMap.get('offerId')).subscribe(offer => {
      this.offer = offer;
      console.log(offer); //ez itt vmiért null
    })
  }

}
