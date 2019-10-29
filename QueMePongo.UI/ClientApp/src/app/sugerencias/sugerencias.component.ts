import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ServiciosService } from '../services/servicios.service';

@Component({
  selector: 'app-sugerencias',
  templateUrl: './sugerencias.component.html',
  styleUrls: ['./sugerencias.component.css']
})
export class SugerenciasComponent implements OnInit {
  sugerencia: any = {}
  eventos: any = []
  selectedOption: any = {}
  prendas:any = []
  cambioPagina: boolean = false;

  constructor(private activatedRoute: ActivatedRoute, private servicios: ServiciosService, private router: Router) {

  }

  ngOnInit() {
    this.ObtenerEventos();
  }

  public ObtenerEventos() {
    this.servicios.ObtenerEventos().subscribe((data: any) => {
      console.log(data);

      this.eventos = data;
    });
  }

  public ObtenerSugerencia() {
    if (this.selectedOption > 0) {
      //console.log(this.eventos);
      //console.log(this.selectedOption);
      let evento = this.eventos.find(x => x.eventoId == this.selectedOption);
      //console.log(evento);
      let request = { EventoId: evento.eventoId, Nombre: evento.nombre, UsuarioId: evento.usuarioId };
      this.servicios.ObtenerSugerencia(request).subscribe((data: any) => {
        console.log(data);
        this.cambioPagina = true;
        this.sugerencia = data;
        this.prendas = data.atuendo.prendas;
        console.log(this.sugerencia)
      });
    }
    
  }

  public Aceptar() {
    this.servicios.AceptarSugerencia(this.sugerencia).subscribe((data: any) => {
      console.log(data);
    });
  }

}
