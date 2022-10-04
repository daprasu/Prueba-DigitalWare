import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import 'devextreme/data/odata/store';
import { VentaModel } from 'src/app/core/models/venta.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { HttpClientService } from 'src/app/core/services/httpclient.service';
import { Router } from '@angular/router';

@Component({
  templateUrl: 'venta.component.html'
})

export class VentaComponent {
  dataSource: any;
  venta: VentaModel;
  response: ResponseModel = new ResponseModel;

  constructor(
    private httpClientService: HttpClientService,
    private router: Router,
    ) {

      this.venta = {
        Id: 0,
        Nombre: "",
        Edad: 0
      } as VentaModel
  }
  ngOnInit() {
    this.dataSource = [];
    this.consultar();
  }

  async consultar() {
    this.response = await this.httpClientService.consultar('/Venta');
    this.dataSource = this.response.objetoResultado;
  }

  async eliminarRegistro(idRegistroEliminado: any) {
    this.response = await this.httpClientService.eliminar('/Venta', idRegistroEliminado);
  }

  destinoRegistro(destino : any){
    if(destino.changes[0].type == "insert"){
      this.agregarRegistro(destino);
    }else if(destino.changes[0].type == "update"){
      this.editarRegistro(destino);
    }
  }

  async editarRegistro(registroEditado : any) {
    this.venta = registroEditado.changes[0].data;
    this.response = await this.httpClientService.editar('/Venta', this.venta);
  }
  async agregarRegistro(registroCreado : any){
    if(registroCreado.data.id == undefined && registroCreado.rowIndex != 0){
      this.venta = {
        Id: 0,
        NombreProducto: registroCreado.changes[0].data.nombreProducto,
        Existencia: registroCreado.changes[0].data.existencia,
        Precio: registroCreado.changes[0].data.precio
      } as VentaModel
      this.response = await this.httpClientService.crear('/Venta', this.venta);
      this.consultar();
    }
  }

  detalleRegistro(e : any){
    this.router.navigate(['/venta-detalle/']);
    let r= e;
  }


}
