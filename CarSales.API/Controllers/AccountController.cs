﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CarSales.API.Models.CustomeFilter;
using CarSales.API.Models.EF;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Pluralsight.AspNetDemo.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<IdentityUser> UserManager => HttpContext.GetOwinContext().Get<UserManager<IdentityUser>>();

        public SignInManager<IdentityUser, string> SignInManager
            => HttpContext.GetOwinContext().Get<SignInManager<IdentityUser, string>>();

        public ActionResult ExternalAuthentication(string provider)
        {
            SignInManager.AuthenticationManager.Challenge(
                new AuthenticationProperties
                {
                    RedirectUri = Url.Action("ExternalCallback", new {provider})
                }, provider);
            return new HttpUnauthorizedResult();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordModel model)
        {
            var user = await UserManager.FindByNameAsync(model.Username);

            if (user !=null)
            {
                var token = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var resetUrl = Url.Action("PasswordReset", "Account", new {userid = user.Id, token = token}, Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Password Reset", $"Use link to reset password: {resetUrl}");
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel model)
        {
            var signInStatus = await SignInManager.PasswordSignInAsync(model.Username, model.Password, true, true);

            switch (signInStatus)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("ChooseProvider");
                case SignInStatus.LockedOut:
                    var user = await UserManager.FindByNameAsync(model.Username);
                    if (user !=null && await UserManager.CheckPasswordAsync(user, model.Password))
                    {
                        ModelState.AddModelError("", "Account Locked");
                        return View(model);
                    }
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(model);

                default:
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(model);
            }
        }

       
            public ActionResult Logout()
        {

            Request.GetOwinContext().Authentication.SignOut();

            Request.GetOwinContext().Authentication.SignOut(Microsoft.AspNet.Identity.DefaultAuthenticationTypes.ApplicationCookie);


            return RedirectToAction("Index", "Home");
        }


            public async Task<ActionResult> ChooseProvider()
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            var providers = await UserManager.GetValidTwoFactorProvidersAsync(userId);

            return View(new ChooseProviderModel {Providers = providers.ToList()});
        }

        [HttpPost]
        public async Task<ActionResult> ChooseProvider(ChooseProviderModel model)
        {
            await SignInManager.SendTwoFactorCodeAsync(model.ChosenProvider);
            return RedirectToAction("TwoFactor", new { provider = model.ChosenProvider});
        }

        public ActionResult TwoFactor(string provider)
        {
            return View(new TwoFactorModel {Provider = provider});
        }

        [HttpPost]
        public async Task<ActionResult> TwoFactor(TwoFactorModel model)
        {
            var signInStatus = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, true, model.RememberBrowser);
            switch (signInStatus)
            {
                 case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                default:
                    ModelState.AddModelError("", "Invalid Credentials");
                    return View(model);
            }
        }

        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            var identityUser = await UserManager.FindByNameAsync(model.Username);
            if (identityUser != null)
            {
                ModelState.AddModelError("", "Already Registered");
                return View(model);
            }

            var result = await UserManager.PasswordValidator.ValidateAsync(model.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
                return View(model);
            }

            var user = new IdentityUser(model.Username) {Email = model.Username};
            var identityResult = await UserManager.CreateAsync(user, model.Password);

            if (identityResult.Succeeded)
            {              

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());
            return View(model);

        }

        public async Task<ActionResult> ConfirmEmail(string userid, string token)
        {
            var identityResult = await UserManager.ConfirmEmailAsync(userid, token);
            if (!identityResult.Succeeded)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult PasswordReset(string userid, string token)
        {
            return View(new PasswordResetModel {UserId = userid, Token = token});
        }

        [HttpPost]
        public async Task<ActionResult> PasswordReset(PasswordResetModel model)
        {
            var identityResult = await UserManager.ResetPasswordAsync(model.UserId, model.Token, model.Password);

            if (!identityResult.Succeeded)
            {
                return View("Error");
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> ExternalCallback(string provider)
        {
            var loginInfo = await SignInManager.AuthenticationManager.GetExternalLoginInfoAsync();
            var signInStatus = await SignInManager.ExternalSignInAsync(loginInfo, true);

            switch (signInStatus)
            {
                case SignInStatus.Success:
                    return RedirectToAction("Index", "Home");
                default:
                    var user = await UserManager.FindByEmailAsync(loginInfo.Email);
                    if (user != null)
                    {
                        var result = await UserManager.AddLoginAsync(user.Id, loginInfo.Login);
                        if (result.Succeeded)
                        {
                            return await ExternalCallback(provider);
                        }
                    }
                    return View("Error");
            }
        }


        public ActionResult SellerRegister()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> SellerRegister(SellerRegisterModel model)
        {
            var identityUser = await UserManager.FindByNameAsync(model.ContactEMail);
            if (identityUser != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var result = await UserManager.PasswordValidator.ValidateAsync(model.Password);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", result.Errors.FirstOrDefault());
                return View(model);
            }

            var user = new IdentityUser(model.ContactEMail) { Email = model.ContactEMail };
            var identityResult = await UserManager.CreateAsync(user, model.Password);

            if (identityResult.Succeeded)
            {
                Seller seller = new Seller() { AspNetUsersId= user.Id,
                ContactEMail=model.ContactEMail,ContactMobile=model.ContactMobile,ContactPhone=model.ContactPhone,
                Name=model.Name,PickupAddress=model.PickupAddress,PostCode=model.PostCode};
                CarSalesDBEntities db = new CarSalesDBEntities();
                db.Sellers.Add(seller);
                db.SaveChanges();

                return RedirectToAction("SellerRegisterDetail", "Account",new { ID=seller.ID});
            }

            ModelState.AddModelError("", identityResult.Errors.FirstOrDefault());

            return View(model);
        }

        [Authorize]       
        public ActionResult SellerRegisterDetail(int ID)
        {
            CarSalesDBEntities db = new CarSalesDBEntities();
            Seller seller = db.Sellers.Find(ID);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(new SellerRegisterModel() {
                AspNetUsersId=seller.AspNetUsersId,
                ContactEMail=seller.ContactEMail,
                ContactMobile=seller.ContactMobile,
                ContactPhone=seller.ContactPhone,
                ID=seller.ID,
                Name=seller.Name,
                PickupAddress=seller.PickupAddress,
                PostCode=seller.PostCode
            } );
          
        }

        public ActionResult SellerRegisterEdit(int ID)
        {
            CarSalesDBEntities db = new CarSalesDBEntities();
            Seller seller = db.Sellers.Find(ID);
            if (seller == null)
            {
                return HttpNotFound();
            }
            return View(new SellerRegisterModel()
            {
                AspNetUsersId = seller.AspNetUsersId,
                ContactEMail = seller.ContactEMail,
                ContactMobile = seller.ContactMobile,
                ContactPhone = seller.ContactPhone,
                ID = seller.ID,
                Name = seller.Name,
                PickupAddress = seller.PickupAddress,
                PostCode = seller.PostCode
            });

        }

        [HttpPost]
        public ActionResult SellerRegisterEdit(SellerRegisterModel SellerRegisterModel)
        {
            CarSalesDBEntities db = new CarSalesDBEntities();
            Seller seller = db.Sellers.Find(SellerRegisterModel.ID);
            if (seller == null)
            {
                return HttpNotFound();
            }
            else {
                seller.Name = SellerRegisterModel.Name;
                seller.ContactEMail = SellerRegisterModel.ContactEMail;
                seller.ContactMobile= SellerRegisterModel.ContactMobile;
                seller.ContactPhone = SellerRegisterModel.ContactPhone;
                seller.PickupAddress = SellerRegisterModel.PickupAddress;
                seller.PostCode = SellerRegisterModel.PostCode;
                db.Entry(seller).State = EntityState.Modified;
                db.SaveChanges();             

                return RedirectToAction("SellerRegisterDetail", "Account", new { ID = seller.ID });
            }
          

        }

    }




    public class PasswordResetModel
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public string Password { get; set; }
    }

    public class ForgotPasswordModel
    {
        public string Username { get; set; }
    }

    public class TwoFactorModel
    {
        public string Provider { get; set; }
        public string Code { get; set; }
        public bool RememberBrowser { get; set; }
    }

    public class ChooseProviderModel
    {
        public List<string> Providers { get; set; }
        public string ChosenProvider { get; set; }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }


    public class SellerRegisterModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
        public string ContactEMail { get; set; }
        public string PickupAddress { get; set; }
        public string PostCode { get; set; }
        public string AspNetUsersId { get; set; }
        public string Password { get; set; }
    }
}