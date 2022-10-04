import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import 'devextreme/data/odata/store';
import { VentaModel } from 'src/app/core/models/venta.model';
import { ResponseModel } from 'src/app/core/models/response.model';
import { HttpClientService } from 'src/app/core/services/httpclient.service';
import { Router } from '@angular/router';
import { VentaDetalleModel } from 'src/app/core/models/venta-detalle.model';

@Component({
  templateUrl: 'venta.component.html'
})

export class VentaComponent {
  dataSourceVenta: any;
  dataSourceVentaDetalle: any;
  listaProducto: any;
  venta: VentaModel;
  ventaDetalle: VentaDetalleModel;
  response: ResponseModel = new ResponseModel;
  ventaId: number =0;

  closeButtonOptions: any;
  popupVisible:boolean = false;

  constructor(
    private httpClientService: HttpClientService,
    private router: Router,
    ) {
      this.detalleVenta = this.detalleVenta.bind(this);
      const that = this;
      this.venta = {
        Id: 0,
        Nombre: "",
        Edad: 0
      } as VentaModel

      this.ventaDetalle = {
        Id: 0,
        ProductoId: 0,
        CantidadProducto: 0,
        VentaId : 0
      } as VentaDetalleModel

      this.closeButtonOptions = {
        text: 'Cerrar',
        onClick(e:any) {
          that.popupVisible = false;
        },
      };
  }
  ngOnInit() {
    this.dataSourceVenta = [];
    this.dataSourceVentaDetalle = [];
    this.listaProducto = [];
    this.consultar();
  }

  // Funcionalidad para Venta
  async consultar() {
    this.response = await this.httpClientService.consultar('/Venta');
    this.dataSourceVenta = this.response.objetoResultado;
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
    this.venta = {
      Id: 0,
      NombreProducto: registroCreado.changes[0].data.nombreProducto,
      Existencia: registroCreado.changes[0].data.existencia,
      Precio: registroCreado.changes[0].data.precio
    } as VentaModel
    this.response = await this.httpClientService.crear('/Venta', this.venta);
    this.consultar();
  }


  // Funcionalidad para VentaDetalle

  detalleVenta(registroDetalle : any){
    this.popupVisible = true;
    this.ventaId= registroDetalle.row.data.id;
    this.consultarVentaDetalle();
    this.consultarProductos();
  }

  async consultarVentaDetalle() {
    this.response = await this.httpClientService.consultarPorVentaId('/VentaDetalle', this.ventaId);
    this.dataSourceVentaDetalle = this.response.objetoResultado;
  }

  async eliminarRegistroVentaDetalle(idRegistroEliminado: any) {
    this.response = await this.httpClientService.eliminar('/VentaDetalle', idRegistroEliminado);
  }

  destinoRegistroVentaDetalle(destino : any){
    if(destino.changes[0].type == "insert"){
      this.agregarRegistroVentaDetalle(destino);
    }else if(destino.changes[0].type == "update"){
      this.editarRegistroVentaDetalle(destino);
    }
  }

  async editarRegistroVentaDetalle(registroEditado : any) {
    this.ventaDetalle = registroEditado.changes[0].data;
    this.response = await this.httpClientService.editar('/VentaDetalle', this.ventaDetalle);
  }
  async agregarRegistroVentaDetalle(registroCreado : any){
    this.ventaDetalle = {
      Id: 0,
      ProductoId: registroCreado.changes[0].data.productoId,
      CantidadProducto: registroCreado.changes[0].data.cantidadProducto,
      VentaId: this.ventaId
    } as VentaModel
    this.response = await this.httpClientService.crear('/VentaDetalle', this.ventaDetalle);
    this.consultarVentaDetalle();
  }

  // consulta lista productos

  async consultarProductos() {
    this.response = await this.httpClientService.consultar('/Producto');
    this.listaProducto = this.response.objetoResultado;
  }

}
