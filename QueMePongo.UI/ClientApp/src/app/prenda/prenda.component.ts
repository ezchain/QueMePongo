import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ServiciosService } from 'src/app/services/servicios.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-prenda',
  templateUrl: './prenda.component.html',
  styleUrls: ['./prenda.component.css']
})
export class PrendaComponent implements OnInit {

  guardarropa: any = {}
  id: number;
  constructor(private activatedRoute: ActivatedRoute, private servicios: ServiciosService, private router: Router) {

    }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      this.ObtenerPrendas(params['id']);
      this.id = params['id'];
    });
  }

  ObtenerPrendas(id: number) {
    this.servicios.ObtenerPrendas(id).subscribe((data: any) => {
      console.log(data);

      this.guardarropa = data;
    });
  }
  

}
