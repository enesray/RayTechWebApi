﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RayTech.DAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class RayTechDbEntities : DbContext
    {
        public RayTechDbEntities()
            : base("name=RayTechDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<WorkOrder> WorkOrder { get; set; }
        public virtual DbSet<WorkOrderActivities> WorkOrderActivities { get; set; }
        public virtual DbSet<users> users { get; set; }
    }
}