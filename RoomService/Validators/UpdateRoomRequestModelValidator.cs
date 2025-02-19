using FluentValidation;
using RoomService.Data.Models;

namespace RoomService.Validators;

public class UpdateRoomRequestModelValidator : AbstractValidator<UpdateRoomRequestModel>
{
    public UpdateRoomRequestModelValidator()
    {
        RuleFor(x => new bool?[] { x.IsOccupied, x.IsUnderCleaning, x.IsUnderMaintenance, x.IsManuallyLocked })
           .Must(flags => flags.Count(f => f == true) <= 1)
           .WithMessage("Max one action is allowed in a single operation. (IsOccupied or IsUnderCleaning or IsUnderMaintenance or IsManuallyLocked)");

        RuleFor(x => x.Comment)
            .NotEmpty()
            .When(x => x.IsManuallyLocked == true)
            .WithMessage("Comment is required when setting room status as under maintenance.");
    }
}
