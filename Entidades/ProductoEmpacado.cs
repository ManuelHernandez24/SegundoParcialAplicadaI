using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenBlazor.Entidades
{
    public class ProductoEmpacado
    {
        [Key]
        public int ProductoEmpacadoId {get; set;}

        [Required]
        public DateTime FechaExpiracion {get; set; } = DateTime.Now;

        [Required(ErrorMessage = "No puede dejar el concepto vacio.")]
        [MinLength(3, ErrorMessage = "La descripcion al menos {1} caracteres")]
        public string Concepto {get; set;}

        [Required(ErrorMessage = "No puede dejar el producto producido vacio.")]
        public string ProductoProducido {get; set;}

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La existencia debe ser mayor a {1} y menor a {2}")]
        public int Cantidad {get; set;}

        public float PesoTotal {get; set;} //Peso en gramos

        [ForeignKey("ProductoEmpacadoId")]

        public virtual List<ProductoEmpacadoDetalle> ProductoEmpacadoDetalle {get;set;} = new List<ProductoEmpacadoDetalle>();
        
        //ProductoId, Descripcion, Existencia, Costo y ValorInventario
    }
}