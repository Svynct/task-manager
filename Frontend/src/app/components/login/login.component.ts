import { Component, OnInit } from '@angular/core';
import { Usuario } from 'src/app/models/Usuario';
import { AuthService } from './auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  usuario: Usuario = new Usuario();

  usuarioIncorreto: boolean;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.authService.usuarioIncorretoEmitter.subscribe(
      mostrar => this.usuarioIncorreto = mostrar
    );
  }

  fazerLogin() {
    this.authService.fazerLogin(this.usuario);
  }
}
