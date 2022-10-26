using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using drugmanagementsystproject.dal;
using drugmanagementsystproject.Models;

namespace drugmanagementsystproject.Controllers
{
    public class LoginpageController : Controller
    {
        //LoginModel l = new LoginModel();
        DataAxcessingLayer empdb = new DataAxcessingLayer();
        // GET: Loginpage
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel l)
        {
            if (ModelState.IsValid)
            {
                EmployeeRegistrationModel e = empdb.Getsingleuserdetail(l.email);

                if (e != null)
                {
                    if (e.emailid == l.email && l.password == e.password)
                    {
                        FormsAuthentication.SetAuthCookie(l.email, true);
                        return RedirectToAction("Dashboard", "EmployeeRegistration");
                    }
                    ModelState.AddModelError("", "Invalid password");
                    return View();
                }
                ModelState.AddModelError("", "Seems Like not register");
                return View();
            }
            ModelState.AddModelError("", "please enter crediancials");
            return View();
        }
            public ActionResult Logout()
            {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
            }

        public ActionResult ForgotPassword() 
        {
            return View();
        }
        //[HttpPost]
        //public ActionResult ForgotPassword(string EmailID)
        //{
        //    //verfify the email id
        //    //generate reset password, send email
        //    string message = "";
        //    bool status = false;

        //    //using (Datamanagementsystem dc = new Datamanagementsystem())
        //    //{
        //    //    ;
        //    //}
        //    EmployeeRegistrationModel E = empdb.getEmployeeById(EmailID);
        //    if (E != null)
        //    {
        //        if (E.emailid == EmailID)
        //        {
        //            string resetcode = Guid.NewGuid().ToString();
        //        }
        //        else
        //        {
        //            message="Account not found";
        //        }
        //    }

        //    return View();
        //}

        //public ActionResult SendVerficationLinkemail(string emailId,string activationcode,string emailFor="VerficyAccount")
        //{
        //    var verifyUrl = "/Users/" + emailFor + "/" + activationcode;
        //    var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
        //    var fromEmail = new MailAddress(emailId);
        //    var toEmail = new MailAdress(emailId);
        //    var fromEmailPassword="********"//we cal replace with actual password
        //    string subject = "your account is sucessfully created!!!";
        //    string body="<br/><br/> we exited to inform dotnet awesome account is"
        //        "sucessfully created"
        //        please click on below link to verify your account <a href= "+link+"link>+</a>
        //    return View();
        //}
    }
}