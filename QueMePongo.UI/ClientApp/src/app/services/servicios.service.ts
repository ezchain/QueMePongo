import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ServiciosService {
  //const url = `	https://api.spotify.com/v1/${query}`; 
  constructor(private http: HttpClient) { }

  Login(credenciales: any) {

    //let headers = new Headers({
    //  'Content-Type': 'application/json'
    //});
    return this.http.post("https://localhost:44302/api/Login/Authenticate", credenciales);
  }
  ObtenerUsuario(id: number) {
    return this.http.get(`http://localhost:51368/api/Usuario/${id}`);
  }

  ObtenerPrendas(id: number) {
    return this.http.get(`http://localhost:51368/api/Guardarropa/${id}`);
  }

  AltaEvento(evento: any) {
    console.log(evento);
    return this.http.post('http://localhost:51368/api/Usuario/AgregarEvento',evento);
  }

  ObtenerEventos() {
    return this.http.get('http://localhost:51368/api/Usuario/ObtenerEventos');
  }

  AltaPrenda(prenda:any) {

    console.log(prenda);
    return this.http.post('http://localhost:51368/api/Prenda', prenda);
  }

}
