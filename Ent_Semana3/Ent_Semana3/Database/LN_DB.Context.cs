﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ent_Semana3.Database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class LN_DBEntities1 : DbContext
    {
        public LN_DBEntities1()
            : base("name=LN_DBEntities1")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<T_TIPOCAMBIO> T_TIPOCAMBIO { get; set; }
    
        public virtual int InsertTipoCambio(string datos, Nullable<int> indicador)
        {
            var datosParameter = datos != null ?
                new ObjectParameter("Datos", datos) :
                new ObjectParameter("Datos", typeof(string));
    
            var indicadorParameter = indicador.HasValue ?
                new ObjectParameter("Indicador", indicador) :
                new ObjectParameter("Indicador", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertTipoCambio", datosParameter, indicadorParameter);
        }
    
        public virtual ObjectResult<get_CV_on_15Day_byMonth_Result> get_CV_on_15Day_byMonth()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_CV_on_15Day_byMonth_Result>("get_CV_on_15Day_byMonth");
        }
    
        public virtual ObjectResult<get_CV_on_1Day_byMonth_Result> get_CV_on_1Day_byMonth()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_CV_on_1Day_byMonth_Result>("get_CV_on_1Day_byMonth");
        }
    
        public virtual ObjectResult<get_CV_on_LastDay_byMonth_Result> get_CV_on_LastDay_byMonth()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_CV_on_LastDay_byMonth_Result>("get_CV_on_LastDay_byMonth");
        }
    }
}
