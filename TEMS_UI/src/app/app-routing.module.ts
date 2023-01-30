import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventsComponent } from './events/events.component';
import { SpeakersComponent } from './speakers/speakers.component';
import { VenuesComponent } from './venues/venues.component';
import { ViewEventComponent } from './view-event/view-event.component';
import { ViewSpeakerComponent } from './view-speaker/view-speaker.component';

const routes: Routes = [
  { path: '', redirectTo: 'events', pathMatch: 'full' },
  { path: 'events', component: EventsComponent },
  { path: 'Events/:id', component: ViewEventComponent },
  { path: 'Events/:id/Speakers', component: SpeakersComponent },
  { path: 'Speakers/:id/Events/:eventId', component: ViewSpeakerComponent },
  { path: 'Events/:id/Venues', component: VenuesComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
