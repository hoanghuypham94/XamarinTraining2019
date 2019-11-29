using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PostsImages.Models;
using Refit;

namespace PostsImages.Services
{
    
    [Headers("Content-Type: application/json")]
    public interface IUserInfoApi
    {
        [Get("/users?username={username}")]
        Task<ObservableCollection<InfoUser>> GetMakeUps(string username);

        [Get("/users?id={id}")]
        Task<ObservableCollection<UserModel>> GetMakeUpsid(string id);

        [Post("/api/v1/addMakeUp")]
        Task<InfoUser> CreateMakeUp([Body] InfoUser makeUp, [Header("Authorization")] string token);
    }
}
