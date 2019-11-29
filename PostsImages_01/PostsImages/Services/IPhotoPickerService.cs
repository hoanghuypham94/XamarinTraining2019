using System;
using System.IO;
using System.Threading.Tasks;

namespace PostsImages.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
