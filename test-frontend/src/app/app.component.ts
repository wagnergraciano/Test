// app.component.ts
import { Component } from '@angular/core';
import { BillComponent } from './bill/bill.component';
import { LegislatorComponent } from './legislator/legislator.component';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [BillComponent, LegislatorComponent, HttpClientModule],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Bill and Legislator Dashboard';
}
