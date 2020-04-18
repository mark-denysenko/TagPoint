import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { GeocoderResult } from '@agm/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

const proxyurl = "https://cors-anywhere.herokuapp.com/";

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

  public placesNearPlaces(lat: number, lng: number, keyword: string | null = null): Observable<string[]> {
    return this.http.get<{ results: any[], plus_code: any }>(`${this.urlBuilder('place/nearbysearch')}&location=${lat},${lng}&radius=50` 
      + (keyword ? `&keyword=${keyword}` : '')).pipe(map(r => r.results.map(p => p.name)));
  }

  private urlBuilder(service: string): string {
    return proxyurl + 'https://maps.googleapis.com/maps/api/' + service + '/json?language=uk&key=' + environment.keys.gmap;
  }
}
