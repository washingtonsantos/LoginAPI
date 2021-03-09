using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LoginAPIConsole
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static async void Login()
        {

            IsValidateLogin("user_test1", "admin1234");

        }

        public static bool IsValidateLogin(string usuario, string password)
        {
            try
            {
                string myJson = "{\"Username\":\"user_test1\",\"Password\":\"admin2016\"}";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://45.132.242.97:5000");
                    client.DefaultRequestHeaders.Accept.Clear();
                    
                    var response = client.PostAsync(
                        "api/Auth/v1/signin",
                         new StringContent(myJson, Encoding.UTF8, "application/json")).Result;

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        //LoginTokenResult login = JsonConvert.DeserializeObject<LoginTokenResult>(result);
                        //return GetVerificaTokenValido(LoginTokenResult.AccessToken).Result;
                        return true;
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        return false;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
