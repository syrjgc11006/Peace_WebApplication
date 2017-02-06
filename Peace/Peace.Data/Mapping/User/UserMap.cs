using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class UserMap : PeaceEntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Username)
                .HasMaxLength(100);

            this.Property(t => t.Email)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Users");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.UserGuid).HasColumnName("UserGuid");
            this.Property(t => t.Username).HasColumnName("Username");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.PasswordFormatId).HasColumnName("PasswordFormatId");
            this.Property(t => t.PasswordSalt).HasColumnName("PasswordSalt");
            this.Property(t => t.RealName).HasColumnName("RealName");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Active).HasColumnName("Active");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.IsSystemAccount).HasColumnName("IsSystemAccount");
            this.Property(t => t.SystemName).HasColumnName("SystemName");
            this.Property(t => t.LastIpAddress).HasColumnName("LastIpAddress");
            this.Property(t => t.LastLoginDateUtc).HasColumnName("LastLoginDateUtc");
            this.Property(t => t.LastActivityDateUtc).HasColumnName("LastActivityDateUtc");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.UserRole_Id).HasColumnName("UserRole_Id");
            this.Property(t => t.ImgUrl).HasColumnName("ImgUrl");

            //¸¨ÖúÊôÐÔ
            this.Property(t => t.CreaterId).HasColumnName("CreaterId");
            this.Property(t => t.CreaterName).HasColumnName("CreaterName");
            this.Property(t => t.UpdaterId).HasColumnName("UpdaterId");
            this.Property(t => t.UpdaterName).HasColumnName("UpdaterName");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.UpdateTime).HasColumnName("UpdateTime");

            // Relationships
            this.HasOptional(t => t.UserRole)
                .WithMany(t => t.Users)
                .HasForeignKey(d => d.UserRole_Id);

        }
    }
}
