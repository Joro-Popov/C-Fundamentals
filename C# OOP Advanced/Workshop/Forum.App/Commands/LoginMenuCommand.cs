using Forum.App.Contracts;

public class LoginMenuCommand : ICommand
{
    private IMenuFactory menuFactory;

    public LoginMenuCommand(IMenuFactory menufactory)
    {
        this.menuFactory = menufactory;
    }

    public IMenu Execute(params string[] args)
    {
        string commandName = this.GetType().Name;
        string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

        IMenu menu = this.menuFactory.CreateMenu(menuName);
        return menu;
    }
}