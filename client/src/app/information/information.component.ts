import { Component, OnInit } from '@angular/core';
import { InformationService } from '../_services/information.service';

@Component({
  selector: 'app-information',
  templateUrl: './information.component.html',
  styleUrls: ['./information.component.css']
})
export class InformationComponent implements OnInit {
  usersCount: number;
  countriesCount: number;
  companiesCount: number;
  offersCount: number;
  offersRunningCount: number;
  offersCompleteCount: number;

  constructor(private informationService: InformationService) { }

  ngOnInit(): void {
    this.loadUsersCount();
    this.loadCountriesCount();
    this.loadCompaniesCount();
    this.loadOffersCount();
    this.loadOffersRunningCount();
    this.loadOffersCompleteCount();
  }

  loadUsersCount(){
    this.informationService.getUsersCount().subscribe(count => {
      this.usersCount = count;
    }, error => {
      console.log(error);
    })
  }
  loadCountriesCount(){
    this.informationService.getCountriesCount().subscribe(count => {
      this.countriesCount = count;
    }, error => {
      console.log(error);
    })
  }
  loadCompaniesCount(){
    this.informationService.getCompaniesCount().subscribe(count => {
      this.companiesCount = count;
    }, error => {
      console.log(error);
    })
  }
  loadOffersCount(){
    this.informationService.getOffersCount().subscribe(count => {
      this.offersCount = count;
    }, error => {
      console.log(error);
    })
  }
  loadOffersRunningCount(){
    this.informationService.getOffersRunningCount().subscribe(count => {
      this.offersRunningCount = count;
    }, error => {
      console.log(error);
    })
  }
  loadOffersCompleteCount(){
    this.informationService.getOffersCompleteCount().subscribe(count => {
      this.offersCompleteCount = count;
    }, error => {
      console.log(error);
    })
  }
}
