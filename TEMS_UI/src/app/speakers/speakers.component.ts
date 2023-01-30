import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ISpeaker } from '../Models/Speaker';
import { SpeakerServicesService } from '../Services/speaker-services.service';

@Component({
  selector: 'app-speakers',
  templateUrl: './speakers.component.html',
  styleUrls: ['./speakers.component.css']
})
export class SpeakersComponent implements OnInit {

  speakerData: ISpeaker[] = [];
  urlId!: any;
  
  constructor(private speakerService: SpeakerServicesService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.urlId = this.activatedRoute.snapshot.paramMap.get('id');
    this.speakerService.GetSpeakerByEventId(this.urlId).subscribe({
      next: (x) => {
        this.speakerData = x;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

}
