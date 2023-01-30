import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSpeakerComponent } from './view-speaker.component';

describe('ViewSpeakerComponent', () => {
  let component: ViewSpeakerComponent;
  let fixture: ComponentFixture<ViewSpeakerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewSpeakerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewSpeakerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
