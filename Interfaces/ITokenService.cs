using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AspNetCore.JwtAuthentication.PasswordHasing.Plugin.Interfaces
{
    public interface ITokenService
    {
        /// <summary>
        ///  generate access token by providing neccessary information
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="validIssuer"></param>
        /// <param name="validAudience"></param>
        /// <param name="issuerSigningKey"></param>
        /// <param name="expireIn"></param>
        /// <returns></returns>
        string GenerateAccessToken(IEnumerable<Claim> claims,string validIssuer,string validAudience,string issuerSigningKey, string expireIn);
        /// <summary>
        /// generate refresh token
        /// </summary>
        /// <returns></returns>
        string GenerateRefreshToken();
        /// <summary>
        /// get principle from expired token to get new access token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="validateAudience"></param>
        /// <param name="validateIssuer"></param>
        /// <param name="validateLifeTime"></param>
        /// <param name="issuerSigningKey"></param>
        /// <returns></returns>
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token, bool validateAudience, bool validateIssuer, bool validateLifeTime, string issuerSigningKey = null);
    }
}
