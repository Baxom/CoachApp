using CoachApp.Application.Core.Repositories;
using CoachApp.Application.Domain.Users.Commands;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Users;
using MediatR;

namespace CoachApp.Application.Domain.Users.Handlers;
internal class UserCommandHandler : IRequestHandler<CreateUserAccount, ValidateWithoutResult>
{
    private readonly IRepository<User> _userAccountRepository;

    public UserCommandHandler(IRepository<User> userAccountRepository)
    {
        _userAccountRepository = userAccountRepository;
    }

    public async Task<ValidateWithoutResult> Handle(CreateUserAccount createUserAccount, CancellationToken cancellationToken)
    {
        var userAccount = User.Create(createUserAccount.Login, createUserAccount.Password);

        await _userAccountRepository.Add(userAccount);

        return ValidateWithoutResult.NoErrors;
    }
}
