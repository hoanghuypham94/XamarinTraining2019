using System;
using System.Threading.Tasks;
using PostsImages.Models;
using Prism.Mvvm;

namespace PostsImages.Services
{
    public interface IUserService 
    {
        Task<UserModel> GetUser(double latitude, double longitude);
    }
}
