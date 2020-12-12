import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  loginMode = false;
  response: User;

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  registerToggle(){
    this.registerMode = !this.registerMode;
  }

  loginToggle(){
    this.loginMode = !this.loginMode;
  }

  cancelRegisterMode(event: boolean){
    this.registerMode = event;
  }

  cancelLoginMode(event: boolean){
    this.loginMode = event;
  }

  getCurrentUser(){
    this.accountService.currentUser$.pipe(take(1)).subscribe(resp =>{
      this.response = resp;
    })
  }
}
