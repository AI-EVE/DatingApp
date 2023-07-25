import { CanActivateFn } from '@angular/router';
import { inject } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);

  if (accountService.isLogin) {
    return true;
  }
  const toastr = inject(ToastrService);
  toastr.error('You shall not pass!');
  return false;
};
