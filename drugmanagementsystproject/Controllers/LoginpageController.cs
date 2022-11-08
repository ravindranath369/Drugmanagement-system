using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        IndivisualTrailsInfoDal idb = new IndivisualTrailsInfoDal();
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
                IndivisualTrailsInfoModel I = idb.GetindividualEmaildetail(l.email);
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
                else if (I != null)
                {
                    if (I.Emailid == l.email)
                    {
                        FormsAuthentication.SetAuthCookie(l.email, true);
                        return RedirectToAction("Index", "DrugTrailHist");
                    }
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

        [HttpPost]
        public ActionResult ForgotPassword(Forgotpassword fp)
        {
            try
            {

                //var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

                var user = empdb.Getsingleuserdetail(fp.Emailid);
                if (user != null)
                {
                    //Send email for reset password
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(user.emailid, resetCode, "ResetPassword");
                    if (empdb.AddResetPasswordCode(resetCode, user.employeeid))
                    {
                        return RedirectToAction("Index");
                    }
                    //account.ResetPasswordCode = resetCode;
                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
                    //in our model class in part 1
                    
                    ModelState.AddModelError("", "Server Error");
                    return View(fp);
                    //message = "Reset password link has been sent to your email id.";
                }
                else
                {
                    ModelState.AddModelError("", "Account doesnot exist");
                    return View(fp);
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View(fp);
            }

        }

        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Home/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress(ConfigurationManager.AppSettings.Get("FromEmail"), "Dotnet Awesome");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = ConfigurationManager.AppSettings.Get("Password"); // Replace with actual password

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";
                body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
                    " successfully created. Please click on the below link to verify your account" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/>We got request for reset your account password. Please click on the below link to reset your password" +
                    "<br/><br/><a href=" + link + ">Reset Password link</a>";
            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword),
                EnableSsl = true,
                
                //Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

        public ActionResult ResetPassword(string id)
        {
            //Verify the reset password link
            //Find account associated with this link
            
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }


            var user = empdb.GetEmployeeByResetPasswordCode(id);
            if (user != null)
            {
                ResetPasswordModel model = new ResetPasswordModel();
                model.resetcode = id;
                return View(model);
            }
            else
            {
                return HttpNotFound();
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            try
            {
                var message = "";
                if (ModelState.IsValid)
                {

                    var user = empdb.GetEmployeeByResetPasswordCode(model.resetcode);
                    if (user != null)
                    {
                        if (empdb.UpdatePassword(model.NewPassword, user.employeeid))
                        {
                            if (empdb.AddResetPasswordCode("", user.employeeid))
                            {
                                message = "New password updated successfully";
                                return RedirectToAction("Index");
                            }
                        }

                    }

                }
                else
                {
                    message = "Something Looks invalid";

                }
                ViewBag.Message = message;
                return View(model);

            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(model);
            }

        }
    }
}
