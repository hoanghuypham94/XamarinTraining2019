using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using PostsImages.Models;
using Refit;

namespace PostsImages.Services
{
    [Headers("Content-Type: application/json")]
    public interface IPhotosApi
    {
        [Get("/photos?id")]
        Task<ObservableCollection<Photoss>> GetPhotosid();

        [Get("/photos?id={id}")]
        Task<ObservableCollection<DetailImageModel>> GetDetailPhotosid(string id);

        [Get("/users?id={id}")]
        Task<ObservableCollection<InfoUser>> GetMakeUpsid(string id);

        [Get("/albums?id={id}")]
        Task<ObservableCollection<Albums>> GetMakeUpsalbum(string id);

        //[Post("/api/v1/addMakeUp")]
        //Task<Photos> CreateMakeUp([Body] Photos makeUp, [Header("Authorization")] string token);
    }
}
