import { Component, OnInit } from '@angular/core';
import { ApiService } from './services/api.service';
import { CangurosRequest } from './models/cangurosRequest';
import { HttpParams } from '@angular/common/http';
import { CangurosResponse } from './models/cangurosResponse';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  x1!: number;
  x2!: number;
  v1!: number;
  v2!: number;
  cargando: boolean = false;
  seCruzan: boolean = false;
  error:boolean = false;

  cangurosRequest!: CangurosRequest;
  canguroResponse!: CangurosResponse[];
  salto!: number;

  constructor(private apiservice: ApiService) { }
  ngOnInit() { }

  numberOnly(event : any): boolean {
    const charCode = (event.which) ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
      return false;
    }
    return true;

  }

  calculateJump(): void {
    this.error = false;
if (this.x1 == null || this.x2 == null || this.v1 == null || this.v2 ==null){
this.error = true;
return;
}
    this.cangurosRequest = new CangurosRequest();
    this.cangurosRequest.Canguro1Distancia = this.x1;
    this.cangurosRequest.Canguro1Velocidad = this.v1;
    this.cangurosRequest.Canguro2Distancia = this.x2;
    this.cangurosRequest.Canguro2Velocidad = this.v2;

    this.seCruzan = false;

    this.apiservice
      .getCangurosDistance(this.cangurosRequest)
      .subscribe(value => {
        this.cargando = true;
        this.canguroResponse = value as CangurosResponse[];
        this.canguroResponse.forEach(element => {
          if (element.response) {
            this.seCruzan = element.response;
          }
        })

        this.salto = this.canguroResponse.length;
      });
  }

  
}