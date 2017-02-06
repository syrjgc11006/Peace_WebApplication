using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class pl_channel_siteMap : PeaceEntityTypeConfiguration<pl_channel_site>
    {
        public pl_channel_siteMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.title)
                .HasMaxLength(100);

            this.Property(t => t.build_path)
                .HasMaxLength(100);

            this.Property(t => t.templet_path)
                .HasMaxLength(100);

            this.Property(t => t.domain)
                .HasMaxLength(255);

            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.logo)
                .HasMaxLength(255);

            this.Property(t => t.company)
                .HasMaxLength(255);

            this.Property(t => t.address)
                .HasMaxLength(255);

            this.Property(t => t.tel)
                .HasMaxLength(30);

            this.Property(t => t.fax)
                .HasMaxLength(30);

            this.Property(t => t.email)
                .HasMaxLength(50);

            this.Property(t => t.crod)
                .HasMaxLength(100);

            this.Property(t => t.seo_title)
                .HasMaxLength(255);

            this.Property(t => t.seo_keyword)
                .HasMaxLength(255);

            this.Property(t => t.seo_description)
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
            this.ToTable("pl_channel_site");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.build_path).HasColumnName("build_path");
            this.Property(t => t.templet_path).HasColumnName("templet_path");
            this.Property(t => t.domain).HasColumnName("domain");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.logo).HasColumnName("logo");
            this.Property(t => t.company).HasColumnName("company");
            this.Property(t => t.address).HasColumnName("address");
            this.Property(t => t.tel).HasColumnName("tel");
            this.Property(t => t.fax).HasColumnName("fax");
            this.Property(t => t.email).HasColumnName("email");
            this.Property(t => t.crod).HasColumnName("crod");
            this.Property(t => t.copyright).HasColumnName("copyright");
            this.Property(t => t.seo_title).HasColumnName("seo_title");
            this.Property(t => t.seo_keyword).HasColumnName("seo_keyword");
            this.Property(t => t.seo_description).HasColumnName("seo_description");
            this.Property(t => t.is_mobile).HasColumnName("is_mobile");
            this.Property(t => t.is_default).HasColumnName("is_default");
            this.Property(t => t.sort_id).HasColumnName("sort_id");

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
