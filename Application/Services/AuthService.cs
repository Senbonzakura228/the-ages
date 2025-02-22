using Application.Authentication;
using Data.DAO;
using Data.Repositories;

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

        public async Task<bool> Registration(string name, string password)
        {
            var result = await userAccountRepository.GetUserByName(name);
            if (result != null) return false;
            var hashPassword = passwordHasher.Generate(password);
            await userAccountRepository.Add(new User(name, hashPassword));
            return true;
        }
    }
}