using AutoMapper;
using HR.LeaveManagement.MVC.Contracts;
using HR.LeaveManagement.MVC.Services.Base;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IAuthenticationService = HR.LeaveManagement.MVC.Contracts.IAuthenticationService;

namespace HR.LeaveManagement.MVC.Services
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly IHttpContextAccessor _httpAccsessor;
        private readonly IMapper _mapper;
        private JwtSecurityTokenHandler _tokenHandler;

        public AuthenticationService(IClient client, ILocalStorageServices services,IHttpContextAccessor httpContextAccessor,IMapper mapper) : base(client, services)
        {
            _httpAccsessor = httpContextAccessor;
            _mapper = mapper;
            _tokenHandler = new JwtSecurityTokenHandler();
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            try
            {
                AuthRequest authRequest = new() { Email = email, Password = password };
                var response = await _client.LoginAsync(authRequest);

                var tokenContet = _tokenHandler.ReadJwtToken(response.Token);
                var claims = ParseClaims(tokenContet);
                var user = new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));
                 await _httpAccsessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);
                _localStorage.SetStorageValue("token", response.Token);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task LogOut()
        {
            _localStorage.ClearStorage(new List<string> { "token" });
            await _httpAccsessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task<RegistrationResponse> Register(string email, string password, string firstName, string LastName, string userName)
        {
            RegistrationRequest registrationRequest = new RegistrationRequest()
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = LastName,
                UserName = userName
            };

            var response = await _client.RegisterAsync(registrationRequest);

            if (!string.IsNullOrEmpty(response.UserId))
                await Authenticate(registrationRequest.Email, registrationRequest.Password);

            return response;
        }
        private IList<Claim> ParseClaims(JwtSecurityToken tokenContent)
        {
            var claims = tokenContent.Claims.ToList();
            claims.Add(new Claim(ClaimTypes.Name, tokenContent.Subject));
            return claims;
        }
    }
}
