using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

public class JwtAuthManager
{
    public const string SECRET = "32rewwr3434re2gregrehherehsertherte";
    private const int EXPIRE_IN_MINS = 20;

    private UserAccountService _userAccountService;

    public JwtAuthManager(UserAccountService userAccountService)
    {
        _userAccountService = userAccountService;
    }

    public UserSession GenerateJwtToken(string userName, string password)
    {
        if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            return null;

        var userAccount = _userAccountService.GetUserAccountByUserName(userName);

        if (userAccount == null || userAccount.Password != password)
            return null;

        var tokenExpiryTimestamp = DateTime.Now.AddMinutes(EXPIRE_IN_MINS);
        var tokenKey = Encoding.ASCII.GetBytes(SECRET);

        var claimIdentity = new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.Name,userAccount.UserName),
            new Claim(ClaimTypes.Role,userAccount.Role)
        });

        var signincredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature);

        var secuityTokenDesciptor = new SecurityTokenDescriptor
        {
            Subject= claimIdentity,
            Expires = tokenExpiryTimestamp,
            SigningCredentials = signincredentials

        };
        var jwtSecurityHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityHandler.CreateToken(secuityTokenDesciptor);
        var token = jwtSecurityHandler.WriteToken(securityToken);

        var UserSession = new UserSession
        {
            UserName = userAccount.UserName,
            Role = userAccount.Role,
            Token = token,
            ExpiresIn = (int)tokenExpiryTimestamp.Subtract(DateTime.Now).TotalSeconds
        };

        return UserSession;
    }
}