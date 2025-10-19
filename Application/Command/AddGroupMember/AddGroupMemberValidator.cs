using FluentValidation;

namespace FantasyTradesGroupService.Application.Command.AddGroupMember;

public class AddGroupMemberValidator : AbstractValidator<AddGroupMemberCommand>
{
    public AddGroupMemberValidator()
    {
        RuleFor(x => x.GroupId).NotEmpty();
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Username).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Role).NotEmpty().MaximumLength(50);
    }
}