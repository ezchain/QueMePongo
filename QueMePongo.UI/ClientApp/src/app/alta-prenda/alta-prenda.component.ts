import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { ServiciosService } from '../services/servicios.service';

@Component({
  selector: 'app-alta-prenda',
  templateUrl: './alta-prenda.component.html',
  styleUrls: ['./alta-prenda.component.css']
})
export class AltaPrendaComponent implements OnInit {
  cambioPagina: boolean = false;
  id: any;
  prenda: FormGroup;
  constructor(private router: Router, private servicios: ServiciosService, private activatedRoute: ActivatedRoute) {
    this.prenda = new FormGroup({
      'nombre': new FormControl('', Validators.required),
      'categoria': new FormControl('', Validators.required),
      'colorPrimario': new FormControl('', Validators.required),
      'colorSecundario': new FormControl('', Validators.required),
      'formalidad': new FormControl('', Validators.required),
      'temperatura': new FormControl('', Validators.required),
      'tela': new FormControl('', Validators.required)
    });
  }

  ngOnInit() {
    this.activatedRoute.params.subscribe(params => {
      
      this.id = params['id'];
    });
  }

  public CambiarPagina() {
    this.cambioPagina = true;
  }

  public AltaPrenda() {
    let tipoPrenda = { Temperatura: this.prenda.controls['temperatura'].value, Formalidad: this.prenda.controls['formalidad'].value };

    let req = {
      Nombre: this.prenda.controls['nombre'].value, GuardarropaId: this.id,
      Categoria: this.prenda.controls['categoria'].value,
      Tela: this.prenda.controls['tela'].value,
      ColorPrimario: this.prenda.controls['colorPrimario'].value,
      ColorSecundario: this.prenda.controls['colorSecundario'].value,
      Tipo: tipoPrenda };

    this.servicios.AltaPrenda(req).subscribe((data: any) => {
      console.log(data);
    });
    
  }

}

