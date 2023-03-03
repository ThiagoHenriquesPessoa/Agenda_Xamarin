using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_Xamarin.Class
{
    public class ServicosUser
    {
        public static string SenhaFireBase = "NaHFxU7TVMMx3QgI6mMYwKBq4GgKDPL7ciIPx5zR";

        private FirebaseClient Cliente = new FirebaseClient("https://agenda-xamarin-default-rtdb.firebaseio.com/",
            new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(SenhaFireBase)
            });

        public async Task<bool> RegistrarUsuario(string user, string senha)
        {
            try
            {
                await Cliente.Child("Usuarios").PostAsync(new Usuarios()
                {
                    Usuario = user,
                    Senha = senha                    
                });
            }
            catch
            {
                return false;
            }
            return true;
        } 

        public async Task<bool> VerificarLogin(string login, string loginSenha)
        {
            var consultar = (await Cliente.Child("Usuarios").OnceAsync<Usuarios>())
                .Where(u => u.Object.Usuario == login)
                .Where(u => u.Object.Senha == loginSenha)
                .FirstOrDefault();

            return consultar != null;
        }
    }
}