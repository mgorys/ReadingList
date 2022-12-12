using FluentValidation;
using ReadingList.Models.Dto;
using ReadingList.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingList.Api.Validators
{
    public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        public CreateBookDtoValidator(ReadingListDbContext dbContext)
        {
            RuleFor(x => x.Name)
                .Custom((value, context) =>
                {
                    var bookNameInUse = dbContext.Books.Any(u => u.Name == value);
                    if (bookNameInUse)
                    {
                        context.AddFailure("Name", "That book name is in use");
                    }
                });
        }
    }
}
