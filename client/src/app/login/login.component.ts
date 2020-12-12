import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @Output() cancelLogin = new EventEmitter();
  model:any = {}
  currentUser: User;
  loginForm: FormGroup;

  constructor(public accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.getCurrentUser();
    this.initzializeForm();
    }

  initzializeForm(){
    this.loginForm = new FormGroup({
      userName: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    });
  }

  login(){
    this.accountService.login(this.model).subscribe(
      response => {
        this.router.navigateByUrl('/offers');
      }, error => {
        console.log(error);
      });
  }

  logout(){
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }

  private getCurrentUser(){
    this.accountService.currentUser$.pipe(take(1)).subscribe(response => {
      this.currentUser = response;
    });
  }

  cancel(){
    this.cancelLogin.emit(false);
  }
}
