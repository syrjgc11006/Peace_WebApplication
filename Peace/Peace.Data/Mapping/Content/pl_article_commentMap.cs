using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Peace.Data
{
    public class pl_article_commentMap : PeaceEntityTypeConfiguration<pl_article_comment>
    {
        public pl_article_commentMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.user_name)
                .HasMaxLength(100);

            this.Property(t => t.user_ip)
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
            this.ToTable("pl_article_comment");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.channel_id).HasColumnName("channel_id");
            this.Property(t => t.article_id).HasColumnName("article_id");
            this.Property(t => t.parent_id).HasColumnName("parent_id");
            this.Property(t => t.user_id).HasColumnName("user_id");
            this.Property(t => t.user_name).HasColumnName("user_name");
            this.Property(t => t.user_ip).HasColumnName("user_ip");
            this.Property(t => t.content).HasColumnName("content");
            this.Property(t => t.is_lock).HasColumnName("is_lock");
            this.Property(t => t.add_time).HasColumnName("add_time");
            this.Property(t => t.is_reply).HasColumnName("is_reply");
            this.Property(t => t.reply_content).HasColumnName("reply_content");
            this.Property(t => t.reply_time).HasColumnName("reply_time");

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
