import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Usuario } from '../../models/Usuario';
import { UsuarioService } from './usuarios.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  titulo = 'Usuários';
  modalRef: BsModalRef;
  usuarioForm: FormGroup;
  novoUsuarioForm: FormGroup;
  usuarioSelecionado: Usuario;
  usuarioCadastrado: boolean;
  usuarioRemovido: Usuario;

  usuarios: Usuario[];

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  openDeleteModal(template: TemplateRef<any>, usuario: Usuario) {
    this.modalRef = this.modalService.show(template);
    this.usuarioRemovido = usuario;
  }

  constructor(private fb: FormBuilder,
    private modalService: BsModalService,
    private usuarioService: UsuarioService) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarUsuario();
  }

  carregarUsuario() {
    this.usuarioService.getAll().subscribe(
      (usuarios: Usuario[]) => {
        this.usuarios = usuarios;
      },
      (erro: any) => { console.log(erro) }
    )
  }

  criarForm() {
    this.usuarioForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      email: ['', Validators.required],
      permissao: ['', Validators.required],
      senha: ['', Validators.required]
    });
    this.novoUsuarioForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required],
      email: ['', Validators.required],
      permissao: ['', Validators.required],
      senha: ['', Validators.required]
    });
  }

  usuarioNovo(usuario: Usuario) {
    this.usuarioService.post(usuario).subscribe(
      () => {
        console.log(usuario);
        this.carregarUsuario();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  salvarUsuario(usuario: Usuario) {
    this.usuarioService.put(usuario.id, usuario).subscribe(
      () => {
        console.log(usuario);
        this.usuarioCadastrado = true;
        this.carregarUsuario();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  novoUsuarioSubmit() {
    let usuario = this.novoUsuarioForm.value;
    usuario.id = 0;
    this.usuarioNovo(usuario);
  }

  usuarioSubmit() {
    this.salvarUsuario(this.usuarioForm.value);
  }

  selecionarUsuario(usuario: Usuario) {
    this.usuarioSelecionado = usuario;
    this.usuarioForm.patchValue(usuario);
  }

  voltar() {
    this.usuarioSelecionado = null;
    this.usuarioCadastrado = false;
  }

  deletarUsuario(usuario: Usuario) {
    this.usuarioService.delete(usuario.id).subscribe(
      (model: any) => {
        console.log(model);
        this.usuarioRemovido = null;
        this.carregarUsuario();
      },
      (erro: any) => {
        console.log(erro);
      }
    )
  }
}
