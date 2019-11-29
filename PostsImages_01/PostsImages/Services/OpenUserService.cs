using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PostsImages.Models;
using Prism.Mvvm;
using Xamarin.Forms;

namespace PostsImages.Services
{
    public class OpenUserService : BindableBase, IUserService
    {
        private string _userName;
        public string Username
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }

        public async Task<UserModel> GetUser(double latitude, double longitude)
        {

            
            var uri = $"https://jsonplaceholder.typicode.com/users?username=" + Username;
            var httpClient = new HttpClient();
            var result = await httpClient.GetStringAsync(uri);
            var data = JsonConvert.DeserializeObject<InfoUser>(result);

            var contact = new UserModel()
            {
                Id = data.id,
                Name = data.name,
                Email = data.email,
                Phone = data.phone,
                Street = data.address.street,
                City = data.address.city,

            };
            return contact;
        }
    }
}
