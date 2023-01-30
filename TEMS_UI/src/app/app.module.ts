import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventsComponent } from './events/events.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ViewEventComponent } from './view-event/view-event.component';
import { SpeakersComponent } from './speakers/speakers.component';
import { VenuesComponent } from './venues/venues.component';
import { ViewSpeakerComponent } from './view-speaker/view-speaker.component';

@NgModule({
  declarations: [
    AppComponent,
    EventsComponent,
    ViewEventComponent,
    SpeakersComponent,
    VenuesComponent,
    ViewSpeakerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
