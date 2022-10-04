import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import 'devextreme/data/odata/store';
import { ClienteModel } from 'src/app/core/models/cliente.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { HttpClientService } from 'src/app/core/services/httpclient.service';

@Component({
  templateUrl: 'cliente.component.html'
})

export class ClienteComponent {
  dataSource: any;
  cliente: ClienteModel;
  response: ResponseModel = new ResponseModel;
  newRow : any

  constructor(
    private httpClientService: HttpClientService,
    ) {

      this.cliente = {
        Id: 0,
        Nombre: "",
        Edad: 0
      } as ClienteModel
  }
  ngOnInit() {
    this.dataSource = [];
    this.consultar();
  }

  async consultar() {
    this.response = await this.httpClientService.consultar('/Cliente');
    this.dataSource = this.response.objetoResultado;
  }

  async eliminarRegistro(idRegistroEliminado: any) {
    this.response = await this.httpClientService.eliminar('/Cliente', idRegistroEliminado);
  }

  destinoRegistro(destino : any){
    if(destino.changes[0].type == "insert"){
      this.agregarRegistro(destino);
    }else if(destino.changes[0].type == "update"){
      this.editarRegistro(destino);
    }
  }

  async editarRegistro(registroEditado : any) {
    this.cliente = registroEditado.changes[0].data;
    this.response = await this.httpClientService.editar('/Cliente', this.cliente);
  }

  async agregarRegistro(registroCreado : any){
    this.cliente = {
      Id: 0,
      Nombre: registroCreado.changes[0].data.nombre,
      Edad: registroCreado.changes[0].data.edad
    } as ClienteModel
    this.response = await this.httpClientService.crear('/Cliente', this.cliente);
    this.consultar();
  }


}
