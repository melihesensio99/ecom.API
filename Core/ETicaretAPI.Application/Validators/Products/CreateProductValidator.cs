using ETicaretAPI.Application.Dtos.Products;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını giriniz.")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Lütfen ürün adını 5 ile 150 karakter arasında giriniz.");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün stok bilgisini giriniz.")
                .GreaterThanOrEqualTo(0)
                    .WithMessage("Lütfen ürün stok bilgisini 0 veya daha büyük giriniz.");

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün fiyatını giriniz.")
                .GreaterThan(0)
                    .WithMessage("Lütfen ürün fiyatını 0'dan büyük giriniz.");
        }
    }
}
