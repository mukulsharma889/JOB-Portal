import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { Observable, of } from 'rxjs';
import { environment } from '../../environments/environment';
import { JobResponse } from '../shared/customer/modals/jobs.response';

@Injectable({
  providedIn: 'root',
})
export class Jobs {
  private readonly baseUrl = signal<string>(environment.baseApiUrl);
  private readonly httpClient = inject(HttpClient);

  /**
   * Fetches a page of jobs from the API. If no base URL is configured we
   * return an empty list so the UI can still render without runtime errors.
   */
  getJobs(page: number = 0, size: number = 10): Observable<JobResponse[]> {
    const url = this.baseUrl() ? `${this.baseUrl()}/jobs?page=${page}&size=${size}` : '';
    const demoJobs: JobResponse[] = [
      {
        id: 1,
        title: 'Business Process counsellor Sales',
        company: 'AKPIS',
        location: 'Mohali, Punjab',
        salary: '₹25,000 - ₹35,000 a month',
        type: 'Full-time',
        postedDate: new Date().toISOString(),
        icon: '',
        description: 'Help manage business processes for a sales team.',
      },
      {
        id: 2,
        title: 'Frontend Developer',
        company: 'TechSolutions',
        location: 'Chandigarh, Punjab',
        salary: '₹60,000 - ₹80,000 a month',
        type: 'Contract',
        postedDate: new Date().toISOString(),
        icon: '',
        description: 'Build UI components using Angular.',
      },
      // add more sample entries as needed
    ];

    if (!url) {
      // in absence of a real API just return the sample list
      return of(demoJobs);
    }

    return this.httpClient.get<JobResponse[]>(url);
  }
}
