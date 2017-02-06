using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class UserRoleMap : PeaceEntityTypeConfiguration<UserRole>
    {
        public UserRoleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.SystemName)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("UserRoles");
            this.Property(t => t.id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.FreeShipping).HasColumnName("FreeShipping");
            this.Property(t => t.TaxExempt).HasColumnName("TaxExempt");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.IsSystemRole).HasColumnName("IsSystemRole");
            this.Property(t => t.SystemName).HasColumnName("SystemName");
            this.Property(t => t.PurchasedWithProductId).HasColumnName("PurchasedWithProductId");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");

            // Relationships
            this.HasMany(t => t.Users1)
                .WithMany(t => t.UserRoles)
                .Map(m =>
                    {
                        m.ToTable("User_UserRole_Mapping");
                        m.MapLeftKey("UserRole_Id");
                        m.MapRightKey("User_Id");
                    });
        }
    }
}
