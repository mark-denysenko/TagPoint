import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { GeocoderResult } from '@agm/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

const proxyurl = "https://cors-anywhere.herokuapp.com/";
const googleApi = "https://maps.googleapis.com/maps/api/";

@Injectable({
  providedIn: 'root'
})
export class GoogleapiService {

  constructor(private readonly http: HttpClient) {}

  public placesNearGeocode(lat: number, lng: number): Observable<string> {
    return this.http.get<{ results: GeocoderResult[], plus_code: any }>(`${this.urlBuilder('geocode')}&latlng=${lat},${lng}`)
      .pipe(map(r => r.results[0].formatted_address));
  }

  public placesNearAddressGeocode(address: string): Observable<GeocoderResult[]> {
    return this.http.get<{ results: GeocoderResult[], plus_code: any }>(`${this.urlBuilder('geocode')}&address=${address}`)
      .pipe(map(r => r.results || []));
  }

  public placesNearPlaces(lat: number, lng: number, keyword: string | null = null): Observable<any[]> {
    return this.http.get<{ results: any[], plus_code: any }>(`${this.urlBuilder('place/nearbysearch')}&location=${lat},${lng}&radius=500` 
      + (keyword ? `&keyword=${keyword}` : '')).pipe(map(r => r.results));
  }

  // MAX_WIDTH - int value from 1 to 1600
  // MAX_HEIGHT - int value from 1 to 1600
  public getPhotoLinkByReference(ref: string, maxHeight: number = 400): string {
    return googleApi + `place/photo?maxheight=${maxHeight}&photoreference=${ref}&key=${environment.keys.gmap}`;
    //return proxyurl + googleApi + `places/photo?maxheight=${maxHeight}&photoreference=${ref}&key=${environment.keys.gmap}`;
    // https://maps.googleapis.com/maps/api/place/photo?maxwidth=400&photoreference=CnRtAAAATLZNl354RwP_9UKbQ_5Psy40texXePv4oAlgP4qNEkdIrkyse7rPXYGd9D_Uj1rVsQdWT4oRz4QrYAJNpFX7rzqqMlZw2h2E2y5IKMUZ7ouD_SlcHxYq1yL4KbKUv3qtWgTK0A6QbGh87GB3sscrHRIQiG2RrmU_jF4tENr9wGS_YxoUSSDrYjWmrNfeEHSGSc3FyhNLlBU&key=AIzaSyAsc-CRI5KjV2xe1H7rhM6Cp68I69n18rA
  }

  private urlBuilder(service: string): string {
    return proxyurl + googleApi + service + '/json?language=uk&key=' + environment.keys.gmap;
  }
}
