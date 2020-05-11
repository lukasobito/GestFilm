using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestFilm.Interfaces
{
    public interface IAuthRepository<TRegisterForm, TLoginForm, TResult>
    {
        TResult Login(TLoginForm loginForm);
        void Register(TRegisterForm registerForm);
    }
}
