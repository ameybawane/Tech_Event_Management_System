import { Component, OnInit } from '@angular/core';
import { IEvent } from '../Models/Event';
import { EventServicesService } from '../Services/event-services.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent implements OnInit {

  eventData: IEvent[] = [];
  date!: Date;

  constructor(private eventService: EventServicesService) { }

  ngOnInit(): void {
    this.date = new Date();
    var year = this.date.getFullYear();
    var month = this.date.getMonth() + 1;
    this.eventService.GetAllEventsByMonthYear(month, year).subscribe({
      next: (x) => {
        this.eventData = x;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

}
