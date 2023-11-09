﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPeliculas.Models
{
    public class Pelicula
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RutaImagen { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set;}
        public enum TipoClasificacion {Siete, Trece, Dieciseis, Dieciocho }
        public TipoClasificacion Clasificacion {  get; set; }
        public DateTime FechaCreacion { get; set; }

        [ForeignKey("categoriaId")]
        public int categoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
