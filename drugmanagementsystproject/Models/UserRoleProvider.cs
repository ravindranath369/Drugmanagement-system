using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using drugmanagementsystproject.dal;

namespace drugmanagementsystproject.Models
{
    public class UserRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string email)
        {
            DataAxcessingLayer userDb = new DataAxcessingLayer();
            List<string> role = new List<string>();
            EmployeeRegistrationModel emp = new EmployeeRegistrationModel();
            emp = userDb.Getsingleuserdetail(email);
            if (emp != null)
            {
                if (emp.Employee)
                    role.Add("Admin");
                else
                    role.Add("User");
            }
            else
                role.Add("Individual");
            
            return role.ToArray();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}