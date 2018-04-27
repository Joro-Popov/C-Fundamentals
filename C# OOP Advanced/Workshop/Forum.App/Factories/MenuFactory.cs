using Forum.App.Contracts;
using System;
using System.Linq;
using System.Reflection;

public class MenuFactory : IMenuFactory
{
    private IServiceProvider serviceProvider;

    public MenuFactory(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public IMenu CreateMenu(string menuName)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        var menuType = assembly.GetTypes()
            .FirstOrDefault(t => t.Name == menuName + "Menu");

        if (assembly == null)
        {
            throw new InvalidOperationException("Menu not found!");
        }
        if (!typeof(ICommand).IsAssignableFrom(menuType))
        {
            throw new InvalidOperationException($"{menuType} is not a menu!");
        }

        var ctrorParams = menuType.GetConstructors().First().GetParameters();

        object[] args = new object[ctrorParams.Length];

        for (int counter = 0; counter < args.Length; counter++)
        {
            args[counter] = this
                .serviceProvider
                .GetService(ctrorParams[counter].ParameterType);
        }

        var command = (IMenu)Activator.CreateInstance(menuType, args);

        return command;
    }
}

