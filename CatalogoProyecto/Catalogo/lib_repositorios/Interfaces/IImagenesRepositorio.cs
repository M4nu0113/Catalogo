﻿using lib_entidades.Modelos;
using System.Linq.Expressions;

namespace lib_repositorios.Interfaces
{
    public interface IImagenesRepositorio
    {
        void Configurar(string string_conexion);
        List<Imagenes> Listar();
        List<Imagenes> Buscar(Expression<Func<Imagenes, bool>> condiciones);
        Imagenes Guardar(Imagenes entidad);
        Imagenes Modificar(Imagenes entidad);
        Imagenes Borrar(Imagenes entidad);
    }
}
