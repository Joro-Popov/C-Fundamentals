﻿using Forum.App.Contracts;

public class ViewPostMenuCommand : ICommand
{
    private IMenuFactory menuFactory;

    public ViewPostMenuCommand(IMenuFactory menuFactory)
    {
        this.menuFactory = menuFactory;
    }

    public IMenu Execute(params string[] args)
    {
        int categoryId = int.Parse(args[0]);
        var commandName = this.GetType().Name;
        var menuName = commandName.Substring(0, commandName.Length - "Command".Length);

        var menu = (IIdHoldingMenu)this.menuFactory.CreateMenu(menuName);
        menu.SetId(categoryId);

        return menu;
    }
}