import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { throwError } from 'rxjs';


import { HttpErrorResponse } from '@angular/common/http';
import { ResponseModel } from '../models/response.model';
import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
})

export class HttpClientService {
    constructor(private _http: HttpClient) { }

    consultar(endpoint: string): Promise<object> {
        let response = this._http.get(`${environment.backend}${endpoint}/consultar`)
            .toPromise()
            .then(result => result as ResponseModel)
            .catch(this.handleError);
        return response;
    }

    consultarPorVentaId(endpoint: string, value : any): Promise<object> {
        let response = this._http.get(`${environment.backend}${endpoint}/consultarporventaId?ventaId=${value}`)
            .toPromise()
            .then(result => result as ResponseModel)
            .catch(this.handleError);
        return response;
    }

    editar(endpoint: string, value : any): Promise<object> {
        let response = this._http.put(`${environment.backend}${endpoint}/editar`, value)
            .toPromise()
            .then(result => result as ResponseModel)
            .catch(this.handleError);
        return response;
    }

    eliminar(endpoint: string, value : any): Promise<object> {
        let response = this._http.post(`${environment.backend}${endpoint}/eliminar?id=${value}`, [])
            .toPromise()
            .then(result => result as ResponseModel)
            .catch(this.handleError);
        return response;
    }

    crear(endpoint: string, value : any): Promise<object> {
        let response = this._http.post(`${environment.backend}${endpoint}/crear`, value)
            .toPromise()
            .then(result => result as ResponseModel)
            .catch(this.handleError);
        return response;
    }

    private handleError(error: HttpErrorResponse) {
        if (error.error instanceof ErrorEvent) {
            // Ocurre un error al lado del cliente o error de red
            console.error('Ocurrio un error:', error.error.message);
        } else {
            // El Api retorna respuesta no satisfactoria.
            // El cuerpo de la respueta puede contener algo que indique el error.
            console.error(
                `Api retorna codigo ${error.status}, ` +
                `con cuerpo: ${error.message}`);
        }
        // retorna un observable con mensaje de error
        return throwError(
            'Algo ha sucedio un error; favor intentarlo de nuevo más tarde.');
    }
}
