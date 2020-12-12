import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { CarouselModule } from 'ngx-bootstrap/carousel';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { OfferListComponent } from './offers/offer-list/offer-list.component';
import { OfferDetailComponent } from './offers/offer-detail/offer-detail.component';
import { SitesComponent } from './sites/sites.component';
import { InformationComponent } from './information/information.component';
import { ProspectComponent } from './prospect/prospect.component';
import { FeedbacksComponent } from './feedbacks/feedbacks.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { ProfileEditComponent } from './profile/profile-edit/profile-edit.component';
import { SharedModule } from './_modules/shared.module';
import { ProfileMessagesComponent } from './profile/profile-messages/profile-messages.component';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { ProfileMessagesNewComponent } from './profile/profile-messages/profile-messages-new/profile-messages-new.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoadingInterceptor } from './_interceptors/loading.interceptor';
import { LoginComponent } from './login/login.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    OfferListComponent,
    OfferDetailComponent,
    SitesComponent,
    InformationComponent,
    ProspectComponent,
    FeedbacksComponent,
    ProfileEditComponent,
    ProfileMessagesComponent,
    ProfileMessagesNewComponent,
    LoginComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    ReactiveFormsModule,
    ButtonsModule,
    SharedModule,
    NgxSpinnerModule,
    CarouselModule.forRoot()
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass:JwtInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass:LoadingInterceptor, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
