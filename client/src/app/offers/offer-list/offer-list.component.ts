import { Component, OnInit } from '@angular/core';
import { take } from 'rxjs/operators';
import { Offer } from 'src/app/_models/offer';
import { Signalr } from 'src/app/_models/signalr';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { OfferService } from 'src/app/_services/offer.service';
import { UserService } from 'src/app/_services/user.service';
import { environment } from 'src/environments/environment';

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
  currentUser: User;
  private sr: Signalr;

  constructor(private offerService: OfferService,
    private userService: UserService,
    private accountService: AccountService) { }

  ngOnInit(): void {
    this.getCurrentUser();
    this.rowNumber = 0;
    this.getUsers();
    this.getOffers();

    this.sr = new Signalr(environment.offerHubUrl);
    this.sr.register('NewOffer', t => {
      this.offers.unshift(t);
      return true;
    });
    this.sr.register('DelOffer', t => {
      this.offers.splice(this.offers.findIndex(o  => o.offerId === t.offerId), 1);
      return true;
    });
    this.sr.start();
  }
  getCurrentUser() {
    this.accountService.currentUser$.pipe(take(1)).subscribe(user => {
      this.currentUser = user;
    })
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

  deleteOffer(offerId: string){
    this.offerService.deleteOffer(offerId).subscribe();
  }

}
