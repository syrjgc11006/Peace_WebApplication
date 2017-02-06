using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class PermissionRecordMap : PeaceEntityTypeConfiguration<PermissionRecord>
    {
        public PermissionRecordMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired();

            this.Property(t => t.SystemName)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Category)
                .IsRequired()
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("PermissionRecords");
            this.Property(t => t.id).HasColumnName("Id");
            this.Property(t => t.Name).HasColumnName("Name");
            this.Property(t => t.SystemName).HasColumnName("SystemName");
            this.Property(t => t.Category).HasColumnName("Category");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");

            // Relationships
            this.HasMany(t => t.UserRoles)
                .WithMany(t => t.PermissionRecords)
                .Map(m =>
                    {
                        m.ToTable("PermissionRecord_Role_Mapping");
                        m.MapLeftKey("PermissionRecord_Id");
                        m.MapRightKey("UserRole_Id");
                    });
        }
    }
}
