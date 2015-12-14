using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GRM_APP.Models
{
    public class GeneralManager : IDisposable
    {
        GRMEntities context;
        public GeneralManager()
        {
            context = new GRMEntities();
            context.Database.Connection.Open();
          
        }
        public void Dispose()
        {
            context.Database.Connection.Close();
            context.Dispose();
        }
        public List<User> GetAllUsers()
        {
            return context.User.ToList();
        }

        public List<Company> GetAllCompanies()
        {
            return context.Company.ToList();
        }

        public List<Company> TopNineCompanies()
        {
           return context.Company.OrderByDescending(x => x.popularity).Take(9).ToList();
            
        }

        public void AddCompany(string Name, string About, string Logo, string Adrress, string Phone)
        {
            Company company = new Company();
            company.name = Name; company.about = About; company.logo = Logo; company.address = Adrress;
            company.phone = Phone;
            context.Company.Add(company);
            try
            {
                context.SaveChanges();
            }
            catch { }
        }

        public void AddUser(string Name, string Surname, DateTime Birth_date, string Gender, string Email, string Password)
        {
            User user = new User();
            user.name = Name;
            user.surname = Surname;
            user.birth_date = Birth_date;
            user.gender = Gender;
            user.email = Email;
            user.password = Password;
            context.User.Add(user);
            try
            {
                context.SaveChanges();
            }
            catch { }
        }
    }
}