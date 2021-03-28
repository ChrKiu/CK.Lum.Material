using FluentValidation;

namespace CK.Lum.Material.Domain.Validator
{
    public class MaterialValidator : AbstractValidator<Models.MaterialAggregate.Material>
    {
        /// <summary>
        /// Validator for <see cref="Material"/>
        /// </summary>
        public MaterialValidator()
        {
            RuleFor(Material => Material.MaterialFunction.MinTemperature)
                .LessThan(Material => Material.MaterialFunction.MaxTemperature)
                .WithMessage($"The entered min temperature is bigger than the entered max temperature.");
        }
    }
}
