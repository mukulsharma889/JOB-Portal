import { CommonModule } from '@angular/common';
import { Component, inject, signal } from '@angular/core';
import { PaginatorModule } from 'primeng/paginator';
import { Jobs } from '../../../services/jobs';
import { JobResponse } from '../../../shared/customer/modals/jobs.response';
import { JobCard } from './job-card/job-card';

@Component({
  selector: 'app-jobs-listing',
  imports: [JobCard, PaginatorModule, CommonModule],
  templateUrl: './jobs-listing.html',
  styleUrl: './jobs-listing.scss',
})
export class JobsListing {
  jobs = signal<JobResponse[]>([]);
  first = signal<number>(0);
  rows = signal<number>(10);

  private readonly jobsService = inject(Jobs);

  ngOnInit() {
    this.loadJobs();
  }

  private loadJobs(): void {
    // note: in a real app you might use the signals directly in the template
    // or a store; this keeps simplicity for now.
    this.jobsService.getJobs(this.first(), this.rows()).subscribe((data) => this.jobs.set(data));
  }

  onPageChange(event: any) {
    this.first.set(event.first);
    this.rows.set(event.rows);
    this.loadJobs();
  }
}
