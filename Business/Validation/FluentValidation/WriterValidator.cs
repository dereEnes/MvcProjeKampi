using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validation.FluentValidation
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemessiniz");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Yazar SoyAdını Boş Geçemessiniz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Mail adresini Boş Geçemessiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanını  Boş Geçemessiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında kısmı Boş Geçilmez");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Yazar Adı 3 karakterden az olamaz!");
            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Yazar SoyAdını Boş Geçemessiniz");
            RuleFor(x => x.WriterMail).MinimumLength(3).WithMessage("Geçerli bir mail adresi giriniz!");
            RuleFor(x => x.WriterAbout).MinimumLength(5).WithMessage("Yazar Hakkında kısmı 5 karakterden uzun olmalı");
        }
    }
}
