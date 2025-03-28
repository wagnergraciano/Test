import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// Defina as interfaces de resposta das APIs
export interface GetBillSupportsOpositionsByIdResponse {
  BillId: number;
  Title: string;
  PrimarySponsor: string;
  LegislatorsSupported: number;
  LegislatorsOpposed: number;
}

export interface GetLegislatorVotesCountByIdResponse {
  LegislatorId: number;
  LegislatorName: string;
  BillsSupported: number;
  BillsOpposed: number;
}

@Injectable({
  providedIn: 'root'
})
export class BillLegislatorService {

  private apiUrlBill = 'http://localhost:5129/api/voting/bill/support-opposition'; // Substitua pela URL real do seu backend
  private apiUrlLegislator = 'http://localhost:5129/api/voting/legislator/support-opposition'; // Substitua pela URL real do seu backend

  constructor(private http: HttpClient) { }

  // Método para obter os dados dos Bills
  getBills(): Observable<GetBillSupportsOpositionsByIdResponse[]> {
    return this.http.get<GetBillSupportsOpositionsByIdResponse[]>(this.apiUrlBill);
  }

  // Método para obter os dados dos Legisladores
  getLegislators(): Observable<GetLegislatorVotesCountByIdResponse[]> {
    return this.http.get<GetLegislatorVotesCountByIdResponse[]>(this.apiUrlLegislator);
  }
}
