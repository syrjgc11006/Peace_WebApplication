using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class pl_article_categoryMap : PeaceEntityTypeConfiguration<pl_article_category>
    {
        public pl_article_categoryMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.title)
                .HasMaxLength(100);

            this.Property(t => t.call_index)
                .HasMaxLength(50);

            this.Property(t => t.class_list)
                .HasMaxLength(500);

            this.Property(t => t.link_url)
                .HasMaxLength(255);

            this.Property(t => t.img_url)
                .HasMaxLength(255);

            this.Property(t => t.seo_title)
                .HasMaxLength(255);

            this.Property(t => t.seo_keywords)
                .HasMaxLength(255);

            this.Property(t => t.seo_description)
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
            this.ToTable("pl_article_category");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.channel_id).HasColumnName("channel_id");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.call_index).HasColumnName("call_index");
            this.Property(t => t.parent_id).HasColumnName("parent_id");
            this.Property(t => t.class_list).HasColumnName("class_list");
            this.Property(t => t.class_layer).HasColumnName("class_layer");
            this.Property(t => t.sort_id).HasColumnName("sort_id");
            this.Property(t => t.link_url).HasColumnName("link_url");
            this.Property(t => t.img_url).HasColumnName("img_url");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.seo_title).HasColumnName("seo_title");
            this.Property(t => t.seo_keywords).HasColumnName("seo_keywords");
            this.Property(t => t.seo_description).HasColumnName("seo_description");

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
