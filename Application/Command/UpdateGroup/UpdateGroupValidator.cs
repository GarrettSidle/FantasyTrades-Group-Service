using FluentValidation;

namespace FantasyTradesGroupService.Application.Command.UpdateGroup;

public class UpdateGroupValidator : AbstractValidator<UpdateGroupCommand>
{
    public UpdateGroupValidator()
    {
        RuleFor(x => x.GroupId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
        RuleFor(x => x.DraftDate)
            .NotEmpty()
            .Must(date => date > DateTime.UtcNow).WithMessage("DraftDate must be in the future.");
        RuleFor(x => x.EndDate)
            .NotEmpty()
            .Must((cmd, endDate) => endDate > cmd.DraftDate).WithMessage("EndDate must be after DraftDate.");
    }
}