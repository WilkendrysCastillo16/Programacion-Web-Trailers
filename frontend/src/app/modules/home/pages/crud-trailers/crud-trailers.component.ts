import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, ReactiveFormsModule } from '@angular/forms';
import { ApiService } from 'src/app/shared/services/api/api.service';
import { BreakpointObserver } from '@angular/cdk/layout';
import { StepperOrientation } from '@angular/material/stepper';
import { from, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IActor } from '../../interfaces/actor';
import { ITrailer } from '../../interfaces/trailer';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ITraillerActor } from '../../interfaces/trailler-actor';
import { ITraillerActorRela } from '../../interfaces/ITraillerActorR';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-crud-trailers',
  templateUrl: './crud-trailers.component.html',
  styleUrls: ['./crud-trailers.component.css']
})
export class CrudTrailersComponent implements OnInit {
  //isOptional = false;
  // SELECCIONADO DE ACTORES LINEA 16-17
  // actores = new FormControl();
  actorList: IActor[] = [];
  trailer!: ITrailer;
  traillerActor: ITraillerActorRela[] = [];

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

  firstFormGroup: FormGroup = this._formBuilder.group({
    id: '',
    nombre: '',
    apellido: ''
  });

  nuevoActor = new FormGroup({
    nameActor: new FormControl(''),
    lastName: new FormControl('')
  })

  secondFormGroup: FormGroup = this._formBuilder.group({
    idTrailer: '',
    title: ['', [Validators.required]],
    director: ['', [Validators.required]],
    review: ['', [Validators.required]],
    yearTrailer: ['', [Validators.required]],
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
    yearTrailer: new FormControl(''),
    cover: new FormControl(''),
    link: new FormControl(''),
    rating: new FormControl(''),
    actores: new FormControl('')
  })

  traillerActorRela: ITraillerActorRela = ({
    id: 0,
    idTrailler: 0,
    idActor: 0
  });

  stepperOrientation: Observable<StepperOrientation>;
  constructor(private _formBuilder: FormBuilder, public dialogRef: MatDialogRef<CrudTrailersComponent>, breakpointObserver: BreakpointObserver, private api: ApiService, @Inject(MAT_DIALOG_DATA) public editar: ITraillerActor) {
    
    this.stepperOrientation = breakpointObserver
      .observe('(min-width: 800px)')
      .pipe(map(({ matches }) => (matches ? 'horizontal' : 'vertical')));

  }

  ngOnInit(): void {
    let Token = localStorage.getItem("Token");
    this.firstFormGroup.patchValue({
      'Token': Token
    });
    this.secondFormGroup.patchValue({
      'Token': Token
    })

    if (this.editar) {
      this.onEdit();
      this.api.getActores().subscribe(x => {
        this.actorList = x.result;
        this.actorList = this.actorList.sort(function (a, b) {
          if (a.nameActor < b.nameActor) return -1;
          if (a.nameActor > b.nameActor) return 1;
          return 0;
        })
        for (let i = 0; i < this.actorList.length; i++) {
          for (let j = 0; j < this.editar.actor.length; j++) {
            if (this.actorList[i].id == this.editar.actor[j].id) {
              this.actorList[i] = this.editar.actor[j];
            }
          }
        }
      })
    }
    else {
      this.api.getActores().subscribe(x => {
        this.actorList = x.result;
        this.actorList = this.actorList.sort(function (a, b) {
          if (a.nameActor < b.nameActor) return -1;
          if (a.nameActor > b.nameActor) return 1;
          return 0;
        })
      })
    }
    // console.log(this.onEdit());
  }

  onCancel() {
    this.dialogRef.close();
  }

  evento() {
    this.api.getActores().subscribe(x => {
      this.actorList = x.result;
      this.actorList = this.actorList.sort(function (a, b) {
        if (a.nameActor < b.nameActor) return -1;
        if (a.nameActor > b.nameActor) return 1;
        return 0;
      })
    })
  }

  // buscarTraillerActor(idTrailler:number, idActor:number){
  //   this.api.getTraillerActorId().subscribe(data =>{
  //     for(let i = 0; i< data.result.length; i++){
  //       if(data.result[i].idTrailler == idTrailler && data.result[i].idActor == idActor){
  //         this.traillerActorRela.id = data.result[i].id;
  //         break;
  //       }
  //     }
  //   });
  // }

