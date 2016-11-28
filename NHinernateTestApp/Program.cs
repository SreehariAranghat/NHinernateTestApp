using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace NHinernateTestApp
{
    class Program
    {
        static Configuration config = null;

        static void Main(string[] args)
        {
            config = new Configuration();
            config.Configure();

            Console.WriteLine("Enter your choice");
            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:

                    User user = new User();
                    Console.Write("Name : ");
                    user.Name = Console.ReadLine();
                    Console.WriteLine("Email : ");
                    user.Email = Console.ReadLine();
                    Console.WriteLine("Type : ");
                    user.Type = (UserType)int.Parse(Console.ReadLine());

                    SaveUser(user);

                    break;
                case 2:
                    Console.Write("Enter User Id : ");
                    int userId = int.Parse(Console.ReadLine());
                    User u = GetUser(userId);
                    if(u != null)
                    {
                        Console.WriteLine("Name : {0} , Email : {1} , Id : {2}, Type : {3}", u.Name, u.Email, u.Id, u.Type.ToString());

                    }
                    else
                    {
                        Console.WriteLine("User not found");
                    }

                    break;
                case 3:

                    var users = GetUsers();
                    foreach(User us in users)
                    {
                        Console.WriteLine("Name : {0} , Email : {1} , Id : {2}, Type : {3}", us.Name, us.Email, us.Id, us.Type.ToString());            
                    }
                    break;
            }


        }

        static void SaveUser(User user)
        {
            using (ISessionFactory fac = config.BuildSessionFactory())
            {
                using (ISession session = fac.OpenSession())
                {
                    using (ITransaction trans = session.BeginTransaction())
                    {
                        int s =  (int)session.Save(user);
                        trans.Commit();

                        Console.WriteLine("User {0} Created ", s);
                    }
                }
            }
        }

        static User GetUser(int id)
        {
            User user = null;

            using (ISessionFactory fac = config.BuildSessionFactory())
            {
                using (ISession session = fac.OpenSession())
                {
                    user = session.Get<User>(id);
                }
            }

           return user;
        }

        static List<User> GetUsers()
        {
            List<User> user = new List<User>();


            using (ISessionFactory fac = config.BuildSessionFactory())
            {
                using (ISession session = fac.OpenSession())
                {
                    user = session.Query<User>().ToList();
                }
            }

             return user;
        }
    }
}
