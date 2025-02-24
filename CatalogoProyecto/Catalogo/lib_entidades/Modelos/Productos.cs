﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_entidades.Modelos
{
    public class Productos
    {
        [Key] public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
        public int Fabricante { get; set; }
        public int Categoria { get; set; }

        [ForeignKey("Fabricante")] public Fabricantes? _Fabricante { get; set; }
        [ForeignKey("Categoria")] public Categorias? _Categoria { get; set; }

        public bool Validar()
        {
            if (string.IsNullOrEmpty(Codigo))
                return false;
            if (string.IsNullOrEmpty(Nombre))
                return false;
            if (Cantidad == 0)
                return false;
            if (Precio == 0)
                return false;
            if (Costo == 0)
                return false;
            if (Categoria == 0) 
                return false;
            if(Fabricante == 0)
                return false;
            return true;
        }
        public void ObtenerPublicaciones()
        {
            // contenido del método
        }
    }
}
