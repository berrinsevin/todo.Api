using todo.Api.Dtos;
using FluentValidation;

namespace todo.Api.Helpers
{
    public class PostRequestValidator : AbstractValidator<RequestPostDto>
    {
        public PostRequestValidator()
        {
            RuleFor(post => post.StatusCode).NotEmpty();
            RuleFor(post => post.ChannelCode).NotEmpty();
            RuleFor(post => post.ExpireDate).GreaterThan(DateTime.Now);
        }
    }
}