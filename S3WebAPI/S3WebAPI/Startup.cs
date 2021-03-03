﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using Owin;

[assembly: OwinStartup(typeof(S3WebAPI.Startup))]

namespace S3WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,

                //The Path For generating the Toekn  
                TokenEndpointPath = new PathString("/token"),

                //Setting the Token Expired Time (24 hours)  
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),

                //AuthorizationServerProvider class will validate the user credentials  
                Provider = new AuthorizationServerProvider()
            };

            //Token Generations  
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
        }

    }
}