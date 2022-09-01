using System;

namespace MovieStoreWebApi.MovieModels.Request
{
    public class AddRequestVM
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
    }
}
