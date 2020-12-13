import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { Country } from '../_models/country';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';
import { CountryService } from '../_services/country.service';
import { OfferService } from '../_services/offer.service';

@Component({
  selector: 'app-prospect',
  templateUrl: './prospect.component.html',
  styleUrls: ['./prospect.component.css']
})
export class ProspectComponent implements OnInit {
  model: any = {};
  prospectMode: number;
  currentUser: User;
  countries: Country[];

  constructor(private router: Router,
    private offerService: OfferService,
    private accountService : AccountService,
    private countryService: CountryService) { }

  ngOnInit(): void {
    this.getCurrentUser();
    this.prospectMode = 0;
    this.loadCountries();
  }

  private getCurrentUser(){
    this.accountService.currentUser$.pipe(take(1)).subscribe(response => {
      console.log(response);
      this.currentUser = response;
      this.model.creatorId = this.currentUser.id;
    });
  }

  loadCountries(){
    this.countryService.getCountries().subscribe(countries => {
      this.countries = countries;
    }, error => {
      console.log(error);
    })
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
