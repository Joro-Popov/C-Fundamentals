﻿using Forum.App.Contracts;
using Forum.Data;
using Forum.DataModels;
using System;
using System.Linq;

public class UserService : IUserService
{
    private ForumData forumData;
    private ISession session;

    public UserService(ForumData forumData, ISession session)
    {
        this.forumData = forumData;
        this.session = session;
    }

    public User GetUserById(int userId)
    {
        throw new NotImplementedException();
    }

    public string GetUserName(int userId)
    {
        var username = this.forumData.Users.FirstOrDefault(u => u.Id == userId).Username;

        return username;
    }

    public bool TryLogInUser(string username, string password)
    {
        bool validUsername = !string.IsNullOrEmpty(username) && username.Length > 3;
        bool validPassword = !string.IsNullOrEmpty(password) && password.Length > 3;

        if (!validUsername || !validPassword)
        {
            return false;
        }

        User user = this.forumData.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

        if (user == null)
        {
            return false;
        }

        session.Reset();
        session.LogIn(user);

        return true;
    }

    public bool TrySignUpUser(string username, string password)
    {
        bool validUsername = !string.IsNullOrEmpty(username) && username.Length > 3;
        bool validPassword = !string.IsNullOrEmpty(password) && password.Length > 3;
        bool userAlreadyExists = this.forumData.Users.Any(u => u.Username == username);
        
        if (!validUsername || !validPassword)
        {
            throw new ArgumentException("username and Password must be longer than 3 symbols!");
        }

        if (userAlreadyExists)
        {
            throw new InvalidOperationException("Username taken!");
        }

        int userId = this.forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
        User user = new User(userId, username, password);

        this.forumData.Users.Add(user);
        this.forumData.SaveChanges();

        return true;
    }
}
