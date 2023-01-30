import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IVenue } from '../Models/Venue';

@Injectable({
  providedIn: 'root'
})
export class VenueServicesService {

  baseApiUrl: string = environment.baseApiUrl; // referenced variable

  // to talk to external api need an http client
  constructor(private http: HttpClient) { }

  GetVenueOfSpecificEvent(id: number): Observable<IVenue> {
    return this.http.get<IVenue>(this.baseApiUrl + "Events/" + id + "/Venues");
  }
}
