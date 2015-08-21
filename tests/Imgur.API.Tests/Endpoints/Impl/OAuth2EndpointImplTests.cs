﻿using Imgur.API.Authentication;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Models.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Imgur.API.Tests.Endpoints.Impl
{
    [TestClass]
    public class OAuth2EndpointImplTests
    {
        private const string OAuth2TokenResponse = "{\"access_token\":\"20649dae013aiuiui87878788787975ae2\",\"expires_in\":3600,\"token_type\":\"bearer\",\"scope\":null,\"refresh_token\":\"2132d34234jkljj84ce0c16fjkljfsdfdc70\",\"account_id\":45344,\"account_username\":\"Bob\"}";

        [TestMethod]
        public void GetAuthorizationUrl_SetStateNull_AreEqual()
        {
            var endpointUrl = "https://api.imgur.com/oauth2/authorize?client_id=ClientId&response_type=Code&state=";
            var imgurAuthentication = new ImgurAuthentication("ClientId", "ClientSecret");
            var endPoint = new OAuth2Endpoint(imgurAuthentication);
            Assert.AreEqual(endpointUrl, endPoint.GetAuthorizationUrl(OAuth2ResponseType.Code, null));
        }

        [TestMethod]
        public void GetAuthorizationUrl_SetState_AreEqual()
        {
            string endpointUrl = "https://api.imgur.com/oauth2/authorize?client_id=ClientId&response_type=Code&state=test";
            var imgurAuthentication = new ImgurAuthentication("ClientId", "ClientSecret");
            var endPoint = new OAuth2Endpoint(imgurAuthentication);
            Assert.AreEqual(endpointUrl, endPoint.GetAuthorizationUrl(OAuth2ResponseType.Code, "test"));
        }
    }
}
