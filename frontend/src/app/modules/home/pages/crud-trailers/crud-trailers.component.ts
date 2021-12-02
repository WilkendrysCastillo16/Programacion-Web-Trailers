import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { ApiService } from 'src/app/shared/services/api/api.service';
import {BreakpointObserver} from '@angular/cdk/layout';
import {StepperOrientation} from '@angular/material/stepper';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import { IActor } from '../../interfaces/actor';

@Component({
  selector: 'app-crud-trailers',
  templateUrl: './crud-trailers.component.html',
  styleUrls: ['./crud-trailers.component.css']
})
export class CrudTrailersComponent implements OnInit {
  //isOptional = false;
  // SELECCIONADO DE ACTORES LINEA 16-17
  actores = new FormControl();
  actorList: string[] = ['Tokio', 'Profesor', 'Berlin', 'Nairobi', 'Rio', 'Denver'];

  

  // SELECCIONADO DE RATING LINEA 16-34
  autoTicks = false;
  disabled = false;
  invert = false;
  max = 5;
  min = 1;
  showTicks = true;
  step = 1;
  thumbLabel = true;
  value = 1;
  vertical = false;
  tickInterval = 1;

  getSliderTickInterval(): number | 'auto' {
    if (this.showTicks) {
      return this.autoTicks ? 'auto' : this.tickInterval;
    }

    return this.value;
  }

  firstFormGroup:FormGroup = this._formBuilder.group({
    id: '',
    nombre: '',
    apellido: '',
    token: ''
  });

  nuevoActor:FormGroup = new FormGroup({
      nombre : new FormControl(''),
      apellido : new FormControl(''),
  });

  postActor(form: IActor){
    // this.api.(form).subscribe(data => {
    //   let dataResponse : ILoginResponse = data;
    //   if(dataResponse.correcto){
    //     localStorage.setItem("Token", dataResponse.result)
    //     this.router.navigate(['principal']);
    //   }
    // })
  }

  secondFormGroup:FormGroup = this._formBuilder.group({
    idTrailer: '',
    title: ['', [Validators.required]],
    director: ['', [Validators.required]],
    review: ['', [Validators.required]],
    year_trailer: ['', [Validators.required]],
    cover: ['', [Validators.required]],
    link: ['', [Validators.required]],
    rating: ['', [Validators.required]],
  });
  stepperOrientation: Observable<StepperOrientation>;
  constructor(private _formBuilder: FormBuilder, breakpointObserver: BreakpointObserver, private api:ApiService) {
    
    this.stepperOrientation = breakpointObserver
      .observe('(min-width: 800px)')
      .pipe(map(({matches}) => (matches ? 'horizontal' : 'vertical')));
   }

    ngOnInit(): void {
      let token = localStorage.getItem("token");
      this.firstFormGroup.patchValue({
        'token':token
      });
    }

    onSubmit() {
      this.api.postActor({
        id: 0,
        nameActor: this.firstFormGroup.value.nombre,
        lastName: this.firstFormGroup.value.apellido,
      })
      .subscribe(respuesta =>{
        console.log("Todo Bien")
      })
    }

    evento(){
      // console.log(this.firstFormGroup);
      // console.log(this.secondFormGroup);
    }
}
