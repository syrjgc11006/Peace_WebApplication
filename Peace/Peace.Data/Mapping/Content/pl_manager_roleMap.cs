using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Peace.Data
{
    public class pl_manager_roleMap : PeaceEntityTypeConfiguration<pl_manager_role>
    {
        public pl_manager_roleMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.role_name)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("pl_manager_role");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.role_name).HasColumnName("role_name");
            this.Property(t => t.role_type).HasColumnName("role_type");
            this.Property(t => t.is_sys).HasColumnName("is_sys");
        }
    }
}
