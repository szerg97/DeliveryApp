import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FeedbacksComponent } from './feedbacks/feedbacks.component';
import { HomeComponent } from './home/home.component';
import { InformationComponent } from './information/information.component';
import { OfferDetailComponent } from './offers/offer-detail/offer-detail.component';
import { OfferListComponent } from './offers/offer-list/offer-list.component';
import { ProfileEditComponent } from './profile/profile-edit/profile-edit.component';
import { ProfileMessagesNewComponent } from './profile/profile-messages/profile-messages-new/profile-messages-new.component';
import { ProfileMessagesComponent } from './profile/profile-messages/profile-messages.component';
import { ProspectComponent } from './prospect/prospect.component';
import { SitesComponent } from './sites/sites.component';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';

const routes: Routes = [
  { path: '', component: HomeComponent},
  { path: 'offers', component: OfferListComponent, canActivate: [AuthGuard]},
  { path: 'profile/edit', component: ProfileEditComponent, canDeactivate: [PreventUnsavedChangesGuard]},
  { path: 'profile/messages', component: ProfileMessagesComponent, canActivate: [AuthGuard] },
  { path: 'profile/messages/new', component: ProfileMessagesNewComponent, canActivate: [AuthGuard] },
  { path: 'offers/:offerId', component: OfferDetailComponent, canActivate: [AuthGuard] },
  { path: 'sites', component: SitesComponent, canActivate: [AuthGuard]},
  { path: 'information', component: InformationComponent},
  { path: 'prospect', component: ProspectComponent, canActivate: [AuthGuard]},
  { path: 'feedbacks', component: FeedbacksComponent, canActivate: [AuthGuard]},
  { path: '**', component: HomeComponent, pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
