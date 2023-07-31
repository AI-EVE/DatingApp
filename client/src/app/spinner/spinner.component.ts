import { Component, Input } from '@angular/core';
import { BusyService } from '../_services/busy.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css'],
})
export class SpinnerComponent {
  isLoading: boolean = false;

  constructor(private busy: BusyService) {}

  ngOnInit(): void {
    this.busy.updateLoadingStatus.subscribe((isLoading) => {
      this.isLoading = isLoading;
    });
  }
}
