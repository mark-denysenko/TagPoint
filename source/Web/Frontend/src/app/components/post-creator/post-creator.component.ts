import { Component, OnInit, Output, EventEmitter, ViewChild, NgZone, ElementRef, Input, OnChanges, SimpleChanges } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AppInputTextComponent } from '../input/text/text.component';
import { MapsAPILoader, GeocoderResult, GeocoderStatus } from '@agm/core';
import { Observable } from 'rxjs';
import { GoogleapiService } from 'src/app/services/googleapi.service';
import { map } from 'rxjs/operators';

declare var google: any;

@Component({
  selector: 'app-post-creator',
  templateUrl: './post-creator.component.html',
  styleUrls: ['./post-creator.component.scss']
})
export class PostCreatorComponent implements OnInit, OnChanges {

  @Input() place!: Marker;
  public text: FormControl;
  public location: FormControl;

  public addressesNear: string[] = [];
  public suggestedLocations$!: Observable<string[]>;

  @Output() sendPost = new EventEmitter<{ message: string, location: string }>();

  constructor(
    private readonly googleApiService: GoogleapiService,
    private mapsAPILoader: MapsAPILoader
  ) {
    this.text = new FormControl('', [Validators.required, Validators.maxLength(1000)]);
    this.location = new FormControl('', [Validators.maxLength(100)]);
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.place.currentValue) {
      const newPlace = changes.place.currentValue;
      this.googleApiService.placesNearPlaces(newPlace.latitude, newPlace.longitude).subscribe(places => {
        this.addressesNear = places;
        this.location.updateValueAndValidity({ onlySelf: false, emitEvent: true });
      });
    }
  }

  ngOnInit() {    
    //load Places Autocomplete
    // this.mapsAPILoader.load().then(() => {
    //   this.geoCoder = new google.maps.Geocoder();

    //   let autocomplete = new google.maps.places.Autocomplete(this.addressRef, {
    //     types: ["address"]
    //   });
    //   autocomplete.addListener("place_changed", () => {
    //     this.ngZone.run(() => {
    //       //get the place result
    //       //let place: google.maps.places.PlaceResult = autocomplete.getPlace();
    //       let place = autocomplete.getPlace();

    //       //verify result
    //       if (place.geometry === undefined || place.geometry === null) {
    //         return;
    //       }

    //       //set latitude, longitude and zoom
    //       // this.latitude = place.geometry.location.lat();
    //       // this.longitude = place.geometry.location.lng();
    //       // this.zoom = 12;
    //     });
    //   });
    // });
    this.suggestedLocations$ = this.location.valueChanges.pipe(
      map((loc: string) => {
        const searchLocation = loc.trim().toLowerCase();

        if (searchLocation.length === 0) {
          return this.addressesNear;

        }

        return this.addressesNear.filter(add => add.toLowerCase().includes(searchLocation));
      }));
  }

  public selectLocation(location: string): void {
    this.location.setValue(location);
  }

  public handleSendPost(): void {
    this.sendPost.emit({ message: this.text.value, location: this.location.value });
  }
}
