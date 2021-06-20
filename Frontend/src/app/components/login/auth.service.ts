import { EventEmitter, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Usuario } from 'src/app/models/Usuario';
import { UsuarioService } from '../usuarios/usuarios.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  usuarioAutenticado: boolean = false;

  usuarioLogado: Observable<Usuario>;

  usuarioIncorretoEmitter = new EventEmitter<boolean>();

  mostrarMenuEmitter = new EventEmitter<boolean>();

  admLogadoEmitter = new EventEmitter<boolean>();

  usuarios: Usuario[];

  constructor(private usuarioService: UsuarioService, private router: Router) {
    this.usuarioService.getAll().subscribe(
      (usuarios: Usuario[]) => {
        this.usuarios = usuarios;
      },
      (erro: any) => { console.log(erro) }
    );
  }

  fazerLogin(usuario: Usuario) {

    this.usuarios.forEach(item => {
      if (item.nome === usuario.nome &&
        item.senha === usuario.senha) {

        if (item.permissao == 'Administrador') {
          this.admLogadoEmitter.emit(true);
        }

        this.usuarioLogado = new Observable(
          observer => {
            observer.next(item);
          });

        this.usuarioAutenticado = true;

        this.mostrarMenuEmitter.emit(true);

        this.router.navigate(['/']);

        return;
      } else {

        this.usuarioIncorretoEmitter.emit(true);

      }
    });
  };

  usuarioEstaAutenticado() {
    return this.usuarioAutenticado;
  }
}
