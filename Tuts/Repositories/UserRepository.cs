using Tuts.Models;

namespace Tuts.Repositories
{
    public class UserRepository : Repository<User>
    {
        public UserRepository(NHibernate.ISession session) : base(session)
        {

        }

        public new IEnumerable<User> GetAll()
        {
            var data = Session.Query<User>()
                .Where(u => u.IsDeleted == null || u.IsDeleted == false);
            return data;
        }

        public new void Delete(User user)
        {
            user.IsDeleted = true;
            Session.Update(user);
            Session.Flush();
        }
    }
}
