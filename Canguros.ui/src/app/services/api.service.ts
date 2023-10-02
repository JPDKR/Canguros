import { Injectable } from "@angular/core";
import { CangurosRequest } from "../models/cangurosRequest";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { CangurosResponse } from "../models/cangurosResponse";

@Injectable({
  providedIn: "root"
})
export class ApiService {
  private url = "http://localhost:5139/api/Canguros/GetCangurosDistanceAsync"; // URL to web api

  constructor(private http: HttpClient) { }

  public getCangurosDistance(data: CangurosRequest): Observable<Array<CangurosResponse>> {
    return this.http.get<Array<CangurosResponse>>(this.url +
      '?Canguro1Distancia=' + data.Canguro1Distancia +
      '&Canguro1Velocidad=' + data.Canguro1Velocidad +
      '&Canguro2Distancia=' + data.Canguro2Distancia +
      '&Canguro2Velocidad=' + data.Canguro2Velocidad);
  }
}