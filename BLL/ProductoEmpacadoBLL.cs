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
    public class ProductoEmpacadoBLL
    {

        public Contexto _contexto;

        public ProductoEmpacadoBLL(Contexto contexto)
        {
            _contexto = contexto;
        }

        private ProductoBLL productoBLL { get; set; }

        public bool Existe(int productoEmpacadoId)
        {

            bool encontrado = false;

            try
            {
                encontrado = _contexto.ProductoEmpacado.Any(l => l.ProductoEmpacadoId == productoEmpacadoId);
            }
            catch (Exception)
            {
                throw;
            }
            return encontrado;
        }


        public bool Guardar(ProductoEmpacado productoEmpacado)
        {
            if (!Existe(productoEmpacado.ProductoEmpacadoId))
            {
                return Insertar(productoEmpacado);
            }
            else
            {
                return Modificar(productoEmpacado);
            }
        }

        private bool Insertar(ProductoEmpacado productoEmpacado)
        {
            bool paso = false;
            int idBuscada = 0;

            try
            {
                foreach (var item in productoEmpacado.ProductoEmpacadoDetalle)
                {
                    idBuscada = BuscarId(item.Descripcion);
                    Producto producto = _contexto.Producto.Find(idBuscada);

                    producto.Existencia -= item.Cantidad;
                    _contexto.Entry(producto).State = EntityState.Modified;
                    paso = _contexto.SaveChanges() > 0;
                }
                _contexto.ProductoEmpacado.Add(productoEmpacado);


                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        private int BuscarId(string nombreDescripcion)
        {
            Producto producto;
            ProductoEmpacado productoEmpacado;
            int IdRetornada = 0;

            foreach (var itemProducto in _contexto.Producto)
            {
                if (nombreDescripcion == itemProducto.Descripcion)
                {
                    IdRetornada = itemProducto.ProductoId;
                    break;
                }
            }
            return IdRetornada;
        }


        private bool Modificar(ProductoEmpacado productoEmpacado)
        {
            bool paso = false;
            try
            {


                _contexto.Database.ExecuteSqlRaw($"Delete FROM Concepto where ProductoEmpacadoId={productoEmpacado.ProductoEmpacadoId}");

                foreach (var Anterior in productoEmpacado.ProductoEmpacadoDetalle)
                {
                    _contexto.Entry(Anterior).State = EntityState.Added;
                }

                _contexto.Entry(productoEmpacado).State = EntityState.Modified;

                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public bool Eliminar(int productoEmpacadoId)
        {
            bool paso = false;
            int idBuscada = 0;
            try
            {
                var productoEmpacado = _contexto.ProductoEmpacado.Find(productoEmpacadoId);

                foreach (var item in productoEmpacado.ProductoEmpacadoDetalle)
                {
                    idBuscada = BuscarId(item.Descripcion);
                    Producto producto = _contexto.Producto.Find(idBuscada);

                    producto.Existencia += item.Cantidad;
                    _contexto.Entry(producto).State = EntityState.Modified;
                    paso = _contexto.SaveChanges() > 0;
                }


                if (productoEmpacado != null)
                {
                    _contexto.ProductoEmpacado.Remove(productoEmpacado);
                    paso = _contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public ProductoEmpacado Buscar(int productoEmpacadoId)
        {
            ProductoEmpacado productoEmpacado;

            try
            {
                productoEmpacado = _contexto.ProductoEmpacado.Include(x => x.ProductoEmpacadoDetalle).Where(p => p.ProductoEmpacadoId == productoEmpacadoId).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            return productoEmpacado;
        }

        public List<ProductoEmpacado> GetList(Expression<Func<ProductoEmpacado, bool>> criterio)
        {
            List<ProductoEmpacado> lista = new List<ProductoEmpacado>();

            try
            {
                lista = _contexto.ProductoEmpacado.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
