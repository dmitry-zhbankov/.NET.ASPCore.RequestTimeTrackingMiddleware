using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RequestTimeTrackingMiddleware.Models;

namespace RequestTimeTrackingMiddleware.DAL
{
    public class ProfileRepository:IProfileRepository
    {
        private List<Profile> profiles;
        public ProfileRepository()
        {
            profiles = new List<Profile>();
            profiles.Add(new Profile()
            {
                ProfileId=1,
                Name = "Name 1"
            });
            profiles.Add(new Profile()
            {
                ProfileId = 1,
                Name = "Name 2"
            });
            profiles.Add(new Profile()
            {
                ProfileId = 1,
                Name = "Name 3"
            });
        }
        public IEnumerable<Profile> Get(Expression<Func<Profile, bool>> filter)
        {
            var res= profiles.Where(filter.Compile());
            return res;
        }

        public Profile GetById(int id)
        {
            var profile = profiles.Find(x => x.ProfileId == id);
            return profile;
        }

        public void Create(Profile entity)
        {
            profiles.Add(entity);
        }

        public void Delete(int id)
        {
            var profile = GetById(id);
            profiles.Remove(profile);
        }

        public void Update(Profile entity)
        {
            var profile = GetById(entity.ProfileId);
            profile.Name = entity.Name;
        }

        public int Save()
        {
            throw new NotImplementedException();
        }
    }
}
