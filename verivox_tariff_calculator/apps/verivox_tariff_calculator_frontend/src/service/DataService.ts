import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TariffInformation } from '../dtos/TariffInformation';
import { lastValueFrom, map, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class DataService {

    constructor(private http: HttpClient) {
    }

    getTariffs(anualCosts: number): Observable<TariffInformation[]>
    {
        return this.http.get<TariffInformation[]>(`api/Tariff?consumption=${anualCosts}`)
    }
}
