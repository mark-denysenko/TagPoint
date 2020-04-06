import { Component, OnInit, Output, EventEmitter, ViewChild, NgZone } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { AppInputTextComponent } from '../input/text/text.component';
import { MapsAPILoader } from '@agm/core';
import { google } from '@agm/core/services/google-maps-types';

@Component({
  selector: 'app-post-creator',
  templateUrl: './post-creator.component.html',
  styleUrls: ['./post-creator.component.scss']
})
export class PostCreatorComponent implements OnInit {

  public text: FormControl;
  public address: FormControl;

  private geoCoder : any;

  @ViewChild(AppInputTextComponent, {static: true}) addressRef!: AppInputTextComponent;

  @Output() sendPost = new EventEmitter<string>();

  constructor(
    private mapsAPILoader: MapsAPILoader,
    private ngZone: NgZone
  ) {
    this.text = new FormControl('', [Validators.required, Validators.maxLength(1000)]);
    this.address = new FormControl('', [Validators.maxLength(100)]);
  }

  ngOnInit() {
    console.log('adddd', this.addressRef);
    
    //load Places Autocomplete
    // this.mapsAPILoader.load().then(() => {
    //   this.geoCoder = new google.maps.Geocoder;
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
    this.address.valueChanges.pipe().subscribe(value => console.log(value));
  }

  public handleSendPost(): void {
    this.sendPost.emit(this.text.value);
  }

  public getAddress(latitude: any, longitude: any) {
    this.geoCoder.geocode({ 'location': { lat: latitude, lng: longitude } }, (results: { formatted_address: FormControl; }[], status: string) => {
      console.log(results);
      console.log(status);
      if (status === 'OK') {
        if (results[0]) {
          //this.zoom = 12;
          //this.address = results[0].formatted_address;
        } else {
          window.alert('No results found');
        }
      } else {
        window.alert('Geocoder failed due to: ' + status);
      }

    });
  }

}
