using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using TravelAgency.BLL.BLL;
using TravelAgency.BLL.Util;
using TravelAgency.DAL.DAL;
using TravelAgency.DAL.Models;
using TravelAgency.DAL.Util;
using TravelAgency.MVC.Util;
using TravelAgency.MVC.ViewModels;
using TravelAgency.Repository;
using WebMatrix.WebData;

namespace TravelAgency.MVC.Controllers
{
    public class AccountController : Controller
    {
        private ITravelAgencyService service;

        public const String ADMIN_ROLE = "Admin";

        public const String CLIENT_ROLE = "Client";

        public AccountController()
        {
            this.service = new TravelAgencyService();
        }
        // GET: Login
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model, String returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                WebDataHelper.AddUserToRole(model.UserName);
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ViewBag.LoginMessage = "Login failed.";
            }

            return View(model);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Register(String userType, String returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (Request.IsAjaxRequest())
            {
                CreateCountryList();
                if (userType == "firm")
                {
                    return PartialView("_RegisterFirmPartial");
                }
                else if (userType == "person")
                {
                    return PartialView("_RegisterPersonPartial");
                }
                else
                {
                    return PartialView("_SelectItemPartial");
                }
            }
            CreateUserTypeList(null);
            return View();
        }

        private void CreateCountryList(int? selectedValue = null)
        {
            ViewData["Panstwo"] = GetCountrySelectList(selectedValue);
        }

        private void CreateAddressCountryList(FormCollection fc)
        {
            int? selected = null;
            int tmp;
            String s = fc == null ? null : fc["tAdresy.Panstwo"];
            if (s != null && s.IndexOf(',') > 0)
            {
                s = s.Substring(s.IndexOf(',') + 1);
            }
            if (fc != null && int.TryParse(s, out tmp))
                selected = tmp;
            ViewData["tAdresy.Panstwo"] = GetCountrySelectList(null);
        }

        private SelectList GetCountrySelectList(int? selectedValue)
        {
            return new SelectList(service.GetCountries(), "IDPanstwa", "NazwaPanstwa", selectedValue);
        }

        private void CreateUserTypeList(String selectedType)
        {
            ViewBag.userType = new SelectList(new UserType[] { 
                new UserType { TypeName = "--", TypeValue = "--" },
                new UserType { TypeName = "Firm", TypeValue = "firm" },
                new UserType { TypeName = "Person", TypeValue = "person" }}, "TypeValue", "TypeName", selectedType);
        }


        private bool CreateAccount(RegistrationModel model)
        {
            List<String> erroList = new List<String>(1);
            var res = WebDataHelper.CreateAccount(model.RegisterData.Email, model.RegisterData.Password, erroList);
            erroList.ForEach(i => ModelState.AddModelError(String.Empty, i));
            return res;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterPerson(RegistrationModel model, String returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                if (CreateAccount(model))
                {
                    try
                    {
                        service.CreatePerson(model.Person, model.Address, model.RegisterData.Email);
                        service.Save();
                        WebSecurity.Login(model.RegisterData.Email, model.RegisterData.Password);
                        return RedirectToLocal(returnUrl);
                    }
                    catch (Exception ex)
                    {
                        HandleRegistrationError(model, ex);
                    }
                }

            }
            ViewBag.UserPartialViewName = "_RegisterPersonPartial";
            CreateCountryList(model.GetSelectedCountry());
            CreateUserTypeList("person");
            return View("Register", model);
        }

