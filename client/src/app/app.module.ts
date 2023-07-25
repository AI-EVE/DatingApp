import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; // import HttpClientModule

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './header/header.component';
import { ReactiveFormsModule } from '@angular/forms';
import { BurgerIconComponent } from './burger-icon/burger-icon.component';
import { HomePageComponent } from './home-page/home-page.component';
import { RegisterFormComponent } from './register-form/register-form.component';

@NgModule({
  declarations: [AppComponent, HeaderComponent, BurgerIconComponent, HomePageComponent, RegisterFormComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
