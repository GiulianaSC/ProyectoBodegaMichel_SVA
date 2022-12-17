using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace api_bodega.Entitys
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        [Required]
        public string nomCategoria { get; set; }

        public string comCategoria { get; set; }

        [Required]
        public bool estadoCategoria { get; set; }
        public List<Producto> producto { get; set; }

        public List<Proveedor> proveedor { get; set; }

    }
}
