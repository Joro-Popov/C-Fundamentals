using Forum.App.Contracts;
using System;

public class CategoryInfoViewModel : ICategoryInfoViewModel
{
    public CategoryInfoViewModel(int id, string name, int postsCount)
    {
        this.Id = id;
        this.Name = name;
        this.PostCount = postsCount;
    }

    public int Id { get; }

    public string Name { get; }

    public int PostCount { get; }
}
