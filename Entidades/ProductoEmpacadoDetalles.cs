using System.ComponentModel.DataAnnotations;
using ExamenBlazor.Entidades;

namespace ExamenBlazor.Entidades
{

    public partial class ProductoEmpacadoDetalle
    {

        [Key]
        public int ProductoEmpacadoDetallesId { get; set; }
        public int ProductoEmpacadoId { get; set; }
        public string? Descripcion { get; set; }
        public int Cantidad { get; set; }

        public ProductoEmpacadoDetalle(string descripcion, int cantidad)
        {
            Descripcion = descripcion;
            Cantidad = cantidad;
        }
    }
}