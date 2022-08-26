using System.Linq;

namespace RayTech.DAL
{
    public class UsersDal
    {
        RayTechDbEntities db = new RayTechDbEntities();
        public users GetUserByApiKey(string apiKey)
        {
            return db.users.FirstOrDefault(x => x.UserKey.ToString() == apiKey);
        }

        public users GetUsersByName(string name)
        {
            return db.users.FirstOrDefault(x => x.Name == name);
        }
    }
}
