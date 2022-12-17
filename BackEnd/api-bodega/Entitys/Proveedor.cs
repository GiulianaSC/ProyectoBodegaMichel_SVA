using System.ComponentModel.DataAnnotations;
namespace api_bodega.Entitys
{
    public class Proveedor
    {
            [Key]
            public int idProveedor { get; set; }
            [Required]
            public string ruc { get; set; }
            [Required]
            public string nombre { get; set; }
            [Required]
            public string telefono { get; set; }

            public string email { get; set; }
            [Required]
            public string direccion { get; set; }

            [Required]
            public bool estadoProveedor{ get; set; }
            [Required]
             public int idCategoria { get; set; }
             public Categoria categoria { get; set; }

    }
}
