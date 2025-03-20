using Application.DTO;
using FluentValidation;

namespace API.Validation
{
    public class BuildingPlaceValidator : AbstractValidator<PlaceBuildingRequestBody>
    {
        private readonly (int, int) _buildingIdInclusive = (1, 10000);
        private readonly (int, int) _XCoordinateInclusive = (-2000, 2000);
        private readonly (int, int) _YCoordinateInclusive = (0, 4000);

        public BuildingPlaceValidator()
        {
            RuleFor(x => x.buildingId)
             .NotNull().WithMessage("id is required")
             .InclusiveBetween(_buildingIdInclusive.Item1, _buildingIdInclusive.Item2)
             .WithMessage("available range between " + _XCoordinateInclusive);

            RuleFor(x => x.xCoordinate)
            .NotNull().WithMessage("X coordinate is required")
             .InclusiveBetween(_XCoordinateInclusive.Item1, _XCoordinateInclusive.Item2)
             .WithMessage("available range between " + _XCoordinateInclusive);

            RuleFor(x => x.yCoordinate)
            .NotNull().WithMessage("Y coordinate is required")
             .InclusiveBetween(_YCoordinateInclusive.Item1, _YCoordinateInclusive.Item2)
             .WithMessage("available range between " + _YCoordinateInclusive);
        }
    }
}