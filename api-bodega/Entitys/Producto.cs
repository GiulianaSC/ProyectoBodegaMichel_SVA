using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_bodega.Entitys
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Verifique la descripción del producto")]
        public string DescripcionProducto { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PrecioCompra { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PrecioVenta { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public bool EstadoProducto { get; set; }

        public List<DetalleComprobante> detallecomprobante { get; set; }
    }
}
