using Application.Authentication;
using Application.DTO;
using Infrastructure.DAO;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class AuthService
    {
        private readonly JwtGenerator jwtGenerator;
        private readonly PasswordHasher passwordHasher;

        private readonly UserAccountRepository userAccountRepository;
        public AuthService(UserAccountRepository userAccountRepository, JwtGenerator jwtGenerator)
        {
            this.jwtGenerator = jwtGenerator;
            passwordHasher = new PasswordHasher();
            this.userAccountRepository = userAccountRepository;
        }

        public async Task<string?> Login(string userName, string password)
        {
            var user = await userAccountRepository.GetUserByName(userName);
            if (user == null) return null;
            var verifyResult = passwordHasher.Verify(password, user.passwordHash);
            if (verifyResult == false) return null;
            var jwtToken = jwtGenerator.GenerateToken(user.id);
            return jwtToken;
        }

        public async Task<RegistredUser?> Registration(string name, string password)
        {
            var result = await userAccountRepository.GetUserByName(name);
            if (result != null) return null;
            var hashPassword = passwordHasher.Generate(password);
            Console.WriteLine(name);
            Console.WriteLine(hashPassword);
            var createdUserId = await userAccountRepository.Add(new User(name, hashPassword));
            return new RegistredUser(createdUserId);
        }
    }
}