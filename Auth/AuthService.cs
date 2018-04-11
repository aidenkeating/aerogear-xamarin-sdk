using System;
using AeroGear.Mobile.Core;
using AeroGear.Mobile.Core.Configuration;

namespace AeroGear.Mobile.Auth
{
    public class AuthService : IServiceModule
    {
        public string Type => "keycloak";

        public bool RequiresConfiguration => true;

        public void Configure(MobileCore core, ServiceConfiguration serviceConfiguration)
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
