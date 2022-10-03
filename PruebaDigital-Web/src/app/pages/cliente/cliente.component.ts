import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import 'devextreme/data/odata/store';
import { ClienteModel } from 'src/app/core/models/cliente.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { HttpClientService } from 'src/app/core/services/httpclient.service';
import {
  DxDataGridModule,
  DxDataGridComponent,
  DxSpeedDialActionModule,
  DxSelectBoxModule,} from 'devextreme-angular';
import { BrowserModule } from '@angular/platform-browser';
import {
  NgModule, ViewChild, enableProdMode,
} from '@angular/core';

@Component({
  templateUrl: 'cliente.component.html'
})

export class ClienteComponent {
  dataSource: any;
  cliente: ClienteModel;
  response: ResponseModel = new ResponseModel;

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

  async editarRegistro(registroEditado : any) {
    this.cliente = registroEditado.changes[0].data;
    this.response = await this.httpClientService.editar('/Cliente', this.cliente);
  }

  async agregarRegistro(registroCreado : any){
    if(registroCreado.data.id == undefined && registroCreado.rowIndex != 0){
      this.cliente = {
        Id: 0,
        Nombre: registroCreado.data.nombre,
        Edad: registroCreado.data.edad
      } as ClienteModel
      this.response = await this.httpClientService.crear('/Cliente', this.cliente);
      this.consultar();
    }
    
  }


}
