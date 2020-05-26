using GestFilm.Models.Global;

namespace GestFilm.Web.Infrastructure
{
    public interface ISessionManager
    {
        User User { get; set; }
        int IdGroup { get; set; }

        void Abandon();
    }
}