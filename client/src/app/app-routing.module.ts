import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { ListsComponent } from './lists/lists.component';
import { MessagesComponent } from './messages/messages.component';
import { authGuard } from './_gourds/auth.guard';
import { ErrorsModule } from './errors/erros.module';

const routes: Routes = [
  {
    path: '',
    loadChildren: () =>
      import('./home-page/home.module').then((m) => m.HomeModule),
    pathMatch: 'full',
  },
  { path: 'home', redirectTo: '', pathMatch: 'full' },

  {
    path: '',
    canActivate: [authGuard],
    runGuardsAndResolvers: 'always',
    children: [
      { path: 'members', component: MemberListComponent },
      { path: 'members/:id', component: MemberDetailComponent },
      { path: 'lists', component: ListsComponent },
      { path: 'messages', component: MessagesComponent },
    ],
  },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' },
  {
    path: 'not-fount',
    loadChildren: () =>
      import('./errors/erros.module').then((m) => m.ErrorsModule),
  },
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules }),
    ErrorsModule,
  ],
  exports: [RouterModule],
})
export class AppRoutingModule {}
