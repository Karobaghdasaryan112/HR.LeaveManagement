using HR.LeaveManagement.Identity.Models;
using HR.LeaveManagment.Application.Contracts.Identity;
using HR.LeaveManagment.Application.Models.Identity;
using HR.LeaveManagment.Application.Models.Identity.Auth;
using HR.LeaveManagment.Application.Models.Identity.Registration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HR.LeaveManagement.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        public AuthService(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<JwtSettings> jwtSettings
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthResponse> LoginAsync(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                throw new Exception($"User With {request.Email} not found");
            }
            var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);

            if(!result.Succeeded)
                throw new Exception($"Credentials for {request.Email} aren't valid");
            
            JwtSecurityToken securityToken = await GanarateToken(user);

            var AuthResponse = new AuthResponse()
            {
                Email = user.Email,
                Id = user.Id,
                UserName = user.UserName,
                Token = new JwtSecurityTokenHandler().WriteToken(securityToken)
            };

            return AuthResponse;

        }

        public async Task<RegistrationResponse> RegisterAsync(RegistrationRequest request)
        {
            var existingUser = await _userManager.FindByEmailAsync(request.UserName);

            if (existingUser != null)
            {
                throw new Exception($"User with {request.UserName} already exists");
            }
            var existingEmail = await _userManager.FindByEmailAsync(request.Email);

            if (existingEmail != null)
                throw new Exception($"User with {request.Email} already exists");

            var user = new ApplicationUser()
            {
                Email = request.Email,
                UserName = request.UserName,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Employee");
                return new RegistrationResponse()
                {
                    UserId = user.Id,
                };

            }
            throw new Exception($"Registration Failed for {request.Email} with errors {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
        public async Task<JwtSecurityToken> GanarateToken(ApplicationUser user)
        {
            var UserClaims = await _userManager.GetClaimsAsync(user);

            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("uid", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email)
                
            }
            .Union(UserClaims)
            .Union(roleClaims);

            var symmentricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var signinCredentials = new SigningCredentials(symmentricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = 
                new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                claims: claims,
                signingCredentials: signinCredentials
            );

            return jwtSecurityToken;
        }
    }
}
