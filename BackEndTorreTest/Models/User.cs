﻿using Newtonsoft.Json;

namespace BackEndTorreTest.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? name { get; set; }
        public string? username { get; set; }
        public string? professionalHeadline { get; set; }
        public string? imageUrl { get; set; }
        [JsonIgnore]
        public List<User>? Favorites { get; set; } = new List<User>();
        [JsonIgnore]
        public int? FollowerId { get; set; }
        [JsonIgnore]
        public User? Follower { get; set; }
    }
}
