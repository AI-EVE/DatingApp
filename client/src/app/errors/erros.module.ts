import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NotFoundComponent } from './not-found/not-found.component';

const routes = [
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server', component: NotFoundComponent },
];

@NgModule({
  declarations: [NotFoundComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ErrorsModule {}
