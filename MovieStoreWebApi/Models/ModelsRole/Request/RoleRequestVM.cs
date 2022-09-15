using FluentValidation;

namespace MovieStoreWebApi.ModelsRole.Request
{
    public class RoleRequestVM
    {

        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class RoleRequestVMValidator : AbstractValidator<RoleRequestVM>
    {
        public RoleRequestVMValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim Kısmını Doldurunuz...");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad Kısmını Doldurunuz...");
        }
    }
}
