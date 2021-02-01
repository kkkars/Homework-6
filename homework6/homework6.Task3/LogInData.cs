using System.Text.Json.Serialization;

namespace homework6.Task3
{
    public class LogInData
    {
        [JsonPropertyName("login")]
        public string Login { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }

        public LogInData()
        {
        }

        public LogInData(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}
