using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class pl_article_attribute_valueMap : PeaceEntityTypeConfiguration<pl_article_attribute_value>
    {
        public pl_article_attribute_valueMap()
        {
            // Primary Key
            this.HasKey(t => t.article_id);

            // Properties
            //this.Property(t => t.article_id)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.sub_title)
                .HasMaxLength(255);

            this.Property(t => t.source)
                .HasMaxLength(100);

            this.Property(t => t.author)
                .HasMaxLength(50);

            this.Property(t => t.goods_no)
                .HasMaxLength(100);

            this.Property(t => t.video_src)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("pl_article_attribute_value");
            this.Property(t => t.article_id).HasColumnName("article_id");
            this.Property(t => t.sub_title).HasColumnName("sub_title");
            this.Property(t => t.source).HasColumnName("source");
            this.Property(t => t.author).HasColumnName("author");
            this.Property(t => t.goods_no).HasColumnName("goods_no");
            this.Property(t => t.stock_quantity).HasColumnName("stock_quantity");
            this.Property(t => t.market_price).HasColumnName("market_price");
            this.Property(t => t.sell_price).HasColumnName("sell_price");
            this.Property(t => t.point).HasColumnName("point");
            this.Property(t => t.video_src).HasColumnName("video_src");

            // Relationships
            this.HasRequired(t => t.pl_article)
                .WithOptional(t => t.pl_article_attribute_value);

        }
    }
}
