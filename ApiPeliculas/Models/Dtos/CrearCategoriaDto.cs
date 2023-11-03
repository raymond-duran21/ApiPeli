using System.ComponentModel.DataAnnotations;

namespace ApiPeliculas.Models.Dtos
{
    public class CrearCategoriaDto
    {
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(255, ErrorMessage = "El numero maximo de caracteres es 255.")]
        public string Nombre { get; set; }
    }
}
