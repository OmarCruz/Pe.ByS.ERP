using Pe.ByS.ERP.Cross.Core.Base;
using Pe.ByS.ERP.Infraestructura.Core.Base;
using Pe.ByS.ERP.Infraestructura.Core.Context;
using Pe.ByS.ERP.Infraestructura.Model.Base;
using System;
using System.Reflection;

namespace Pe.ByS.ERP.Infraestructura.Repository.Base
{
    /// <summary>
    /// Repository base for all wite model
    /// </summary>
    public abstract class ComandRepository<T> : IComandRepository<T>
         where T : Entity
    {
        public IDbContextProvider dataBaseProvider { get; set; }
        public IEntornoActualAplicacion entornoActualAplicacion { get; set; }

        public void Insertar(T entidad)
        {
            entidad.EsEliminado = false;
            entidad.UsuarioCreacion = entornoActualAplicacion != null ? entornoActualAplicacion.UsuarioSession : entidad.UsuarioCreacion;
            entidad.FechaCreacion = DateTime.Now;
            entidad.TerminalCreacion = entornoActualAplicacion != null ? entornoActualAplicacion.Terminal : entidad.TerminalCreacion;

            this.dataBaseProvider.DbSet<T>().Add(entidad);
            RegistrarAuditoria(entidad);
        }

        public void Editar(T entidad)
        {
            entidad.UsuarioModificacion = entornoActualAplicacion != null ? entornoActualAplicacion.UsuarioSession : entidad.UsuarioModificacion;
            entidad.FechaModificacion = DateTime.Now;
            entidad.TerminalModificacion = entornoActualAplicacion != null ? entornoActualAplicacion.Terminal : entidad.TerminalModificacion;

            this.dataBaseProvider.Modified(entidad);
            RegistrarAuditoria(entidad);
        }

        public void Eliminar(params object[] llaves)
        {
            var entidadEliminar = this.GetById(llaves);
            entidadEliminar.EsEliminado = true;
            Editar(entidadEliminar);
        }

        public T GetById(params object[] id)
        {
            return this.dataBaseProvider.DbSet<T>().Find(id);
        }

        public int GuardarCambios()
        {
            return this.dataBaseProvider.Persist();
        }

        public void RegistrarAuditoria(T entity)
        {

            var hasTraceAudit = typeof(T).GetCustomAttribute<TraceAuditAttribute>();
            if (hasTraceAudit != null)
            {
                using (IDbContextProvider dataBaseProviderAudit = new BySAuditDbContextProvider())
                {
                    dataBaseProviderAudit.DbSet<T>().Add(entity);
                    dataBaseProviderAudit.Persist();
                }
            }
        }

        public void Dispose()
        {
            if (this.dataBaseProvider != null)
            {
                this.dataBaseProvider.Dispose();
            }
        }
    }
}
