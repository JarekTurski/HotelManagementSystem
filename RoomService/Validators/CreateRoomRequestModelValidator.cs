using FluentValidation;
using RoomService.Data.Models;

namespace RoomService.Validators;

public class CreateRoomRequestModelValidator : AbstractValidator<CreateRoomRequestModel>
{
    public CreateRoomRequestModelValidator()
    {
        RuleFor(x => x.Name).NotEmpty();

        RuleFor(x => x.Size).NotEmpty();
    }
}
