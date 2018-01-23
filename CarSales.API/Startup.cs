﻿using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;

[assembly: OwinStartup(typeof(Pluralsight.AspNetDemo.Startup))]

namespace Pluralsight.AspNetDemo
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            const string connectionString =
                @"Data Source=(LocalDb)\MSSQLLocalDB;Database=Pluralsight.AspNetIdentityDemo.Module3.3;trusted_connection=yes;";
            app.CreatePerOwinContext(() => new IdentityDbContext(connectionString));
            app.CreatePerOwinContext<UserStore<IdentityUser>>((opt, cont) => new UserStore<IdentityUser>(cont.Get<IdentityDbContext>()));
            app.CreatePerOwinContext<UserManager<IdentityUser>>(
                (opt, cont) =>
                {
                    var usermanager = new UserManager<IdentityUser>(cont.Get<UserStore<IdentityUser>>());
                    usermanager.RegisterTwoFactorProvider("SMS", new PhoneNumberTokenProvider<IdentityUser> {MessageFormat = "Token: {0}"});
                    usermanager.SmsService = new SmsService();
                    usermanager.UserTokenProvider = new DataProtectorTokenProvider<IdentityUser>(opt.DataProtectionProvider.Create());
                    usermanager.EmailService = new EmailService();

                    usermanager.UserValidator = new UserValidator<IdentityUser>(usermanager) {RequireUniqueEmail = true};
                    usermanager.PasswordValidator = new PasswordValidator
                    {
                        RequireDigit = true,
                        RequireLowercase = true,
                        RequireNonLetterOrDigit = true,
                        RequireUppercase = true,
                        RequiredLength = 8
                    };

                    usermanager.UserLockoutEnabledByDefault = true;
                    usermanager.MaxFailedAccessAttemptsBeforeLockout = 2;
                    usermanager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(3);

                    return usermanager;
                });
            app.CreatePerOwinContext<SignInManager<IdentityUser, string>>(
                (opt, cont) => new SignInManager<IdentityUser, string>(cont.Get<UserManager<IdentityUser>>(), cont.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<UserManager<IdentityUser>, IdentityUser>(
                        validateInterval: TimeSpan.FromSeconds(3),
                        regenerateIdentity: (manager, user) => manager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie))
                }
            });

            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
            {
                ClientId = ConfigurationManager.AppSettings["google:ClientId"],
                ClientSecret = ConfigurationManager.AppSettings["google:ClientSecret"],
                Caption = "Google"
            });

        }
    }
}
