import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IEvent } from '../Models/Event';
import { IVenue } from '../Models/Venue';
import { EventServicesService } from '../Services/event-services.service';
import { VenueServicesService } from '../Services/venue-services.service';

@Component({
  selector: 'app-venues',
  templateUrl: './venues.component.html',
  styleUrls: ['./venues.component.css']
})
export class VenuesComponent implements OnInit {
  urlId!: any;
  venueData!: IVenue;
  eventData!: IEvent;
  venueName!: string;
  venueAddress!: string;
  venueCity!: string;
  venueWebsite!: string;
  venueContactNo!: string;
  eventName!: string;

  constructor(private eventService: EventServicesService,
    private venueService: VenueServicesService,
    private activatedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.urlId = this.activatedRoute.snapshot.paramMap.get('id');
    
    this.venueService.GetVenueOfSpecificEvent(this.urlId).subscribe({
      next: (x) => {
        this.venueData = x;
        this.venueName = this.venueData.name;
        this.venueAddress = this.venueData.address;
        this.venueCity = this.venueData.city;
        this.venueWebsite = this.venueData.website;
        this.venueContactNo = this.venueData.contactNo;
      },
      error: (response) => {
        console.log(response);
      }
    });
    this.eventService.GetEventById(this.urlId).subscribe({
      next: (x) => {
        this.eventData = x;
        this.eventName = this.eventData.name;
      },
      error: (response) => {
        console.log(response);
      }
    });
  }

}
