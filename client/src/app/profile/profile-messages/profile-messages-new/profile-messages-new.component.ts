import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs/operators';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-profile-messages-new',
  templateUrl: './profile-messages-new.component.html',
  styleUrls: ['./profile-messages-new.component.css']
})
export class ProfileMessagesNewComponent implements OnInit {
  model: any = {};
  currentUser: User;
  userName: string;
  content: string;

  constructor(private accountService: AccountService,
    private messageService: MessageService,
    private router: Router) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  private getCurrentUser(){
    this.accountService.currentUser$.pipe(take(1)).subscribe(response => {
      console.log(response);
      this.currentUser = response;
    });
  }

  sendMessage(){
    if (this.currentUser.role === 'Admin') {
      this.messageService.sendMessage(this.model).subscribe(message => {
        console.log(message);
        this.router.navigateByUrl('/profile/messages');
      })
    }
    else{
      this.model.recipientUserName='admin';
      this.messageService.sendMessage(this.model).subscribe(message => {
        console.log(message);
        this.router.navigateByUrl('/profile/messages');
      })
    }
    
  }
}
