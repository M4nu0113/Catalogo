﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Estados
    {
        [Key] public int Id { get; set; }
        public string? Nombre { get; set; }

        public void CambiarEstado()
        {
            // contenido del método
        }
    }
}