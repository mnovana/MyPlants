using MyPlants.Interfaces;

namespace MyPlants.Services
{
    public class FirebaseAuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;

        public FirebaseAuthenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<string> LoginAsync(string email, string password)
        {
            var body = new
            {
                email,
                password,
                returnSecureToken = true
            };

            var response = await _httpClient.PostAsJsonAsync("", body);

            if(response.IsSuccessStatusCode)
            {
                var payload = await response.Content.ReadFromJsonAsync<FirebasePayload>();
                return payload.IdToken;
            }
            else
            {
                
                throw new Exception("Failed login: " + response.StatusCode);
            }
        }

        public class FirebasePayload
        {
            public string Email { get; set; }
            public string LocalId { get; set; }
            public string DisplayName { get; set; }
            public string IdToken { get; set; }
            public bool Registered { get; set; }
            public string RefreshToken { get; set; }
            public string ExpiresIn { get; set; }
        }
    }
}
