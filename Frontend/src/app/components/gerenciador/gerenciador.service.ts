import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Tarefa } from '../../models/Tarefa';

@Injectable({
  providedIn: 'root'
})
export class GerenciadorService {

  baseUrl = `${environment.baseUrl}/api/tarefa`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Tarefa[]> {
    return this.http.get<Tarefa[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Tarefa> {
    return this.http.get<Tarefa>(`${this.baseUrl}/${id}`);
  }

  post(tarefa: Tarefa) {
    return this.http.post(`${this.baseUrl}/registrar`, tarefa);
  }

  put(id: number, tarefa: Tarefa) {
    return this.http.put(`${this.baseUrl}/${id}`, tarefa);
  }

  delete(id: number): Observable<Tarefa> {
    return this.http.delete<Tarefa>(`${this.baseUrl}/${id}`);
  }
}
