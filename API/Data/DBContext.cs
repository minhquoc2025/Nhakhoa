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


        public virtual DbSet<SOS_Article_Group_Priority_Setting> SOS_Article_Group_Priority_Setting { get; set; }
        public virtual DbSet<SOS_Article_Group_Setting> SOS_Article_Group_Setting { get; set; }
        public virtual DbSet<SOS_Article_Setting> SOS_Article_Setting { get; set; }
        public virtual DbSet<SOS_Article_Setting_Temp> SOS_Article_Setting_Temp { get; set; }
        public virtual DbSet<SOS_Class_Code_Setting> SOS_Class_Code_Setting { get; set; }
        public virtual DbSet<SOS_Destination_Setting> SOS_Destination_Setting { get; set; }
        public virtual DbSet<SOS_Order_Type_Setting> SOS_Order_Type_Setting { get; set; }
        public virtual DbSet<SOS_Sales_Order_Scheduling_Result> SOS_Sales_Order_Scheduling_Result { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // 2. Setting Prop Model
            // builder.Entity<Demo>(entity =>
            // {
            //     entity.HasKey(x => x.Id);
            // });

            // ...... more

            builder.Entity<SOS_Article_Group_Priority_Setting>(entity =>
        {
            entity.HasKey(e => e.Article_Group_Priority);

            entity.Property(e => e.Article_Group_Priority).IsUnicode(false);
        });

            builder.Entity<SOS_Article_Group_Setting>(entity =>
            {
                entity.HasKey(e => e.Article_Group_ID);

                entity.Property(e => e.Article_Group_Priority).IsUnicode(false);
            });

            builder.Entity<SOS_Article_Setting>(entity =>
            {
                entity.HasKey(e => new { e.Article_Group_ID, e.Article });

                entity.Property(e => e.Dev_Type).IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Model)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Season)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Special_Article)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            builder.Entity<SOS_Article_Setting_Temp>(entity =>
                {
                    entity.HasKey(e => new { e.Article_Group_ID, e.Article });

                    entity.Property(e => e.Dev_Type).IsUnicode(false);

                    entity.Property(e => e.Gender)
                        .IsUnicode(false)
                        .IsFixedLength();

                    entity.Property(e => e.Model)
                        .IsUnicode(false)
                        .IsFixedLength();

                    entity.Property(e => e.Season)
                        .IsUnicode(false)
                        .IsFixedLength();

                    entity.Property(e => e.Special_Article)
                        .IsUnicode(false)
                        .IsFixedLength();
                });

            builder.Entity<SOS_Class_Code_Setting>(entity =>
            {
                entity.HasKey(e => e.Class_Code);

                entity.Property(e => e.Class_Code)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            builder.Entity<SOS_Destination_Setting>(entity =>
            {
                entity.HasKey(e => e.Destination);

                entity.Property(e => e.Destination_Limit).IsUnicode(false);
            });

            builder.Entity<SOS_Order_Type_Setting>(entity =>
            {
                entity.HasKey(e => e.Order_Type);

                entity.Property(e => e.Order_Type)
                    .IsUnicode(false)
                    .IsFixedLength();
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