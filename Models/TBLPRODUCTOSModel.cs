using System.ComponentModel.DataAnnotations;    

namespace CRUDPROJECT.Models
{
    public class TBLPRODUCTOSModel
    {

        public int IdProducto  { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string NombreProd { get; set; }
        [Required(ErrorMessage = "El campo Precio es obligatorio")]
        public int Precio { get; set; }
        [Required(ErrorMessage = "El campo Descripcion es obligatorio")]
        public string DescripcionProd { get; set; }
    
    }
}
