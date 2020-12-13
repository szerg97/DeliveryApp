import { Component, OnInit } from '@angular/core';
import { Message } from 'src/app/_models/message';
import { Pagination } from 'src/app/_models/pagination';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-profile-messages',
  templateUrl: './profile-messages.component.html',
  styleUrls: ['./profile-messages.component.css']
})
export class ProfileMessagesComponent implements OnInit {
  messages: Message[];
  pagination: Pagination;
  container = 'Inbox';
  pageNumber = 1;
  pageSize = 5;
  loading = false;

  constructor(private messageService: MessageService) { }

  ngOnInit(): void {
    this.loadMessages();
  }

  loadMessages(){
    this.loading = true;
    this.messageService.getMessages(this.pageNumber, this.pageSize, this.container).subscribe(response => {
      this.messages = response.result;
      this.pagination = response.pagination;
      this.loading = false;
    });
  }

  deleteMessage(messageId: string){
    this.messageService.deleteMessage(messageId).subscribe(() => {
      this.messages.splice(this.messages.findIndex(m  => m.messageId === messageId), 1);
    });
  }

  pageChanged(event: any){
    this.pageNumber = event.page;
    this.loadMessages();
  }

}
