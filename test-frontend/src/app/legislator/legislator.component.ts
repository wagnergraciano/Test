// legislator.component.ts
import { Component, inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-legislator',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './legislator.component.html',
  styleUrls: ['./legislator.component.css'],
})
export class LegislatorComponent implements OnInit {
  legislators: any[] = [];
  private http = inject(HttpClient);

  ngOnInit(): void {
    this.http
      .get<any[]>('http://localhost:5129/api/voting/legislator/support-opposition')
      .subscribe((data) => {
        this.legislators = data;
      });
  }
}
