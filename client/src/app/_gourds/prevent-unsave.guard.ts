import { CanDeactivateFn } from '@angular/router';
import { MemberEditComponent } from '../members/member-edit/member-edit.component';

export const preventUnsaveGuard: CanDeactivateFn<MemberEditComponent> = (
  component
) => {
  if (component.form.dirty) {
    return confirm(
      'Are you sure you want to continue? Any unsaved changes will be lost.'
    );
  }
  return true;
};
