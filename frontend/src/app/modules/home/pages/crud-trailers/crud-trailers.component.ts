import { Component, Inject, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { ApiService } from 'src/app/shared/services/api/api.service';
import {BreakpointObserver} from '@angular/cdk/layout';
import {StepperOrientation} from '@angular/material/stepper';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';
import { IActor } from '../../interfaces/actor';
import { ITrailer } from '../../interfaces/trailer';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ITraillerActor } from '../../interfaces/trailler-actor';

@Component({
  selector: 'app-crud-trailers',
  templateUrl: './crud-trailers.component.html',
  styleUrls: ['./crud-trailers.component.css']
})
export class CrudTrailersComponent implements OnInit {
  //isOptional = false;
  // SELECCIONADO DE ACTORES LINEA 16-17
  // actores = new FormControl();
  actorList:IActor[]=[];

  
  trailer!:ITrailer;

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
    apellido: ''
  });

  nuevoActor = new FormGroup({
    nameActor: new FormControl(''),
    lastName: new FormControl('')
  })

  postActor(form: IActor){
    this.api.postActor(form).subscribe(data => {
      console.log(data);
    })
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
    actores: ['', [Validators.required]],
  });

  nuevoTrailer = new FormGroup({
    idTrailer: new FormControl(''),
    title: new FormControl(''),
    director: new FormControl(''),
    review: new FormControl(''),
    year_trailer: new FormControl(''),
    cover: new FormControl(''),
    link: new FormControl(''),
    rating: new FormControl(''),
    actores: new FormControl('')
  })

  postTrailer(form: ITrailer){
    this.api.postTrailer(form).subscribe(data =>{
      console.log(data)
    })
  }

  stepperOrientation: Observable<StepperOrientation>;
  constructor(private _formBuilder: FormBuilder, public dialogRef: MatDialogRef<CrudTrailersComponent>, breakpointObserver: BreakpointObserver, private api:ApiService,  @Inject(MAT_DIALOG_DATA) public editar: ITraillerActor) {
    
    this.stepperOrientation = breakpointObserver
      .observe('(min-width: 800px)')
      .pipe(map(({matches}) => (matches ? 'horizontal' : 'vertical')));
   }

    ngOnInit(): void {
      let Token = localStorage.getItem("Token");
      this.firstFormGroup.patchValue({
        'Token': Token
      });
      this.secondFormGroup.patchValue({
        'Token': Token
      })


      this.api.getActores().subscribe(x=>{
        this.actorList = x.result;
      })

      if (this.editar){
      this.onEdit();}

      // console.log(this.onEdit());
    }

    onCancel(){
      this.dialogRef.close();
    }

    evento(){
      console.log(this.firstFormGroup);
      console.log(this.secondFormGroup);
    }

    putTrailer(form: ITrailer){
    this.api.putTraillers(form).subscribe(data =>{
      console.log(data)
    })
  }

    onEdit() {
      console.log("entre");
      this.actorList = this.editar.actor;
      this.nuevoTrailer.controls['idTrailer'].setValue(this.editar.trailler.id);
      this.nuevoTrailer.controls['title'].setValue(this.editar.trailler.title);
      this.nuevoTrailer.controls['director'].setValue(this.editar.trailler.director);
      this.nuevoTrailer.controls['review'].setValue(this.editar.trailler.review);
      this.nuevoTrailer.controls['year_trailer'].setValue(this.editar.trailler.yearTrailer);
      this.nuevoTrailer.controls['cover'].setValue(this.editar.trailler.cover);
      this.nuevoTrailer.controls['link'].setValue(this.editar.trailler.link);
      this.nuevoTrailer.controls['rating'].setValue(this.editar.trailler.rating);
      this.nuevoTrailer.controls['actores'].setValue(this.editar.actor);
  }
}

