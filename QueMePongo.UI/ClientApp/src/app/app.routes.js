"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var home_component_1 = require("./home/home.component");
var login_component_1 = require("./login/login.component");
var prenda_component_1 = require("./prenda/prenda.component");
var alta_eventos_component_1 = require("./alta-eventos/alta-eventos.component");
var calendario_component_1 = require("./calendario/calendario.component");
var alta_prenda_component_1 = require("./alta-prenda/alta-prenda.component");
var sugerencias_component_1 = require("./sugerencias/sugerencias.component");
exports.ROUTES = [
    { path: 'home/:id', component: home_component_1.HomeComponent },
    { path: 'login', component: login_component_1.LoginComponent },
    { path: 'prenda/:id', component: prenda_component_1.PrendaComponent },
    { path: 'altaEventos', component: alta_eventos_component_1.AltaEventosComponent },
    { path: 'calendario', component: calendario_component_1.CalendarioComponent },
    { path: 'AltaPrenda/:id', component: alta_prenda_component_1.AltaPrendaComponent },
    { path: 'sugerencia', component: sugerencias_component_1.SugerenciasComponent },
    { path: '**', pathMatch: 'full', redirectTo: 'login' }
];
//# sourceMappingURL=app.routes.js.map