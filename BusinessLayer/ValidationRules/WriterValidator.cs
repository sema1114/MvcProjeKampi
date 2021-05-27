﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidator :AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçmeyiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz ");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında boş geçemezsiniz ");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("LÜtfen en az 2 karakter girişi yapın ");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla giriş yapın");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("ÜNvan kısmını boş geçemezsiniz");

        }
    }
}
