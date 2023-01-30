import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IEvent } from '../Models/Event';
import { EventServicesService } from '../Services/event-services.service';

@Component({
  selector: 'app-view-event',
  templateUrl: './view-event.component.html',
  styleUrls: ['./view-event.component.css']
})
export class ViewEventComponent implements OnInit {
  urlId!: number;
  Name!: string;
  totalDays!: number;
  eventData!: IEvent;

  constructor(private eventService: EventServicesService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    
    this.eventService.GetEventById(id).subscribe({
      next: (x) => {
        this.eventData = x;
        this.Name = this.eventData.name;

        this.urlId = this.eventData.id;

        let startDt = (new Date(this.eventData.startDate));
        let endDt = (new Date(this.eventData.endDate));
        this.totalDays = Math.floor((endDt.getTime() - startDt.getTime()) / 1000 / 60 / 60 / 24);
        
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

}
