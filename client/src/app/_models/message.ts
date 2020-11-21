export interface Message {
    messageId: string;
    senderId: string;
    senderUserName: string;
    recipientId: string;
    recipientUserName: string;
    content: string;
    dateRead?: Date;
    messageSent: Date;
    subject: string;
  }