import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { PrendaComponent } from './prenda/prenda.component';
import { AltaEventosComponent } from './alta-eventos/alta-eventos.component';
import { CalendarioComponent } from './calendario/calendario.component';
import { AltaPrendaComponent } from './alta-prenda/alta-prenda.component';
import { SugerenciasComponent } from './sugerencias/sugerencias.component';

export const ROUTES: Routes = [
  { path: 'home/:id', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'prenda/:id', component: PrendaComponent },
  { path: 'altaEventos', component: AltaEventosComponent },
  { path: 'calendario', component: CalendarioComponent },
  { path: 'AltaPrenda/:id', component: AltaPrendaComponent },
  { path: 'sugerencia', component: SugerenciasComponent }

    {path: '**', pathMatch: 'full', redirectTo: 'login'}
];
