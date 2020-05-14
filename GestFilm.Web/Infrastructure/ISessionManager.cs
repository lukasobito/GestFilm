using GestFilm.Models.Global;

namespace GestFilm.Web.Infrastructure
{
    public interface ISessionManager
    {
        User User { get; set; }

        void Abandon();
    }
}