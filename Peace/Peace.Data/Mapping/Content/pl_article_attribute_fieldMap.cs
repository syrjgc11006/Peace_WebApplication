using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class pl_article_attribute_fieldMap : PeaceEntityTypeConfiguration<pl_article_attribute_field>
    {
        public pl_article_attribute_fieldMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(100);

            this.Property(t => t.title)
                .HasMaxLength(100);

            this.Property(t => t.control_type)
                .HasMaxLength(50);

            this.Property(t => t.data_type)
                .HasMaxLength(50);

            this.Property(t => t.valid_tip_msg)
                .HasMaxLength(255);

            this.Property(t => t.valid_error_msg)
                .HasMaxLength(255);

            this.Property(t => t.valid_pattern)
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
            this.ToTable("pl_article_attribute_field");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.control_type).HasColumnName("control_type");
            this.Property(t => t.data_type).HasColumnName("data_type");
            this.Property(t => t.data_length).HasColumnName("data_length");
            this.Property(t => t.data_place).HasColumnName("data_place");
            this.Property(t => t.item_option).HasColumnName("item_option");
            this.Property(t => t.default_value).HasColumnName("default_value");
            this.Property(t => t.is_required).HasColumnName("is_required");
            this.Property(t => t.is_password).HasColumnName("is_password");
            this.Property(t => t.is_html).HasColumnName("is_html");
            this.Property(t => t.editor_type).HasColumnName("editor_type");
            this.Property(t => t.valid_tip_msg).HasColumnName("valid_tip_msg");
            this.Property(t => t.valid_error_msg).HasColumnName("valid_error_msg");
            this.Property(t => t.valid_pattern).HasColumnName("valid_pattern");
            this.Property(t => t.sort_id).HasColumnName("sort_id");
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
