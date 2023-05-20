using CoachApp.Application.Core.Repositories;
using CoachApp.Domain.Users;
using MediatR;

namespace CoachApp.Application.Domain.Users.Commands.Handlers;
internal class UserAccountCommandHandler : IRequestHandler<CreateUserAccount>
{
    private readonly IRepository<User> _userAccountRepository;

    public UserAccountCommandHandler(IRepository<User> userAccountRepository)
    {
        _userAccountRepository = userAccountRepository;
    }

    public Task Handle(CreateUserAccount createUserAccount, CancellationToken cancellationToken)
    {
        var userAccount = User.Create(createUserAccount.Login, createUserAccount.Password);

        return _userAccountRepository.Add(userAccount);
    }
}
