using System;
using AeroGear.Mobile.Auth.Credentials;
using Android.App;
using Android.Content;
using Android.Preferences;
using Java.Lang;

namespace Auth.Platform.Credentials
{
    /// <summary>
    /// Class for peristing, retrieving, updating and removing OpenID Connect
    /// credentials on a device.
    /// </summary>
    public class OIDCCredentialManager : ICredentialManager
    {
        private static readonly string StoreName = "AeroGear.Mobile.Auth.Credentials";

        private ISharedPreferences SharedPreferences;

        private static OIDCCredentialManager instance;

        /// <summary>
        /// Instance of the credential manager using the application context.
        /// </summary>
        /// <value>Instance of <see cref="OIDCCredentialManager"/></value>
        public static OIDCCredentialManager Instance {
            get
            {
                if (instance == null)
                {
                    instance = new OIDCCredentialManager(Application.Context.ApplicationContext);
                }
                return instance;
            }
        }

        private OIDCCredentialManager(Context context)
        {
            SharedPreferences = PreferenceManager.GetDefaultSharedPreferences(context.ApplicationContext);
        }

        public ICredential Read(string key)
        {
            string currentState = SharedPreferences.GetString(key, null);
            if (currentState == null) {
                return new OIDCCredential();
            }
            return new OIDCCredential(currentState);
        }

        public void Remove(string key)
        {
            if (!SharedPreferences.Edit().Remove(key).Commit())
            {
                throw new IllegalStateException("Failed to clear state from shared preferences");
            }
        }

        public void Save(string key, ICredential credential)
        {
            if (key == null) {
                Remove(key);
                return;
            }
            if (!SharedPreferences.Edit().PutString(key, credential.SerializedCredential).Commit()) {
                throw new IllegalArgumentException("Failed to update state from shared preferences");
            }
        }
    }
}
