export interface JobResponse {
  id: number;
  title: string;
  company: string;
  location: string;
  salary: string;
  type: 'Full-time' | 'Part-time' | 'Contract' | 'Internship'; // String literal types for better UX
  postedDate: string;
  icon: string;
  description: string;
  requirements?: string[]; // Optional property
  status?: 'Applied' | 'Pending' | 'Rejected'; // For candidate tracking
}
