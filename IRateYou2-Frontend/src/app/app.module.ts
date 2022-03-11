import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { MainPageComponent } from './main-page/main-page.component';
import {NgxsModule} from "@ngxs/store";
import {environment} from "../environments/environment";
import {ReactiveFormsModule} from "@angular/forms";
import {UserState} from "./shared/states/user/user.state";

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    MainPageComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    NgxsModule.forRoot([UserState], {
      developmentMode: !environment.production
    }),
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
