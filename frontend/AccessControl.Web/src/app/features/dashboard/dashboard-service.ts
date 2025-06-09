import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "../../../environments/environment";


@Injectable({
  providedIn: 'root',
})
export class DashboardService {
  constructor(private _http: HttpClient) {}

  getWeatherForecastList(): Observable<any> {
    return this._http.get(`${environment.apiUrl}/WeatherForecast`);
  }
}