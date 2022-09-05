namespace MovieStoreWebApi.ModelsCustomer.Response
{
    public class CustomerResponseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool Active { get; set; } = true;
    }
}
