using RestWithASPNET5.Configurations;
using RestWithASPNET5.Data.VO;
using RestWithASPNET5.Repository;
using RestWithASPNET5.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestWithASPNET5.Business.Implementations
{
    public class LoginBusiness : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;
        private IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginBusiness(TokenConfiguration configuration, IUserRepository userRepository, ITokenService tokenService)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public TokenVO ValidaCredenciais(UserVO userCredentials)
        {
            var user = _userRepository.ValidateCredentials(userCredentials);

            if (user == null)
            {
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var acessToken = _tokenService.GenerateAcessToken(claims);

            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpireTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _userRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now.AddMinutes(_configuration.Minutes);

            return new TokenVO(true, createDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), acessToken, refreshToken);       
        }

        public TokenVO ValidaCredenciais(TokenVO token)
        {
            var acessToken = token.AcessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(acessToken);

            var userName = principal.Identity.Name;

            var user = _userRepository.ValidateCredentials(userName);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpireTime <= DateTime.Now)
            {
                return null;
            }

            acessToken = _tokenService.GenerateAcessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            _userRepository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = DateTime.Now.AddMinutes(_configuration.Minutes);

            return new TokenVO(true, createDate.ToString(DATE_FORMAT), expirationDate.ToString(DATE_FORMAT), acessToken, refreshToken);
        }

        public bool RevokeToken(string userName)
        {
            return _userRepository.RevokeToken(userName);
        }
    }
}
