using System;
using AeroGear.Mobile.Auth.Credentials;
using OpenId.AppAuth;

namespace Auth.Platform.Credentials
{
    /// <summary>
    /// Credential for OpenID Connect. This contains the access, identity and
    /// refresh tokens and other metadata for the credential.
    /// </summary>
    public class OIDCCredential : ICredential
    {
        /// <summary>
        /// The <see cref="AuthState"/> that backs the wrapping credential.
        /// </summary>
        private AuthState AuthState;

        public string SerializedCredential => AuthState.JsonSerializeString();

        public string AccessToken => AuthState.AccessToken;

        public string IdentityToken => AuthState.IdToken;

        public string RefreshToken => AuthState.RefreshToken;

        public bool IsAuthorized => AuthState.IsAuthorized;

        public bool IsExpired => AuthState.HasClientSecretExpired;

        public OIDCCredential(string serializedCredential)
        {
            AuthState = AuthState.JsonDeserialize(serializedCredential);
        }

        public OIDCCredential() {
            AuthState = new AuthState();
        }
    }
}
