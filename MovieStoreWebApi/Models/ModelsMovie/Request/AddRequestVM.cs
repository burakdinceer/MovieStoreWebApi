using FluentValidation;
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

    public class AddRequestVMValidator : AbstractValidator<AddRequestVM>
    {
        public AddRequestVMValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Lütfen Ad Kısmını Doldurunuz...");
            RuleFor(x => x.ReleaseDate).NotEmpty().WithMessage("Lütfen Tarih Kısmını Doldurunuz...");
            RuleFor(x => x.Genre).NotEmpty().WithMessage("Lütfen Tür Kısmını Doldurunuz...");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Lütfen Fiyat Kısmını Doldurunuz...");
        }
    }
}
