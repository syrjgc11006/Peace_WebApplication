using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Peace.Data
{
    public class AddressMap : PeaceEntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Addresses");
            this.Property(t => t.id).HasColumnName("Id");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.Company).HasColumnName("Company");
            this.Property(t => t.CountryId).HasColumnName("CountryId");
            this.Property(t => t.StateProvinceId).HasColumnName("StateProvinceId");
            this.Property(t => t.City).HasColumnName("City");
            this.Property(t => t.Address1).HasColumnName("Address1");
            this.Property(t => t.Address2).HasColumnName("Address2");
            this.Property(t => t.ZipPostalCode).HasColumnName("ZipPostalCode");
            this.Property(t => t.PhoneNumber).HasColumnName("PhoneNumber");
            this.Property(t => t.FaxNumber).HasColumnName("FaxNumber");
            this.Property(t => t.CustomAttributes).HasColumnName("CustomAttributes");
            this.Property(t => t.CreatedOnUtc).HasColumnName("CreatedOnUtc");
            this.Property(t => t.CreateTime).HasColumnName("CreateTime");
            this.Property(t => t.ModifyTime).HasColumnName("ModifyTime");
            this.Property(t => t.User_Id).HasColumnName("User_Id");

            // Relationships
            this.HasOptional(t => t.User)
                .WithMany(t => t.Addresses)
                .HasForeignKey(d => d.User_Id);

        }
    }
}
