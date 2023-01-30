import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ISpeaker } from '../Models/Speaker';
import { ITalkDetails } from '../Models/TalkDetails';

@Injectable({
  providedIn: 'root'
})
export class SpeakerServicesService {

  baseApiUrl: string = environment.baseApiUrl; // referenced variable

  // to talk to external api need an http client
  constructor(private http: HttpClient) { }

  GetSpeakerByEventId(id: any): Observable<ISpeaker[]> {
    return this.http.get<ISpeaker[]>(this.baseApiUrl + "Events/" + id + "/Speakers");
  }

  GetSpeakerById(id: any): Observable<ISpeaker> {
    return this.http.get<ISpeaker>(this.baseApiUrl + "Speaker/" + id);
  }

  GetTalksBySpeakerForSpecificEvent(eventId: number, speakerId: number): Observable<ITalkDetails[]> {
    return this.http.get<ITalkDetails[]>(this.baseApiUrl + "Events/" + eventId + "/Speakers/" + speakerId + "/Talks");
  }
}