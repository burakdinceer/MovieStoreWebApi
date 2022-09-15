using FluentValidation;
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
        public string DirectorNames { get; set; }
        public string DirectorSurnames { get; set; }
        public string RoleNames { get; set; }
        public string RoleSurnames { get; set; }



    }

    
}
