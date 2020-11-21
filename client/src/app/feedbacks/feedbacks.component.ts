import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { Feedback } from '../_models/feedback';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';
import { FeedbackService } from '../_services/feedback.service';
import { UserService } from '../_services/user.service';

@Component({
  selector: 'app-feedbacks',
  templateUrl: './feedbacks.component.html',
  styleUrls: ['./feedbacks.component.css']
})
export class FeedbacksComponent implements OnInit {
  model: any = {}
  users: User[];
  currentUser: User;
  feedbacks: Feedback[];
  loggedIn: boolean;

  constructor(private feedbackService: FeedbackService,
    private userService: UserService,
    private accountService: AccountService,
    private router: Router) { 
    
  }

  ngOnInit(): void {
    this.getFeedbacks();
    this.getUsers();
    this.getCurrentUser();
  }

  getUserByCreatorId(creatorId: string): string {
    const user: User =  this.users.find(x => x.id == creatorId);
    return user.userName;
  }

  getFeedbacks(){
    this.feedbackService.getFeedbacks().subscribe(response => {
      this.feedbacks = response;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  addFeedback(){
    this.feedbackService.addFeedback(this.model).subscribe(response => {
      console.log(response);
      this.router.navigateByUrl('/feedbacks');
    }, error => {
      console.log(error);
    });
  }

  private getCurrentUser(){
    this.accountService.currentUser$.pipe(take(1)).subscribe(response => {
      console.log(response);
      this.currentUser = response;
      this.model.creatorId = this.currentUser.id;
    });
  }

  getUsers(){
    this.userService.getUsers().subscribe(response => {
      this.users = response;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }
  

}
