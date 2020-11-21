import { Component, OnInit } from '@angular/core';
import { Offer } from 'src/app/_models/offer';
import { User } from 'src/app/_models/user';
import { OfferService } from 'src/app/_services/offer.service';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-offer-list',
  templateUrl: './offer-list.component.html',
  styleUrls: ['./offer-list.component.css']
})
export class OfferListComponent implements OnInit {
  model: any = {};
  offers: Offer[];
  users: User[];
  rowNumber: any;

  constructor(private offerService: OfferService,
    private userService: UserService) { }

  ngOnInit(): void {
    this.rowNumber = 0;
    this.getUsers();
    this.getOffers();
  }

  getUsers(){
    this.userService.getUsers().subscribe(response => {
      this.users = response;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  getOffers(){
    this.offerService.getOffers().subscribe(result => {
      this.offers = result;
      console.log(result);
    }, error => {
      console.log(error);
    })
  }

  getUserByCreatorId(creatorId: string): string {
    const user: User =  this.users.find(x => x.id == creatorId);
    return user.userName;
  }

}
