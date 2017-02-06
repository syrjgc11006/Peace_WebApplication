using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class pl_managerMap : PeaceEntityTypeConfiguration<pl_manager>
    {
        public pl_managerMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.user_name)
                .HasMaxLength(100);

            this.Property(t => t.password)
                .HasMaxLength(100);

            this.Property(t => t.salt)
                .HasMaxLength(20);

            this.Property(t => t.real_name)
                .HasMaxLength(50);

            this.Property(t => t.telephone)
                .HasMaxLength(30);

            this.Property(t => t.email)
                .HasMaxLength(30);

            //¸¨ÖúÊôÐÔ
            this.Property(t => t.CreaterId);

            this.Property(t => t.CreaterName)
                .HasMaxLength(100);

            this.Property(t => t.UpdaterId);

            this.Property(t => t.UpdaterName)
                .HasMaxLength(100);
            this.Property(t => t.CreateTime);

            this.Property(t => t.UpdateTime);

            // Table & Column Mappings
            this.ToTable("pl_manager");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.role_id).HasColumnName("role_id");
            this.Property(t => t.role_type).HasColumnName("role_type");
            this.Property(t => t.user_name).HasColumnName("user_name");
            this.Property(t => t.password).HasColumnName("password");
            this.Property(t => t.salt).HasColumnName("salt");
            this.Property(t => t.real_name).HasColumnName("real_name");
            this.Property(t => t.telephone).HasColumnName("telephone");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.is_lock).HasColumnName("is_lock");
            //¸¨ÖúÊôÐÔ
            this.Property(t => t.CreaterId).HasColumnName("CreaterId");
            this.Property(t => t.CreaterName).HasColumnName("CreaterName");
            this.Property(t => t.UpdaterId).HasColumnName("UpdaterId");
            this.Property(t => t.UpdaterName).HasColumnName("UpdaterName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");

            // Relationships
            this.HasOptional(t => t.pl_manager_role)
                .WithMany(t => t.pl_manager)
                .HasForeignKey(d => d.role_id);

        }
    }
}
