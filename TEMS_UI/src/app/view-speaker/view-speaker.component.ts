import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ISpeaker } from '../Models/Speaker';
import { ITalkDetails } from '../Models/TalkDetails';
import { SpeakerServicesService } from '../Services/speaker-services.service';

@Component({
  selector: 'app-view-speaker',
  templateUrl: './view-speaker.component.html',
  styleUrls: ['./view-speaker.component.css']
})
export class ViewSpeakerComponent implements OnInit {

  speakerId!: any;
  eventId!: any;
  speakerData!: ISpeaker;
  speakerName!: string;
  speakerOrganisation!: string;
  speakerTwitterHandle!: string;
  speakerDescription!: string;
  talksData!: ITalkDetails[];
  

  constructor(private activatedRoute: ActivatedRoute,
    private speakerService: SpeakerServicesService) { }

  ngOnInit(): void {
    this.speakerId = this.activatedRoute.snapshot.paramMap.get('id');

    this.eventId = this.activatedRoute.snapshot.paramMap.get('eventId');

    this.speakerService.GetSpeakerById(this.speakerId).subscribe({
      next: (x) => {
        this.speakerData = x;
        this.speakerName = this.speakerData.name;
        this.speakerOrganisation = this.speakerData.organisation;
        this.speakerTwitterHandle = this.speakerData.twitterHandle;
        this.speakerDescription = this.speakerData.description;
      },
      error: (response) => {
        console.log(response);
      }
    });

    this.speakerService.GetTalksBySpeakerForSpecificEvent(this.eventId, this.speakerId).subscribe({
      next: (x) => {
        this.talksData = x;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

}
