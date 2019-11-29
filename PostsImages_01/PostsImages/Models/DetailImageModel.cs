using System;
namespace PostsImages.Models
{
    public class DetailImageModel
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string TitleAlbum { get; set; }
    }
}
