using FluentNHibernate.Mapping;

namespace Tuts.Models
{
    public class Group
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual IList<User> Users { get; set; }
    }

    public class GroupMapping : ClassMap<Group>
    {
        public GroupMapping()
        {
            Id(x => x.Id)
                .GeneratedBy.Native()
                .Column("id");
            Map(x => x.Name)
                .Column("name");
            HasManyToMany(x => x.Users);
            Table("groups");
        }
    }
}
