﻿using System.Threading.Tasks;
using Imgur.API.Authentication;
using Imgur.API.Models;

namespace Imgur.API.Endpoints
{
    /// <summary>
    ///     Authorizes account access.
    /// </summary>
    public interface IOAuth2Endpoint : IEndpoint
    {
        /// <summary>
        ///     Creates an authorization url that can be used to authorize access to a user's account.
        /// </summary>
        /// <param name="oAuth2ResponseType">Determines if Imgur returns a Code, a PIN code, or an opaque Token.</param>
        /// <param name="state">
        ///     This optional parameter indicates any state which may be useful to your application upon receipt of
        ///     the response.
        /// </param>
        /// <returns></returns>
        string GetAuthorizationUrl(OAuth2ResponseType oAuth2ResponseType, string state);

        /// <summary>
        ///     After the user authorizes, they will receive a PIN code that they copy into your app.
        ///     Get the access token from the PIN.
        /// </summary>
        /// <param name="pin">The PIN that the user is prompted to enter.</param>
        /// <returns></returns>
        Task<IOAuth2Token> GetTokenByPin(string pin);

        /// <summary>
        ///     After the user authorizes, the pin is returned as a code to your application
        ///     via the redirect URL you specified during registration, in the form of a regular query string parameter.
        ///     <para>Keep in mind that you can use localhost as a redirect URL.</para>
        /// </summary>
        /// <param name="code">The code from the query string.</param>
        /// <returns></returns>
        Task<IOAuth2Token> GetTokenByCode(string code);

        /// <summary>
        ///     If a user has authorized their account but you no longer have a valid access_token for them,
        ///     then a new one can be generated by using the refresh_token.
        ///     <para>
        ///         When your application receives a refresh token, it is important to store
        ///         that refresh token for future use.
        ///     </para>
        ///     <para>
        ///         If your application loses the refresh token, you will have to prompt the user
        ///         for their login information again.
        ///     </para>
        /// </summary>
        /// <returns></returns>
        Task<IOAuth2Token> GetTokenByRefreshToken(string refreshToken);
    }
}