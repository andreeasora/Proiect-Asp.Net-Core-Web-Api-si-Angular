import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Client } from '../interfaces/client';

@Injectable({
  providedIn: 'root'
})

export class ClientiService {

  public url = 'https://localhost:5001/api/client';
  constructor(
    public http: HttpClient,
  ) { }

  public getAllClients() : Observable<Client[]>{
    return this.http.get<Client[]>(`${this.url}`);
  }

  public getClientById(id: any) : Observable<Client>{
    return this.http.get<Client>(`${this.url}/${id}`);
  }

  public deleteClient(client: any) : Observable<any>{
    const opt = {
      headers: new HttpHeaders(),
      body: client
    }
    return this.http.delete(`${this.url}`, opt);
  }

  public adaugaClient(client: any) : Observable<any>{
    return this.http.post(`${this.url}`, client);
  }

  public updateClient(client: any) : Observable<any>{
    return this.http.put(`${this.url}`, client);
  }
}
