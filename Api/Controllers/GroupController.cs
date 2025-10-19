// Api/Controllers/GroupController.cs
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FantasyTradesGroupService.Application.Command.CreateGroup;
using FantasyTradesGroupService.Application.Command.AddGroupMember;
using FantasyTradesGroupService.Application.Query.GetGroupById;
using FantasyTradesGroupService.Application.Query.GetGroupByCode;
using FantasyTradesGroupService.Application.Query.GetGroupsByMemberId;
using FantasyTradesGroupService.Application.Command.UpdateGroup;
using FantasyTradesGroupService.Application.Command.DeleteGroup;
using FantasyTradesGroupService.Application.Interfaces;
using FantasyTradesGroupService.Domain.Dtos;

[ApiController]
[Route("api/groups")]
public class GroupController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IGroupRepository _repo;

    public GroupController(IMediator mediator, IGroupRepository repo)
    {
        _mediator = mediator;
        _repo = repo;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGroupCommand command)
    {
        if (command.DraftDate == default || command.EndDate == default)
            return BadRequest("DraftDate and EndDate are required.");
        var id = await _mediator.Send(command);
        return Ok(new { groupId = id });
    }

    [HttpGet("{groupId}")]
    public async Task<IActionResult> GetById(Guid groupId)
    {
        var group = await _mediator.Send(new GetGroupByIdQuery(groupId));
        if (group == null)
            return NotFound();
        return Ok(group);
    }

    [HttpGet("code/{code}")]
    public async Task<IActionResult> GetByCode(string code)
    {
        var group = await _mediator.Send(new GetGroupByCodeQuery(code));
        if (group == null)
            return NotFound();
        return Ok(group);
    }

    [HttpGet("member/{userId}")]
    public async Task<IActionResult> GetGroupsByMember(Guid userId)
    {
        var groups = await _mediator.Send(new GetGroupsByMemberIdQuery(userId));
        return Ok(groups);
    }


    [HttpPost("{groupId}/members")]
    public async Task<IActionResult> AddMember(Guid groupId, [FromBody] AddGroupMemberCommand command)
    {
        if (groupId != command.GroupId)
            return BadRequest("Group ID in URL must match body");

        var group = await _repo.GetByIdAsync(groupId);
        if (group == null)
            return NotFound();

        await _mediator.Send(command);
        return Ok();
    }

    [HttpPut("{groupId}")]
    public async Task<IActionResult> Update(Guid groupId, [FromBody] UpdateGroupCommand command)
    {
        if (groupId != command.GroupId)
            return BadRequest("Group ID in URL must match body");
        if (command.DraftDate == default || command.EndDate == default)
            return BadRequest("DraftDate and EndDate are required.");
        await _mediator.Send(command);
        return Ok();
    }

    [HttpDelete("{groupId}")]
    public async Task<IActionResult> Delete(Guid groupId)
    {
        await _mediator.Send(new DeleteGroupCommand(groupId));
        return Ok();
    }
}
 
