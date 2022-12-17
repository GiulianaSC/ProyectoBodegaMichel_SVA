using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace api_bodega.Entitys
{
    public class Distrito
    {
        [Key]
        public int idDistrito { get; set; }
        [Required]
        public string nomDistrito { get; set; }

        public string comDistrito { get; set; }
        [Required]
        public bool estadoDistrito { get; set; }

        public List<Cliente> cliente { get; set; }
    }
}
