// Application/Commands/CreateGroup/CreateGroupValidator.cs
using FluentValidation;
using FantasyTradesGroupService.Application.Command.CreateGroup;

namespace FantasyTradesGroupService.Application.Command.CreateGroup
{
    public class CreateGroupValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.CreatorUserId).NotEmpty();
            RuleFor(x => x.CreatorUsername).NotEmpty();
        }
    }
}
