// bill.component.ts
import { Component, inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-bill',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './bill.component.html',
  styleUrls: ['./bill.component.css'],
})
export class BillComponent implements OnInit {
  bills: any[] = [];
  private http = inject(HttpClient);

  ngOnInit(): void {
    this.http
      .get<any[]>('http://localhost:5129/api/voting/bill/support-opposition')
      .subscribe((data) => {
        this.bills = data;
      });
  }
}
