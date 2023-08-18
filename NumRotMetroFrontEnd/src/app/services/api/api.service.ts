import { Injectable } from '@angular/core';
import { RegistroDeBaseDeDatosI } from 'src/app/Models/registro-de-base-de-datos.model';
import { ResponseI } from 'src/app/Models/response.model';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  url:string="http://localhost:5249/";
  constructor(private httpClient:HttpClient) { }

  RecuperarRegistros():Observable<RegistroDeBaseDeDatosI[]> {
    return this.httpClient.get<RegistroDeBaseDeDatosI[]>(this.url + "Registros");
  }
}
