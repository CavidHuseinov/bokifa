using Bokifa.Domain.DTOs.HeadBanner;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bokifa.Application.Validators.HeadBanner
{
    public class UpdateHeadBannerValidator:AbstractValidator<UpdateHeadBannerDto>
    {
        public UpdateHeadBannerValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content cannot be empty");
        }
    }
}
