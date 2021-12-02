import { ILogin } from './../../../modules/home/interfaces/login';
import { ITrailer } from './../../../modules/home/interfaces/trailer';
import { IActor } from './../../../modules/home/interfaces/actor';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ITraillerActor } from 'src/app/modules/home/interfaces/trailler-actor';
import { ILoginResponse } from 'src/app/modules/home/interfaces/login-response';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private _http: HttpClient) { }

  private hostApi: string = 'https://api-trailler.azurewebsites.net/';

  //GET ALL

  getActores(): Observable<any>{
    return this._http.get(this.hostApi +'api/actors');
  }

  getTraillers(): Observable<ITrailer[]>{
    return this._http.get<ITrailer[]>(this.hostApi +'api/traillers');
  } // https://api-trailler.azurewebsites.net/api/traillers

  getTraillerActor(): Observable<any>{
    return this._http.get(this.hostApi +'api/trailleractor/completo');
  }

  postLogin(form: ILogin): Observable<ILoginResponse>{
    return this._http.post<ILoginResponse>(this.hostApi + 'api/LoginAdmin/Login', form);
  }

}
