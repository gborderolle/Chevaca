﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Chevaca.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ChevacaDB : DbContext
    {
        public ChevacaDB()
            : base("name=ChevacaDB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aportes_energias> aportes_energias { get; set; }
        public virtual DbSet<aportes_proteinas> aportes_proteinas { get; set; }
        public virtual DbSet<bebederos> bebederos { get; set; }
        public virtual DbSet<camioneros> camioneros { get; set; }
        public virtual DbSet<clientes> clientes { get; set; }
        public virtual DbSet<comederos> comederos { get; set; }
        public virtual DbSet<dormideros> dormideros { get; set; }
        public virtual DbSet<escritorio_rurales> escritorio_rurales { get; set; }
        public virtual DbSet<estancia_campos> estancia_campos { get; set; }
        public virtual DbSet<estancia_campos_padrones> estancia_campos_padrones { get; set; }
        public virtual DbSet<estancia_campos_potreros> estancia_campos_potreros { get; set; }
        public virtual DbSet<estancias> estancias { get; set; }
        public virtual DbSet<frigorificos> frigorificos { get; set; }
        public virtual DbSet<historial_animales_concursos> historial_animales_concursos { get; set; }
        public virtual DbSet<historial_animales_enfermedades> historial_animales_enfermedades { get; set; }
        public virtual DbSet<historial_animales_ingestas> historial_animales_ingestas { get; set; }
        public virtual DbSet<historial_animales_pesadas> historial_animales_pesadas { get; set; }
        public virtual DbSet<historial_animales_vacunas> historial_animales_vacunas { get; set; }
        public virtual DbSet<ingeniero_agronomos> ingeniero_agronomos { get; set; }
        public virtual DbSet<lista_animales_categorias> lista_animales_categorias { get; set; }
        public virtual DbSet<lista_animales_razas> lista_animales_razas { get; set; }
        public virtual DbSet<lotes> lotes { get; set; }
        public virtual DbSet<ovejas> ovejas { get; set; }
        public virtual DbSet<ovejas_historial_concursos> ovejas_historial_concursos { get; set; }
        public virtual DbSet<ovejas_historial_enfermedades> ovejas_historial_enfermedades { get; set; }
        public virtual DbSet<ovejas_historial_ingestas> ovejas_historial_ingestas { get; set; }
        public virtual DbSet<ovejas_historial_pesadas> ovejas_historial_pesadas { get; set; }
        public virtual DbSet<ovejas_historial_vacunas> ovejas_historial_vacunas { get; set; }
        public virtual DbSet<proveedores> proveedores { get; set; }
        public virtual DbSet<raciones> raciones { get; set; }
        public virtual DbSet<raciones_prestaciones> raciones_prestaciones { get; set; }
        public virtual DbSet<raciones_proveedores> raciones_proveedores { get; set; }
        public virtual DbSet<trabajadores> trabajadores { get; set; }
        public virtual DbSet<trabajadores_perros> trabajadores_perros { get; set; }
        public virtual DbSet<usuarios> usuarios { get; set; }
        public virtual DbSet<vacas> vacas { get; set; }
        public virtual DbSet<vacas_historial_concursos> vacas_historial_concursos { get; set; }
        public virtual DbSet<vacas_historial_enfermedades> vacas_historial_enfermedades { get; set; }
        public virtual DbSet<vacas_historial_ingestas> vacas_historial_ingestas { get; set; }
        public virtual DbSet<vacas_historial_pesadas> vacas_historial_pesadas { get; set; }
        public virtual DbSet<vacas_historial_vacunas> vacas_historial_vacunas { get; set; }
        public virtual DbSet<veterinarias> veterinarias { get; set; }
        public virtual DbSet<logs> logs { get; set; }
        public virtual DbSet<logs_API> logs_API { get; set; }
    }
}