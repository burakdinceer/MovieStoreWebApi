using FluentValidation;

namespace MovieStoreWebApi.ModelsCustomer.Request
{
    public class CustomerRequestVm
    {      
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class CustomerRequestVmValidator : AbstractValidator<CustomerRequestVm>
    {
        public CustomerRequestVmValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Lütfen İsim Kısmını Doldurunuz...");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen Soyisim Kısmını Doldurunuz...");
        }
    }
}
