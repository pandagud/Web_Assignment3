using AuthenticationHelper.Types;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationHelper.Extensions
{
    public static class TokenValidationParametersExtensions
    {
        public static TokenOptions ToTokenOptions(this TokenValidationParameters tokenValidationParameters,
            int tokenExpiryInMinutes = 30)
        {
            return new TokenOptions(tokenValidationParameters.ValidIssuer,
                tokenValidationParameters.ValidAudience,
                tokenValidationParameters.IssuerSigningKey,
                tokenExpiryInMinutes);
        }
    }
}