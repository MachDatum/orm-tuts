using FluentNHibernate.Mapping;

namespace Tuts.Models
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual Address Address { get; set; }
        public virtual IList<Group> Groups { get; set; }
        public virtual bool? IsDeleted { get; set; }
    }

    public class UserMapping : ClassMap<User>
    {
        public UserMapping()
        {
            Id(x => x.Id)
                .GeneratedBy.Native()
                .Column("id");
            Map(x => x.Name)
                .Column("name");
            References(x => x.Address);
            HasManyToMany(x => x.Groups);
            Map(x => x.IsDeleted)
                .Column("is_deleted");
            Table("users");
        }
    }
}
