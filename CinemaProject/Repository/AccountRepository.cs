using CinemaProject.Data;
using CinemaProject.Models;
using System.Security.Principal;

namespace MVCTask2Day02.Repository
{
    public class AccountRepository : IAccountRepository
    {
        AppDBContext context;
        public AccountRepository(AppDBContext context)
        {
            this.context = context;
        }
        public Account Get(string username, string password)
        {
            return context.Accounts.FirstOrDefault(a => a.UserName == username && a.Password == password);
        }
        public string GetRoles(int id)
        {
            if (id % 2 == 0)
            {
                return "Admin";
            }
            return "User";
        }
        public void Create(Account account)
        {
            context.Accounts.Add(account);
        }

        public bool Find(string username, string password)
        {
            Account acc = context.Accounts.FirstOrDefault(e => e.UserName == username && e.Password == password);
            if (acc != null)
                return true;
            else
                return false;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
