"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var home_component_1 = require("./home/home.component");
var login_component_1 = require("./login/login.component");
var prenda_component_1 = require("./prenda/prenda.component");
exports.ROUTES = [
    { path: 'home/:id', component: home_component_1.HomeComponent },
    { path: 'login', component: login_component_1.LoginComponent },
    { path: 'prenda/:id', component: prenda_component_1.PrendaComponent },
    { path: '**', pathMatch: 'full', redirectTo: 'login' }
];
//# sourceMappingURL=app.routes.js.map