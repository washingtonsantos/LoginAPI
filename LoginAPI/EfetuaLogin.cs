using System;
using System.Net;
using System.Net.Http;
using System.Text;

namespace LoginAPI
{
    public class EfetuaLogin
    {
        public static bool SignEmailAndPassword(string usuario, string pass)
        {
            try
            {
                string json = string.Format(@"{{""Username"":""{0}"",""Password"":""{1}""}}", usuario, pass);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://45.132.242.97:5000");
                    client.DefaultRequestHeaders.Accept.Clear();

                    var response = client.PostAsync(
                        "api/Auth/v1/signin",
                         new StringContent(json, Encoding.UTF8, "application/json")).Result;

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