  postTrailer(form: any) {
    if (this.editar) {
      // let idTraillerR = 0; 
      // // this.buscarTraillerActor(form.idTrailer, form.actores[0].id);
      // // console.log(this.traillerActorRela.id);
      // this.api.putTraillers(form).subscribe(data => {
      //   idTraillerR = data.result.id;
      //   for (let i = 0; i < this.actorList.length; i++) {
      //     for (let j = 0; j < form.actores.length; j++) {
      //       if (form.actores[j].nameActor == this.actorList[i].nameActor && form.actores[j].lastName == this.actorList[i].lastName) {
      //         this.traillerActorRela.idTrailler = idTraillerR; //ID del trailler que se va a actualizar
      //         this.traillerActorRela.idActor = this.actorList[i].id; //ID del actor que se encontro selecionado
      //         //Buscara el ID de la relacion existente entre los dos ID encontrado anteriormente
      //         this.api.getTraillerActorId().subscribe(res =>{

      //           console.log(this.traillerActorRela.id);
      //           console.log(this.traillerActorRela.idTrailler);
      //           console.log(this.traillerActorRela.idActor);
      //           for(let k = 0; k< res.result.length; k++){
      //             // if(res.result[k].idTrailler == idTraillerR && res.result[k].idActor == this.actorList[i].id){
      //             //   // this.traillerActorRela.id = res.result[k].id;
      //             //   // console.log(this.traillerActorRela);

      //             //   console.log(res.result[k].id);
      //             //   console.log(res.result[k].idTrailler);
      //             //   console.log(res.result[k].idActor);
      //             // }
      //           }
      //         });           
      //         // this.api.putTraillerActor(this.traillerActorRela).subscribe(data => {
      //         //   console.log(data);
      //         // })
      //       }
      //     }
      //   }  
      // });
      // setTimeout(() =>  { location.reload(); },500); 
      // Swal.fire({
      //   icon: 'success',
      //   title: 'Trailler actualizado correctamente',
      //   showConfirmButton: false,
      //   timer: 1000
      // })
    }
    else {
      let idTraillerR = 0;

      this.api.postTrailer(form).subscribe(data => {
        idTraillerR = data.result.id;
        for (let i = 0; i < this.actorList.length; i++) {
          for (let j = 0; j < form.actores.length; j++) {
            if (form.actores[j].nameActor == this.actorList[i].nameActor && form.actores[j].lastName == this.actorList[i].lastName) {
              this.traillerActorRela.idTrailler = idTraillerR;
              this.traillerActorRela.idActor = this.actorList[i].id;
              console.log(this.traillerActorRela.idActor);
              console.log(this.traillerActorRela.idTrailler);
              this.api.postTraillerActor(this.traillerActorRela).subscribe(data => {
                console.log(data);
              })              
            }
          }
        }        
      });
      setTimeout(() => { location.reload(); },700); 
      Swal.fire({
        icon: 'success',
        title: 'Trailler agregado correctamente',
        showConfirmButton: false,
        timer: 1000
      }) 
    }
  }

  putTrailer(form: ITrailer) {
    this.api.putTraillers(form).subscribe(data => {
      console.log(data)
    })
  }

  getSliderTickInterval(): number | 'auto' {
    if (this.showTicks) {
      return this.autoTicks ? 'auto' : this.tickInterval;
    }

    return this.value;
  }

  postActor(form: IActor) {
    this.api.postActor(form).subscribe(data => {
      console.log(data);
    })
    Swal.fire({
        icon: 'success',
        title: 'Actor agregado correctamente',
        showConfirmButton: false,
        timer: 1000
      })
      this.nuevoActor.controls['nameActor'].setValue('');
      this.nuevoActor.controls['lastName'].setValue('');
  }

  onEdit() {
    this.nuevoTrailer.controls['idTrailer'].setValue(this.editar.trailler.id);
    this.nuevoTrailer.controls['title'].setValue(this.editar.trailler.title);
    this.nuevoTrailer.controls['director'].setValue(this.editar.trailler.director);
    this.nuevoTrailer.controls['review'].setValue(this.editar.trailler.review);
    this.nuevoTrailer.controls['yearTrailer'].setValue(this.editar.trailler.yearTrailer);
    this.nuevoTrailer.controls['cover'].setValue(this.editar.trailler.cover);
    this.nuevoTrailer.controls['link'].setValue(this.editar.trailler.link);
    this.value = this.editar.trailler.rating;
    this.nuevoTrailer.controls['rating'].setValue(this.editar.trailler.rating);
    this.nuevoTrailer.controls['actores'].setValue(this.editar.actor);

  }

}
