using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class ILeaveTypeDtoValidator : AbstractValidator<ILeaveTypeDto>
    {
        public ILeaveTypeDtoValidator() {

            RuleFor(p => p.Name)
                   .NotEmpty().WithMessage("{PropertyName} is required.")
                   .NotNull()
                   .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} Characters.");

            RuleFor(p => p.DefaultDays)
                .NotEmpty().WithMessage("{propertyName} is required.")
                .GreaterThan(0).WithMessage("{propertyName} must be at least 1.")
                .LessThan(100).WithMessage("{propertyName} must be less than {ComparisonValue}.");

        }
    }
}
