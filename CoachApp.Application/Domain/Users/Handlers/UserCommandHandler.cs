using CoachApp.Application.Core.FluentValidation;
using CoachApp.Application.Core.Repositories;
using CoachApp.Application.Core.Security;
using CoachApp.Application.Domain.Users.Commands;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Users;
using MediatR;
using OneOf.Types;

namespace CoachApp.Application.Domain.Users.Handlers;
internal class UserCommandHandler : IRequestHandler<CreateUser, ValidateWithoutResult>,
                                    IRequestHandler<LogUser, ValidateResult<User>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IManagePassword _managePassword;

    public UserCommandHandler(IUnitOfWork unitOfWork, IManagePassword managePassword)
    {
        _unitOfWork = unitOfWork;
        _managePassword = managePassword;
    }

    public async Task<ValidateWithoutResult> Handle(CreateUser createUserAccount, CancellationToken cancellationToken)
    {
        var userAccount = User.Create(createUserAccount.Email, _managePassword.Encrypt(createUserAccount.Password));

        await _unitOfWork.Users.Add(userAccount);

        return new None();
    }

    public async Task<ValidateResult<User>> Handle(LogUser request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByEmail(request.Email);

        if (user is null || !_managePassword.Compare(request.Password, user.EncrytedPassword))
            return FluentValidationHelpers.CreateDomainFailure(UserErrors.UserNotFound);

        return user;
    }
}
