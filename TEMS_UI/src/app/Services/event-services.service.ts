import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IEvent } from '../Models/Event';

@Injectable({
  providedIn: 'root'
})
export class EventServicesService {

  baseApiUrl: string = environment.baseApiUrl; // referenced variable

  // to talk to external api need an http client
  constructor(private http: HttpClient) { }

  GetAllEventsByMonthYear(month: number, year: number): Observable<IEvent[]> {
    return this.http.get<IEvent[]>(this.baseApiUrl + "Event/" + month + "/" + year);
  }

  GetEventById(id: any): Observable<IEvent> {
    return this.http.get<IEvent>(this.baseApiUrl + "Event/" + id);
  }
}
