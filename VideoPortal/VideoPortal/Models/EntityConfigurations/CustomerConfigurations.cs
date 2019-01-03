using System.Data.Entity.ModelConfiguration;

namespace VideoPortal.Models.EntityConfigurations
{
    public class CustomerConfigurations : EntityTypeConfiguration<Customer>
    {
        public CustomerConfigurations()
        {
            ToTable("tbl_Customers");

            HasKey(c => c.Id);

            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);
        }
    }
}