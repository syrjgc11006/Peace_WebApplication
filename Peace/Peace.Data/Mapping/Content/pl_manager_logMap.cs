using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class pl_manager_logMap : PeaceEntityTypeConfiguration<pl_manager_log>
    {
        public pl_manager_logMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            this.Property(t => t.action_type)
                .HasMaxLength(100);

            this.Property(t => t.remark)
                .HasMaxLength(255);

            this.Property(t => t.user_ip)
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
            this.ToTable("pl_manager_log");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.action_type).HasColumnName("action_type");
            this.Property(t => t.remark).HasColumnName("remark");
            this.Property(t => t.user_ip).HasColumnName("user_ip");
            //¸¨ÖúÊôÐÔ
            this.Property(t => t.CreaterId).HasColumnName("CreaterId");
            this.Property(t => t.CreaterName).HasColumnName("CreaterName");
            this.Property(t => t.UpdaterId).HasColumnName("UpdaterId");
            this.Property(t => t.UpdaterName).HasColumnName("UpdaterName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");
        }
    }
}
