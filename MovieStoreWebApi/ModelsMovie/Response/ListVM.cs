using MovieStoreWebApi.Entites;
using System;

namespace MovieStoreWebApi.MovieModels.Response
{
    public class ListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public int Price { get; set; }
        public bool Active { get; set; } = true;


    }
}
