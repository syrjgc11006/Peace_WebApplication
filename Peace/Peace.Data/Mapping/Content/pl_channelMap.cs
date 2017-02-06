using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Peace.Data
{
    public class pl_channelMap : PeaceEntityTypeConfiguration<pl_channel>
    {
        public pl_channelMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(50);

            this.Property(t => t.title)
                .HasMaxLength(100);

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
            this.ToTable("pl_channel");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.site_id).HasColumnName("site_id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.is_albums).HasColumnName("is_albums");
            this.Property(t => t.is_attach).HasColumnName("is_attach");
            this.Property(t => t.is_spec).HasColumnName("is_spec");
            this.Property(t => t.sort_id).HasColumnName("sort_id");

            //¸¨ÖúÊôÐÔ
            this.Property(t => t.CreaterId).HasColumnName("CreaterId");
            this.Property(t => t.CreaterName).HasColumnName("CreaterName");
            this.Property(t => t.UpdaterId).HasColumnName("UpdaterId");
            this.Property(t => t.UpdaterName).HasColumnName("UpdaterName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");

            // Relationships
            this.HasOptional(t => t.pl_channel_site)
                .WithMany(t => t.pl_channel)
                .HasForeignKey(d => d.site_id);

        }
    }
}
