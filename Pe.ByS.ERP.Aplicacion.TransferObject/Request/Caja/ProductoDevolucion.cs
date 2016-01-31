using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pe.ByS.ERP.Aplicacion.TransferObject.Request.Caja
{
    public class ProductoDevolucion
    {
        public int EstadoSolicitud { get; set; }
        public String cantidadDevolucionControl { get; set; }
        public int cantidadDevolucionValue { get; set; }
        public int cantidadProducto { get; set; }
        public String descripcionProducto { get; set; }
        public double descuento { get; set; }
        public int documentoPagoId { get; set; }
        public double precioProducto { get; set; }
        public String presentacionProducto { get; set; }
        public int productoId { get; set; }
        public double subtotal { get; set; }
        public String subtotalDevolucionControl { get; set; }
        public double subtotalDevolucionValue { get; set; }

        /*
         * 
            EstadoSolicitud: 1
            cantidadDevolucionControl: "<input id="txtCantidadDevolucion_1" type="number" class="form-control" min="0" max="2" value="0">"
            cantidadDevolucionValue: "1"
            cantidadProducto: 2
            descripcionProducto: "PARACETAMOL"
            descuento: 0.5
            documentoPagoId: 32
            precioProducto: 8.5
            presentacionProducto: "TAB. 40X2"
            productoId: 1
            subtotal: 8
            subtotalDevolucionControl: "<input id="txtSubTotal_1" class="form-control" value="0.00" disabled="disabled"/>"
            subtotalDevolucionValue: "8.50"
         * */

    }
}
