import { Component, OnInit } from '@angular/core';
import dayGridPlugin from '@fullcalendar/daygrid';
import { Router } from '@angular/router';
import { ServiciosService } from '../services/servicios.service';

@Component({
  selector: 'app-calendario',
  templateUrl: './calendario.component.html',
  styleUrls: ['./calendario.component.css']
})
export class CalendarioComponent implements OnInit {
  calendarPlugins = [dayGridPlugin];
  calendarEvents = [];
  



  constructor(private servicios: ServiciosService) {

  }
  ngOnInit() {
    this.ObtenerEventos();
    
  }

  ObtenerEventos() {
    this.servicios.ObtenerEventos().subscribe((data: any) => {
      console.log(data);
      data.forEach(parametro => {
        console.log(parametro.nombre);
        this.calendarEvents = this.calendarEvents.concat({ 
      { title: parametro.nombre, date: parametro.fechaInicio }
    });
      });
    });

}