        private void HandleRegistrationError(RegistrationModel model, Exception ex)
        {
            try
            {
                WebDataHelper.DeleteUser(model.RegisterData.Email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            ModelState.AddModelError("", ex.Message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterFirm(RegistrationModel model, String returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                if (CreateAccount(model))
                {
                    try
                    {
                        service.CreateFirm(model.Firm, model.Address, model.RegisterData.Email);
                        service.Save();
                        WebSecurity.Login(model.RegisterData.Email, model.RegisterData.Password);
                        return RedirectToLocal(returnUrl);
                    }
                    catch (Exception ex)
                    {
                        HandleRegistrationError(model, ex);
                    }
                }
            }
            ViewBag.UserPartialViewName = "_RegisterFirmPartial";
            CreateCountryList(model.GetSelectedCountry());
            CreateUserTypeList("firm");
            return View("Register", model);
        }

        [Authorize]
        public ActionResult Edit()
        {
            int? userId = service.GetClientId(User.Identity.Name);
            if (userId.HasValue)
            {
                CreateAddressCountryList(null);
                tFirmy firm = service.GetFirmData(userId.Value);
                if (firm != null)
                {
                    return View("EditFirm", firm);
                }
                else
                {
                    tOsoby person = service.GetPersonData(userId.Value);
                    if (person == null)
                    {
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        return View("EditPerson", person);
                    }
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditFirm(FormCollection fc, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tFirmy firm = service.GetFirmData(id.Value);
            try
            {
                if (TryUpdateModel(firm, "") && TryUpdateModel(firm.tAdresy, "tAdresy"))
                {
                    if (CheckPasswords(fc, service.GetClient(firm.IDKlienta)))
                    {
                        if (ModelState.IsValid)
                        {
                            service.ChangeFirmData(firm);
                            if (ChangePassword(fc["OldPassword"], fc["NewPassword"], firm.IDKlienta))
                            {
                                service.Save();
                                ViewBag.Message = "Data saved successfully.";
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                HandleEditionException(ex);
            }
            CreateAddressCountryList(fc);
            return View(firm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult EditPerson(FormCollection fc, int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tOsoby person = service.GetPersonData(id.Value);
            try
            {
                if (TryUpdateModel(person, "") && TryUpdateModel(person.tAdresy, "tAdresy"))
                {
                    if (CheckPasswords(fc, service.GetClient(person.IDKlienta)))
                    {
                        if (ModelState.IsValid)
                        {
                            service.ChangePersonData(person);
                            if (ChangePassword(fc["OldPassword"], fc["NewPassword"], person.IDKlienta))
                            {
                                service.Save();
                                ViewBag.Message = "Data saved successfully.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                HandleEditionException(ex);
            }

            CreateAddressCountryList(fc);
            return View(person);
        }

        private void HandleEditionException(Exception ex)
        {
            String saveDataError = "Failed to save data: ";
            var dbex = ex as DbUpdateException;
            if (dbex != null && dbex.InnerException != null)
            {
                if (dbex.InnerException.InnerException != null)
                    ViewBag.ErrorMessage = saveDataError + dbex.InnerException.InnerException.Message;
                else
                    ViewBag.ErrorMessage = saveDataError + dbex.InnerException.Message;
            }
            else
            {
                ViewBag.ErrorMessage = saveDataError + ex.Message;
            }
        }

        private bool ChangePassword(String oldPassword, string newPassword, int clientId)
        {
            if (ModelState.IsValid)
            {
                List<String> errorList = new List<String>(2);
                var res = WebDataHelper.ChangePassword(User.Identity.Name, oldPassword, newPassword, clientId, errorList);
                errorList.ForEach(e => ModelState.AddModelError("", e));
                return res;
            }
            return false;
        }
        private bool CheckPasswords(FormCollection fc, tKlient cd)
        {
            bool isValid = true;
            if (!String.IsNullOrEmpty(fc["NewPassword"])
                || !String.IsNullOrEmpty(fc["OldPassword"])
                || !String.IsNullOrEmpty(fc["NewPassword2"]))
            {
                if (fc["NewPassword"] != fc["NewPassword2"])
                {
                    ViewBag.NewPassword2Error = "Passwords do not match.";
                    isValid = false;
                }
                // Old password must not be chacked here since the WebSecurity carries about that.

                if (fc["NewPassword"].Length < 8)
                {
                    ViewBag.NewPasswordError = "New password is too short.";
                    isValid = false;
                }
            }
            return isValid;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
