using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public partial class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            Database.SetCommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
        }

        // 1. Add DBSet
        // public virtual DbSet<Demo> Demo { get; set; }


        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<SOS_Sales_Order_Scheduling_Result> SOS_Sales_Order_Scheduling_Result { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // 2. Setting Prop Model
            // builder.Entity<Demo>(entity =>
            // {
            //     entity.HasKey(x => x.Id);
            // });

            // ...... more

            builder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.service_id);

            entity.Property(e => e.service_name).IsUnicode(false);
        });

            
            builder.Entity<SOS_Sales_Order_Scheduling_Result>(entity =>
            {
                entity.HasKey(e => new { e.Demand_Order_Header, e.Demand_Order_Batch_Number });

                entity.Property(e => e.Article).IsFixedLength();

                entity.Property(e => e.Destination_Limit).IsUnicode(false);

                entity.Property(e => e.Model_NO).IsFixedLength();
            });

            // OnModelCreatingGeneratedProcedures(builder);
            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder builder);
    }
}