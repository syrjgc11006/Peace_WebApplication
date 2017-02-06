using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class pl_article_attachMap : PeaceEntityTypeConfiguration<pl_article_attach>
    {
        public pl_article_attachMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.file_name)
                .HasMaxLength(255);

            this.Property(t => t.file_path)
                .HasMaxLength(255);

            this.Property(t => t.file_ext)
                .HasMaxLength(20);

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
            this.ToTable("pl_article_attach");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.article_id).HasColumnName("article_id");
            this.Property(t => t.file_name).HasColumnName("file_name");
            this.Property(t => t.file_path).HasColumnName("file_path");
            this.Property(t => t.file_size).HasColumnName("file_size");
            this.Property(t => t.file_ext).HasColumnName("file_ext");
            this.Property(t => t.down_num).HasColumnName("down_num");
            this.Property(t => t.point).HasColumnName("point");

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
