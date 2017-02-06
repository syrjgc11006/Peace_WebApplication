using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Peace.Data
{
    public class pl_navigationMap : PeaceEntityTypeConfiguration<pl_navigation>
    {
        public pl_navigationMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.nav_type)
                .HasMaxLength(50);

            this.Property(t => t.name)
                .HasMaxLength(50);

            this.Property(t => t.title)
                .HasMaxLength(100);

            this.Property(t => t.sub_title)
                .HasMaxLength(100);

            this.Property(t => t.icon_url)
                .HasMaxLength(255);

            this.Property(t => t.link_url)
                .HasMaxLength(255);

            this.Property(t => t.remark)
                .HasMaxLength(500);

            this.Property(t => t.action_type)
                .HasMaxLength(500);

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
            this.ToTable("pl_navigation");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.parent_id).HasColumnName("parent_id");
            this.Property(t => t.channel_id).HasColumnName("channel_id");
            this.Property(t => t.nav_type).HasColumnName("nav_type");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.sub_title).HasColumnName("sub_title");
            this.Property(t => t.icon_url).HasColumnName("icon_url");
            this.Property(t => t.link_url).HasColumnName("link_url");
            this.Property(t => t.sort_id).HasColumnName("sort_id");
            this.Property(t => t.is_lock).HasColumnName("is_lock");
            this.Property(t => t.remark).HasColumnName("remark");
            this.Property(t => t.action_type).HasColumnName("action_type");
            this.Property(t => t.is_sys).HasColumnName("is_sys");

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
