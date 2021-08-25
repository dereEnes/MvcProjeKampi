using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemessiniz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("açıklamayı Boş Geçemessiniz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 3 karakter uzunluğunda olmalıdır.");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("En fazla 50 karakter uzunluğunda olmalıdır.");
            RuleFor(x => x.CategoryDescription).MaximumLength(200).WithMessage("En fazla 20 karakter uzunluğunda olmalıdır.");
            RuleFor(x => x.CategoryDescription).MinimumLength(3).WithMessage("En az 5 karakter uzunluğunda olmalıdır.");

        }
    }
}
