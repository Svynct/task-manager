import { Component, OnInit } from '@angular/core';
import { AuthService } from '../login/auth.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  usuarioLogado: boolean = false;

  admLogado: boolean = false;

  constructor(private authService: AuthService) {
  }

  ngOnInit() {
    this.authService.admLogadoEmitter.subscribe(
      logado => this.admLogado = logado
    );
    this.authService.mostrarMenuEmitter.subscribe(
      mostrar => this.usuarioLogado = mostrar
    );
  }

  refresh() {
    window.location.reload();
  }
}
