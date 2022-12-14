using Newtonsoft.Json;
using Plenti.Interfaces;
using Plenti.Model;

namespace Plenti.Implements
{
    public class UserLoader : IUserLoader
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UserLoader(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<User> GetAllUser()
        {
            return JsonConvert.DeserializeObject<IEnumerable<User>>(File.ReadAllText(_webHostEnvironment.ContentRootPath + @"/DataSample.json"));
        }
    }
}
