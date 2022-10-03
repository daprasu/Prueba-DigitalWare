import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import 'devextreme/data/odata/store';
import { ProductoModel } from 'src/app/core/models/producto.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { HttpClientService } from 'src/app/core/services/httpclient.service';

@Component({
  templateUrl: 'producto.component.html'
})

export class ProductoComponent {
  dataSource: any;
  producto: ProductoModel;
  response: ResponseModel = new ResponseModel;

  constructor(
    private httpClientService: HttpClientService,
    ) {

      this.producto = {
        Id: 0,
        Nombre: "",
        Edad: 0
      } as ProductoModel
  }
  ngOnInit() {
    this.dataSource = [];
    this.consultar();
  }

  async consultar() {
    this.response = await this.httpClientService.consultar('/Producto');
    this.dataSource = this.response.objetoResultado;
  }

  async eliminarRegistro(idRegistroEliminado: any) {
    this.response = await this.httpClientService.eliminar('/Producto', idRegistroEliminado);
  }

  async editarRegistro(registroEditado : any) {
    this.producto = registroEditado.changes[0].data;
    this.response = await this.httpClientService.editar('/Producto', this.producto);
  }

  async agregarRegistro(registroCreado : any){
    if(registroCreado.data.id == undefined && registroCreado.rowIndex != 0){
      this.producto = {
        Id: 0,
        NombreProducto: registroCreado.data.nombreProducto,
        Existencia: registroCreado.data.existencia,
        Precio: registroCreado.data.precio
      } as ProductoModel
      this.response = await this.httpClientService.crear('/Producto', this.producto);
      this.consultar();
    }
    
  }


}
