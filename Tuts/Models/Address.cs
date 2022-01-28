using FluentNHibernate.Mapping;

namespace Tuts.Models
{
    public class Address
    {
        public virtual int Id { get; set; }
        public virtual string City { get; set; }
        public virtual IList<User> Users { get; set; }
    }

    public class AddressMapping : ClassMap<Address>
    {
        public AddressMapping()
        {
            Id(x => x.Id)
                .GeneratedBy.Native()
                .Column("id");
            Map(x => x.City)
                .Column("city");
            HasMany(x => x.Users);
            Table("addresses");
        }
    }
}
