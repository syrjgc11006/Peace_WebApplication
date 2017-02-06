using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class pl_channel_fieldMap : PeaceEntityTypeConfiguration<pl_channel_field>
    {
        public pl_channel_fieldMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            //¸¨ÖúÊôÐÔ
            this.Property(t => t.CreaterId);

            this.Property(t => t.CreaterName)
                .HasMaxLength(100);

            this.Property(t => t.UpdaterId);

            this.Property(t => t.UpdaterName)
                .HasMaxLength(100);
            this.Property(t => t.CreateTime);

            this.Property(t => t.UpdateTime);

            // Properties
            // Table & Column Mappings
            this.ToTable("pl_channel_field");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.channel_id).HasColumnName("channel_id");
            this.Property(t => t.field_id).HasColumnName("field_id");

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
