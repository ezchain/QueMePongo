import { Component } from '@angular/core';

import { ActivatedRoute } from '@angular/router';
import { ServiciosService } from 'src/app/services/servicios.service';

import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  usuario: any = {}

  constructor(private activatedRoute: ActivatedRoute, private servicios:ServiciosService, private router:Router) {
    this.activatedRoute.params.subscribe(params => {
      this.ObtenerUsuario(params['id']);
    }
    }

  ObtenerUsuario(id: number) {
    this.servicios.ObtenerUsuario(id).subscribe((data: any) => {
      console.log(data);

      this.usuario = data;
    });
  }

}
