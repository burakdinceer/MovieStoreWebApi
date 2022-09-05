namespace MovieStoreWebApi.Models.ModelsDirector.Response
{
    public class DirectorResponseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Active { get; set; } = true;
    }
}
