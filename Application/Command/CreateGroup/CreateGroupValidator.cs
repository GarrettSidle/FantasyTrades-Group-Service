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
            RuleFor(x => x.DraftDate)
                .NotEmpty()
                .Must(date => date > DateTime.UtcNow).WithMessage("DraftDate must be in the future.");
            RuleFor(x => x.EndDate)
                .NotEmpty()
                .Must((cmd, endDate) => endDate > cmd.DraftDate).WithMessage("EndDate must be after DraftDate.");
        }
    }
}
