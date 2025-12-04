using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;

namespace DDON_WebPage.Components.Data
{
    public class ServerApi
    {
        public class ServerResponse
        {
            public string? Message { get; set; }
            public string? Error { get; set; }
            public string? Token { get; set; }
        }

        public static async Task<ServerResponse?> Operation(AppDbContext Pgsql, string action, string account, string password,string passwordToken, string email, string emailToken)
        {
            string path = "/api/account";
            var requestData = new
            {
                Action = action,
                Account = account,
                Password = password,
                PasswordToken = passwordToken,
                Email = email,
                EmailToken = emailToken
            };

            string jsonData = JsonSerializer.Serialize(requestData);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestVersion = System.Net.HttpVersion.Version11;

                HttpResponseMessage response;
                try
                {
                    response = await client.PostAsync("http://localhost:52099" + path, content);
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"\n Operation HTTP exception:\n{e}");
                    return new ServerResponse { Error = "Request failed." };
                }

                var responseBody = await response.Content.ReadAsStringAsync();

                ServerResponse? serverResponse;
                try
                {
                    serverResponse = JsonSerializer.Deserialize<ServerResponse>(responseBody);

                    if (!string.IsNullOrEmpty(serverResponse?.Token))
                    {
                        var user = await Pgsql.account.FirstOrDefaultAsync(u => u.NormalName == account.ToLower());

                        if (user == null)
                        {
                            serverResponse.Error = "Invalid user or password.";
                            return serverResponse;
                        }
                    }
                }
                catch (JsonException)
                {
                    return new ServerResponse { Error = "Invalid JSON response." };
                }

                return serverResponse;
            }
        }
    }
}