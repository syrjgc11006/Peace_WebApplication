using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Peace.Data
{
    public class pl_article_albumsMap : PeaceEntityTypeConfiguration<pl_article_albums>
    {
        public pl_article_albumsMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.thumb_path)
                .HasMaxLength(255);

            this.Property(t => t.original_path)
                .HasMaxLength(255);

            this.Property(t => t.remark)
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
            this.ToTable("pl_article_albums");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.article_id).HasColumnName("article_id");
            this.Property(t => t.thumb_path).HasColumnName("thumb_path");
            this.Property(t => t.original_path).HasColumnName("original_path");
            this.Property(t => t.remark).HasColumnName("remark");

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
