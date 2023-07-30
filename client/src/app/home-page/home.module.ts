import { NgModule } from '@angular/core';
import { HomePageComponent } from './home-page.component';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterFormComponent } from '../register-form/register-form.component';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [HomePageComponent, RegisterFormComponent],
  imports: [
    RouterModule.forChild([{ path: '', component: HomePageComponent }]),
    CommonModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
  ],
})
export class HomeModule {}
