import { Component, OnInit } from '@angular/core';
import { ApiService } from 'src/app/shared/services/api/api.service';
import { ILogin } from '../../interfaces/login';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ILoginResponse } from '../../interfaces/login-response';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  loginForm = new FormGroup({
    email: new FormControl('', Validators.required),
    pass: new FormControl('', Validators.required)
  })

  
  constructor(private api:ApiService, private router:Router) { }

  ngOnInit(): void {


  }

  onLogin(form: ILogin){
    this.api.postLogin(form).subscribe(data => {
      let dataResponse : ILoginResponse = data;
      if(dataResponse.correcto){
        localStorage.setItem("Token", dataResponse.result)
        this.router.navigate(['principal']);
      }
    })
  }
}
