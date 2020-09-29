import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {HttpClientModule} from '@angular/common/http';
import {Routes, RouterModule} from '@angular/router';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import {PropertyDetailResolverService} from './property/property-detail/property-detail-resolver.service';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';

import { NavBarComponent } from './nav-bar/nav-bar.component';
import { PropertyCardComponet } from './property/property-card/propety-card.component';
import { PropertyListComponent } from './property/property-list/property-list.component';
import { HousingService } from './services/housing.service';
import { AddPropertyComponent } from './property/add-property/add-property.component';
import { PropertyDetailComponent } from './property/property-detail/property-detail.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserServiceService } from './services/user-service.service';
import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';
import { FilterPipe } from './Pipes/filter.pipe';
import { SortPipe } from './Pipes/sort.pipe';


const appRoutes: Routes = [
  { path: '', component : PropertyListComponent},
  { path: 'rent-property', component : PropertyListComponent},
  { path: 'property-detail/:id',
           component : PropertyDetailComponent,
            resolve: {prp: PropertyDetailResolverService}},
  { path: 'add-property', component : AddPropertyComponent},
  { path: 'user/login', component : UserLoginComponent},
  { path: 'user/register', component : UserRegisterComponent},
  { path: '**', component : PropertyListComponent}
];

@NgModule({
   declarations: [
      AppComponent,

      NavBarComponent,
      PropertyCardComponet,
      PropertyListComponent,
      AddPropertyComponent,
      PropertyDetailComponent,

      UserRegisterComponent,
      UserLoginComponent,
      FilterPipe,
      SortPipe

   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot(appRoutes),
      BrowserAnimationsModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      ButtonsModule.forRoot(),
      BsDatepickerModule.forRoot(),
      NgxGalleryModule
   ],
   providers: [
     HousingService,
     UserServiceService,
     AlertifyService,
     AuthService,
     PropertyDetailResolverService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
