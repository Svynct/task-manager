import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Tarefa } from '../../models/Tarefa';
import { GerenciadorService } from './gerenciador.service';

@Component({
  selector: 'app-gerenciador',
  templateUrl: './gerenciador.component.html',
  styleUrls: ['./gerenciador.component.css']
})
export class GerenciadorComponent implements OnInit {

  titulo = 'Gerenciador de Tarefas';
  tarefaSelecionada: Tarefa;
  modalRef: BsModalRef;
  tarefaForm: FormGroup;
  novaTarefaForm: FormGroup;
  isDisabled: boolean;
  tarefaRemovida: Tarefa;

  tarefas: Tarefa[];

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }

  openDeleteModal(template: TemplateRef<any>, tarefa: Tarefa) {
    this.modalRef = this.modalService.show(template);
    this.tarefaRemovida = tarefa;
  }

  constructor(private fb: FormBuilder,
    private modalService: BsModalService,
    private tarefaService: GerenciadorService) {
    this.criarForm();
  }

  ngOnInit(): void {
    this.carregarTarefas();
  }

  carregarTarefas() {
    this.tarefaService.getAll().subscribe(
      (tarefas: Tarefa[]) => {
        this.tarefas = tarefas;
      },
      (erro: any) => {
        console.error(erro);
      }
    );
  }

  criarForm() {
    this.tarefaForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required]
    });
    this.novaTarefaForm = this.fb.group({
      id: [''],
      nome: ['', Validators.required]
    });
  }

  novaTarefa(tarefa: Tarefa) {
    this.tarefaService.post(tarefa).subscribe(
      () => {
        console.log(tarefa);
        this.carregarTarefas();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  salvarTarefa(tarefa: Tarefa) {
    this.tarefaService.put(tarefa.id, tarefa).subscribe(
      () => {
        console.log(tarefa);
        this.carregarTarefas();
      },
      (erro: any) => {
        console.log(erro);
      }
    );
  }

  novaTarefaSubmit() {
    let tarefa = this.novaTarefaForm.value;
    tarefa.id = 0;
    this.novaTarefa(tarefa);
  }

  tarefaSubmit() {
    this.salvarTarefa(this.tarefaForm.value);
  }

  selecionarTarefa(tarefa: Tarefa) {
    this.tarefaSelecionada = tarefa;
    this.tarefaForm.patchValue(tarefa);
  }

  voltar() {
    this.tarefaSelecionada = null;
  }

  deletarTarefa(tarefa: Tarefa) {
    this.tarefaService.delete(tarefa.id).subscribe(
      (model: any) => {
        console.log(model);
        this.carregarTarefas();
      },
      (erro: any) => {
        console.log(erro);
      }
    )
  }
}
