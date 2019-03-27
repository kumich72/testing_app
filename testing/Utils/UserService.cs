using System;
using System.Linq;
using testing.Models;

namespace testing.Utils
{
    public class UserService
    {
        const string RoleName = "student";
        private static NLog.Logger Nlogger = NLog.LogManager.GetCurrentClassLogger();

        public static bool Create(UserDto userDto)
        {
            Nlogger.Error("Пытаемся создать пользователя " + userDto.Name +";"+userDto.Login);
            try
            {
                using (UserContext db = new UserContext())
                {
                    var findRole = db.Role.Where(p => p.Name == RoleName).FirstOrDefault();

                    var findUser = db.User.Where(p => p.Name == userDto.Name && p.Login == userDto.Login).FirstOrDefault();

                    if (findUser == null)
                    {
                        User user = new User { Roles = findRole, Email = userDto.Email, Name = userDto.Name, Login = userDto.Login, Password = userDto.Password, PasswordConfirm = userDto.PasswordConfirm };

                        db.User.Add(user);
                        db.SaveChanges();
                        Nlogger.Error("Успешно создали пользователя " + userDto.Name + ";" + userDto.Login);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch(Exception ex)
            {
                Nlogger.Error("Не удалось создать пользователя! ошибка ="+ex.Message);
            }
            return false;

        }

        internal static LoginDto LoginIn(LoginDto loginDto)
        {
            using (UserContext db = new UserContext())
            {
                loginDto.Succsess = true;
                //Session["Login"] = loginDto.Login;
                // string[] userRoles = (string[])Session["UserRoles"];
                var findUser = db.User.Where(p => p.Password == loginDto.Password && p.Login == loginDto.Login).FirstOrDefault();

                if (findUser == null)
                {
                    loginDto.Succsess = false;
                }
            }
            return loginDto;
        }
    }
}