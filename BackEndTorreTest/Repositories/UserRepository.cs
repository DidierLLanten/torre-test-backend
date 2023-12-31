﻿using BackEndTorreTest.Models;
using BackEndTorreTest.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BackEndTorreTest.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public async Task PostUser(User User)
        {
            _dbContext.Add(User);
            await _dbContext.SaveChangesAsync();
        }

        public async Task PutUser(User user)
        {
            user.Follower = _dbContext.Users.FirstOrDefault(e => e.FollowerId == null);
            _dbContext.Add(user);
            //var userAux = _dbContext.Users.FirstOrDefault(e => e.FollowerId == null)
            //var userAux = _dbContext.Users.Include(u => u.Favorites).FirstOrDefault(e => e.FollowerId == null);
            //userAux.Favorites.Add(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
