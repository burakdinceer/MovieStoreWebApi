using FluentValidation;

namespace MovieStoreWebApi.Models.ModelsDirector.Request
{
    public class DirectorRequestVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class DirectorRequestVMValidator : AbstractValidator<DirectorRequestVM>
    {
        public DirectorRequestVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Ad Kısmını Doldurunuz...");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen Soyad Kısmını Doldurunuz...");
        }
    }
}
