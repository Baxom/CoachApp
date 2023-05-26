﻿using System.ComponentModel;
using FluentValidation.Results;
using OneOf;
using OneOf.Types;

namespace CoachApp.CQRS.Results;

[GenerateOneOf]
public partial class ValidateWithoutResult : OneOfBase<ValidationResult>
{
    public static ValidationResult NoErrors => new ValidationResult();
}

[GenerateOneOf]
public partial class ExistingResult<T> : OneOfBase<T, NotFound>
{

}

[GenerateOneOf]
public partial class ValidateResult<T> : OneOfBase<T, ValidationResult>
{

}

[GenerateOneOf]
public partial class ValidateExistingResult<T> : OneOfBase<T, NotFound, ValidationResult>
{

}