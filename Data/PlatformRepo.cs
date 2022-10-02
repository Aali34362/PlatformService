using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatFormRepo : IPlatformRepo
    {
        private readonly AppDbContext context;
        public PlatFormRepo(AppDbContext context){
            this.context = context;
        }

        public void CreatePlatform(Platform platform)
        {
            if(platform==null)
            {
                throw new ArgumentNullException(nameof(platform));
            }
            else{
                context.Platforms.Add(platform);
            }
        }

        public IEnumerable<Platform> GetAllPlatform()
        {
            return context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return context.Platforms.FirstOrDefault(x=>x.Id == id);
        }

        public bool SaveChanges()
        {
            return (context.SaveChanges() >= 0);
        }
    }
}