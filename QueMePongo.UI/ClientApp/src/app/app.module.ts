import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { LoginComponent } from './login/login.component';
import { ROUTES } from './app.routes';

import { ServiciosService } from 'src/app/services/servicios.service';
import { PrendaComponent } from './prenda/prenda.component';
import { ColorPipe } from './color.pipe';
import { TelaPipe } from './tela-pipe';
import { CategoriaPipe } from './categoria.pipe';
import { AltaEventosComponent } from './alta-eventos/alta-eventos.component';

import { FullCalendarModule } from '@fullcalendar/angular';
import { CalendarioComponent } from './calendario/calendario.component';
import { AltaPrendaComponent } from './alta-prenda/alta-prenda.component';
import { SugerenciasComponent } from './sugerencias/sugerencias.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    LoginComponent,
    PrendaComponent,
    ColorPipe,
    TelaPipe,
    CategoriaPipe,
    AltaEventosComponent,
    CalendarioComponent,
    AltaPrendaComponent,
    SugerenciasComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    FullCalendarModule,
    RouterModule.forRoot(ROUTES, { useHash: true })
  ],
  providers: [ServiciosService],
  bootstrap: [AppComponent]
})
export class AppModule { }
