import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ServiciosService } from 'src/app/services/servicios.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  credenciales: FormGroup;

  constructor(private router: Router, private servicios: ServiciosService) {
    this.credenciales = new FormGroup({
      'username': new FormControl('', Validators.required),
      'password': new FormControl('', Validators.required)
    });
  }

  ngOnInit() {
  }

  Login() {
    //this.router.navigate(['home']);
    let req = { Username: this.credenciales.controls['username'].value, Catering: this.credenciales.controls['password'].value };
    this.servicios.Login(req).subscribe((data: any) => {
      console.log(data);
      
      this.router.navigate(['home']);
    });
  }

}
