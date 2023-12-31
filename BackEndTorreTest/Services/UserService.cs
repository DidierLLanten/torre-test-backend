﻿using BackEndTorreTest.Models;
using BackEndTorreTest.Repositories.Interfaces;
using BackEndTorreTest.Services.Interfaces;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace BackEndTorreTest.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            try
            {
                var httpClient = new HttpClient();
                var apiUrl = "https://torre.ai/api/entities/_searchStream";

                var jsonData = "{\r\n    \"excludeContacts\": true,\r\n    \"excludedPeople\": [],\r\n    \"identityType\": \"person\",\r\n    \"limit\": 10,\r\n    \"meta\": false,\r\n    \"query\": \"ROBERTO\",\r\n    \"torreGgId\": \"194304\"\r\n}";

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                List<User> usuarios = new List<User>();

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    string[] jsonObjects = responseContent.Split("\n", StringSplitOptions.RemoveEmptyEntries);


                    foreach (var jsonObject in jsonObjects)
                    {
                        User usuario = JsonSerializer.Deserialize<User>(jsonObject);
                        usuarios.Add(usuario);
                    }
                    return usuarios;
                }
                else
                {
                    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception e) { Console.WriteLine("****************************************************** " + e); }
            return null;
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public async Task AddFavorite(User user)
        {
            var users = _userRepository.GetAllUsers();
            User userAux;

            if (users.Count() == 0)
            {
                userAux = new User();
                userAux.Favorites.Add(user);
                await _userRepository.PostUser(userAux);
            }
            else
            {
                await _userRepository.PutUser(user);
            }
        }
    }
}
