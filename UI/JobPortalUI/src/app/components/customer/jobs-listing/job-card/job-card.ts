import { NgIf } from '@angular/common';
import { Component, input, signal } from '@angular/core';
import { JobResponse } from '../../../../shared/customer/modals/jobs.response';

@Component({
  selector: 'app-job-card',
  imports: [NgIf],
  templateUrl: './job-card.html',
  styleUrl: './job-card.scss',
})
export class JobCard {
  // Using signal input syntax instead of @Input
  job = input<JobResponse | undefined>(undefined);

  // Track whether this job is saved
  isSaved = signal<boolean>(false);

  // Toggle save status
  toggleSaveJob(): void {
    this.isSaved.update((saved) => !saved);
  }
}
