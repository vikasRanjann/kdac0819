﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Car_Rental_Reservation_System.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class FinalProject_DBEntities : DbContext
    {
        public FinalProject_DBEntities()
            : base("name=FinalProject_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<T_ErrorLogs> T_ErrorLogs { get; set; }
        public DbSet<T_OTP_Details> T_OTP_Details { get; set; }
        public DbSet<T_PasswordHistoryLog> T_PasswordHistoryLog { get; set; }
        public DbSet<T_Roles> T_Roles { get; set; }
        public DbSet<T_Users> T_Users { get; set; }
        public DbSet<T_Address> T_Address { get; set; }
        public DbSet<T_Car> T_Car { get; set; }
        public DbSet<T_Customers> T_Customers { get; set; }
        public DbSet<T_Feedback> T_Feedback { get; set; }
        public DbSet<T_Rent> T_Rent { get; set; }
        public DbSet<T_Reservation> T_Reservation { get; set; }
    
        public virtual int proc_AddRole(string param1)
        {
            var param1Parameter = param1 != null ?
                new ObjectParameter("param1", param1) :
                new ObjectParameter("param1", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_AddRole", param1Parameter);
        }
    
        public virtual int proc_ModifyRole(Nullable<int> param1, string param2)
        {
            var param1Parameter = param1.HasValue ?
                new ObjectParameter("param1", param1) :
                new ObjectParameter("param1", typeof(int));
    
            var param2Parameter = param2 != null ?
                new ObjectParameter("param2", param2) :
                new ObjectParameter("param2", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_ModifyRole", param1Parameter, param2Parameter);
        }
    
        public virtual int proc_RemoveRole(Nullable<int> param1)
        {
            var param1Parameter = param1.HasValue ?
                new ObjectParameter("param1", param1) :
                new ObjectParameter("param1", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("proc_RemoveRole", param1Parameter);
        }
    }
}
