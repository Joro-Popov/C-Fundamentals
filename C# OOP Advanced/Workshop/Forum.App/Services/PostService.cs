﻿using Forum.App.Contracts;
using Forum.Data;
using System;
using System.Collections.Generic;
using System.Linq;

public class PostService : IPostService
{
    private ForumData forumData;
    private IUserService userService;

    public PostService(ForumData forumData, IUserService userService)
    {
        this.forumData = forumData;
        this.userService = userService;
    }

    public IEnumerable<IReplyViewModel> GetPostReplies(int postId)
    {
        var replies = this.forumData.Replies
            .Where(p => p.PostId == postId)
            .Select(r => new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));

        return replies;
    }

    public int AddPost(int userId, string postTitle, string postCategory, string postContent)
    {
        throw new NotImplementedException();
    }

    public void AddReplyToPost(int postId, string replyContents, int userId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
    {
        var categories = this.forumData.Categories.Select(c => new CategoryInfoViewModel(c.Id, c.Name, c.Posts.Count));
        return categories;
    }

    public string GetCategoryName(int categoryId)
    {
        var categoryName = this.forumData.Categories.Find(c => c.Id == categoryId)?.Name;

        if (categoryName == null)
        {
            throw new ArgumentException($"Category with id {categoryId} not found!");
        }

        return categoryName;
    }

    public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
    {
        var postsIds = forumData.Categories.First(c => c.Id == categoryId).Posts;

        var posts = forumData.Posts.Where(p => postsIds.Contains(p.Id));
        

    }

    public IPostViewModel GetPostViewModel(int postId)
    {
        var post = this.forumData.Posts.FirstOrDefault(p => p.Id == postId);
        IPostViewModel postView = new PostViewModel(post.Title, this.userService.GetUserName(post.AuthorId), post.Content, this.GetPostReplies(postId));

        return postView;
    }
}
