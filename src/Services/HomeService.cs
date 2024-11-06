using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using CodingExercise.Models; 

namespace CodingExercise.Services
{
    public class HomeService
    {
        private readonly HttpClient _httpClient;

        public HomeService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<User>> GetUsersAsync()
{
    var json = await _httpClient.GetStringAsync("https://dummyjson.com/users");

    var options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
    var userResponse = JsonSerializer.Deserialize<UserResponse>(json, options);

    using var document = JsonDocument.Parse(json);
    var root = document.RootElement;

    if (root.TryGetProperty("users", out JsonElement usersElement) && usersElement.ValueKind == JsonValueKind.Array)
    {
        Console.WriteLine($"Users array found with {usersElement.GetArrayLength()} elements.");
    }
    else
    {
        Console.WriteLine("Failed to locate 'users' property or it is not an array.");
    }

    if (userResponse == null || userResponse.Users == null)
    {
        Console.WriteLine("Deserialization to UserResponse failed or no users found.");
        return new List<User>();
    }

    Console.WriteLine($"Number of users deserialized: {userResponse.Users.Count}");
    return userResponse.Users;
}

    }
}
