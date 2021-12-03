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


  constructor(private _http: HttpClient) { 
    // this.header.append("Content-Type", "application/json");
    // this.header.append("Authorization", "bearer " + localStorage.getItem("Token"));
  }

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

  //POST

  postActor(actor: IActor): Observable<IActor>{
    let Token = localStorage.getItem("Token");
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + Token
    })
    return this._http.post<IActor>(this.hostApi+'api/actors', actor, { headers: headers })
  }

  postLogin(form: ILogin): Observable<ILoginResponse>{
    return this._http.post<ILoginResponse>(this.hostApi + 'api/LoginAdmin/Login', form);
  }

  postTrailer(trailer: ITrailer): Observable<ITrailer>{
    let Token = localStorage.getItem("Token");
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + Token
    })
    return this._http.post<ITrailer>(this.hostApi+'api/traillers', trailer, { headers: headers })
  }


  //PUT

  putTraillers(trailer: ITrailer){
    return this._http.put(this.hostApi+ 'api/traillers', trailer);
  }



  //DELETE
  deleteTraillers(id: number): Observable<any>{
    let Token = localStorage.getItem("Token");
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + Token
    })
    return this._http.delete(this.hostApi+ 'api/traillers/'+ id, { headers: headers})
  }

}
