using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class pl_manager_role_valueMap : PeaceEntityTypeConfiguration<pl_manager_role_value>
    {
        public pl_manager_role_valueMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nav_name)
                .HasMaxLength(100);

            this.Property(t => t.action_type)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("pl_manager_role_value");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.role_id).HasColumnName("role_id");
            this.Property(t => t.nav_name).HasColumnName("nav_name");
            this.Property(t => t.action_type).HasColumnName("action_type");

            // Relationships
            this.HasOptional(t => t.pl_manager_role)
                .WithMany(t => t.pl_manager_role_value)
                .HasForeignKey(d => d.role_id);

        }
    }
}
