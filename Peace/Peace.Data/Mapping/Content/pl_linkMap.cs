using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Peace.Data
{
    public class pl_linkMap : PeaceEntityTypeConfiguration<pl_link>
    {
        public pl_linkMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.site_path)
                .HasMaxLength(100);

            this.Property(t => t.title)
                .HasMaxLength(255);

            this.Property(t => t.user_name)
                .HasMaxLength(50);

            this.Property(t => t.user_tel)
                .HasMaxLength(20);

            this.Property(t => t.email)
                .HasMaxLength(50);

            this.Property(t => t.site_url)
                .HasMaxLength(255);

            this.Property(t => t.img_url)
                .HasMaxLength(255);

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
            this.ToTable("pl_link");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.site_path).HasColumnName("site_path");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.user_name).HasColumnName("user_name");
            this.Property(t => t.user_tel).HasColumnName("user_tel");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.site_url).HasColumnName("site_url");
            this.Property(t => t.img_url).HasColumnName("img_url");
            this.Property(t => t.is_image).HasColumnName("is_image");
            this.Property(t => t.sort_id).HasColumnName("sort_id");
            this.Property(t => t.is_red).HasColumnName("is_red");
            this.Property(t => t.is_lock).HasColumnName("is_lock");

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
