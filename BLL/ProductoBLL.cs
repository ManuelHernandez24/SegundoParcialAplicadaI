using System;
using ExamenBlazor.Entidades;
using ExamenBlazor.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace ExamenBlazor.BLL
{
    public class ProductoBLL
    {

        public Contexto _contexto;

        public ProductoBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        public bool Existe(int productoId)
        {

            bool encontrado = false;

            try
            {
                encontrado = _contexto.Producto.Any(l => l.ProductoId == productoId);
            }
            catch (Exception)
            {
                throw;
            }
            return encontrado;
        }

        public bool ExisteDescripcion(string descripcion)
        {
            bool encontrado = false;

            try
            {
                encontrado = _contexto.Producto.Any(l => l.Descripcion.ToLower() == descripcion.ToLower());
            }
            catch (Exception)
            {
                throw;
            }
            return encontrado;
        }

        public bool Guardar(Producto producto)
        {
            if (!Existe(producto.ProductoId))
            {
                return Insertar(producto);
            }
            else
            {
                return Modificar(producto);
            }
        }

        private bool Insertar(Producto producto)
        {
            bool paso = false;

            try
            {
                producto.ValorInventario = producto.Costo * producto.Existencia;
                _contexto.Producto.Add(producto);
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private bool Modificar(Producto producto)
        {
            bool paso = false;
            try
            {
                _contexto.Database.ExecuteSqlRaw($"DELETE FROM ProductoDetalle WHERE ProductoId={producto.ProductoId}");

                foreach (var Anterior in producto.ProductoDetalle)
                {
                    _contexto.Entry(Anterior).State = EntityState.Added;
                }

                _contexto.Entry(producto).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Eliminar(int productoId)
        {
            bool paso = false;
            try
            {
                var producto = _contexto.Producto.Find(productoId);
                if (producto != null)
                {
                    _contexto.Producto.Remove(producto);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _contexto.Dispose();
            }
            return paso;
        }

        public Producto Buscar(int productoId)
        {
            Producto producto;

            try
            {
                producto = _contexto.Producto.Include(x => x.ProductoDetalle).Where(p => p.ProductoId == productoId).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return producto;
        }

        public List<Producto> GetList(Expression<Func<Producto, bool>> criterio)
        {
            List<Producto> lista = new List<Producto>();

            try
            {
                lista = _contexto.Producto.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
