using CoachApp.Application.Core.Repositories;
using CoachApp.CQRS.Results;
using CoachApp.Domain.Users;
using MediatR;

namespace CoachApp.Application.Domain.Users.Commands.Handlers;
internal class UserAccountCommandHandler : IRequestHandler<CreateUserAccount, ValidateWithoutResult>
{
    private readonly IRepository<User> _userAccountRepository;

    public UserAccountCommandHandler(IRepository<User> userAccountRepository)
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
