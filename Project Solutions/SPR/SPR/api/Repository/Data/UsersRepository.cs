using api.Context;
using api.Models;
using api.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace api.Repository.Data
{
    public class UsersRepository : GeneralRepository<Db_context, User, int>
    {
        private readonly Db_context myContext;
        public UsersRepository(Db_context myContext) : base(myContext)
        {
            this.myContext = myContext;
        }

        public int Register(FormRegister param) //use postman  to test
        {
            try
            {
                var act = new User
                {
                    Username = param.Username,
                    Name=param.Name,
                    Email = param.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(param.Password),
                };
                myContext.Users.Add(act);
                myContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                Console.Write(e);
                return 0;
            }

        }

        public int Login(LoginForm loginVM)
        {
            var checkUsername = CheckDataAccount(loginVM.Username);
            if (checkUsername != null)
            {
                var getPassword = myContext.Users.Where(e => e.Username == checkUsername.Username).FirstOrDefault();
                bool checkPassword = BCrypt.Net.BCrypt.Verify(loginVM.Password, getPassword.Password);
                //     bool checkPassword = loginVM.Password == getPassword.Password ;
                if (checkPassword)
                {
                    return 1;
                }
                else
                {
                    return 3;
                }
            }
            else
            {
                return 2;
            }

        }
        public User CheckDataAccount(String param)
        {
            var respond = myContext.Users.Where(e => e.Username == param).FirstOrDefault();
            return respond;

        }
    }
}
