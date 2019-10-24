import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ServiciosService } from '../services/servicios.service';

@Component({
  selector: 'app-alta-eventos',
  templateUrl: './alta-eventos.component.html',
  styleUrls: ['./alta-eventos.component.css']
})
export class AltaEventosComponent implements OnInit {
  evento: FormGroup;
  constructor(private router: Router, private servicios: ServiciosService) {
    this.evento = new FormGroup({
      'nombre': new FormControl('', Validators.required),
      'ubicacion': new FormControl('', Validators.required),
      'fecha': new FormControl('', Validators.required),
      'frecuencia': new FormControl('', Validators.required)
    });
  }

  ngOnInit() {
  }

  Alta() {
    let ubicacion = { Latitud: 302, Longitud: 213 };
    let frecuencia = { Nombre: this.evento.controls['frecuencia'].value };
    let fecha = new Date(this.evento.controls['fecha'].value)
    let req = { Nombre: this.evento.controls['nombre'].value, Ubicacion: ubicacion,Fecha: fecha, Frecuencia: frecuencia };

    this.servicios.AltaEvento(req).subscribe((data: any) => {
      console.log(data);
    });
    this.router.navigate(['calendario']);

  }
}
