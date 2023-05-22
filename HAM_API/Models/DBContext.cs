using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace HAM_API.Models
{
    public partial class DBContext : DbContext
    {
        public DBContext()
            : base("name=DBContext")
        {
        }

        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<tbl_booking> tbl_booking { get; set; }
        public virtual DbSet<tbl_department> tbl_department { get; set; }
        public virtual DbSet<tbl_doctor> tbl_doctor { get; set; }
        public virtual DbSet<tbl_patient> tbl_patient { get; set; }
        public virtual DbSet<tbl_prescription> tbl_prescription { get; set; }
        public virtual DbSet<tbl_role> tbl_role { get; set; }
        public virtual DbSet<tbl_service> tbl_service { get; set; }
        public virtual DbSet<tbl_user> tbl_user { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_booking>()
                .Property(e => e.price)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_department>()
                .HasMany(e => e.tbl_doctor)
                .WithOptional(e => e.tbl_department)
                .HasForeignKey(e => e.dep_id);

            modelBuilder.Entity<tbl_doctor>()
                .HasMany(e => e.tbl_booking)
                .WithOptional(e => e.tbl_doctor)
                .HasForeignKey(e => e.dc_id);

            modelBuilder.Entity<tbl_doctor>()
                .HasMany(e => e.tbl_prescription)
                .WithOptional(e => e.tbl_doctor)
                .HasForeignKey(e => e.dc_id);

            modelBuilder.Entity<tbl_patient>()
                .Property(e => e.gender)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<tbl_patient>()
                .HasMany(e => e.tbl_booking)
                .WithOptional(e => e.tbl_patient)
                .HasForeignKey(e => e.pt_id);

            modelBuilder.Entity<tbl_role>()
                .Property(e => e.role_name)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_role>()
                .HasMany(e => e.tbl_user)
                .WithOptional(e => e.tbl_role)
                .HasForeignKey(e => e.role_id);

            modelBuilder.Entity<tbl_service>()
                .Property(e => e.price)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_service>()
                .HasMany(e => e.tbl_booking)
                .WithOptional(e => e.tbl_service)
                .HasForeignKey(e => e.sv_id);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.pw)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.p_number)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .Property(e => e.img)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_booking)
                .WithOptional(e => e.tbl_user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_doctor)
                .WithOptional(e => e.tbl_user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_patient)
                .WithOptional(e => e.tbl_user)
                .HasForeignKey(e => e.user_id);

            modelBuilder.Entity<tbl_user>()
                .HasMany(e => e.tbl_prescription)
                .WithOptional(e => e.tbl_user)
                .HasForeignKey(e => e.user_id);
        }
    }
}