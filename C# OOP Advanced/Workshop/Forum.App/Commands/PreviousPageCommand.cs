using Forum.App.Contracts;

public class PreviousPageCommand : ICommand
{
    private ISession session;

    public PreviousPageCommand(ISession session)
    {
        this.session = session;
    }

    public IMenu Execute(params string[] args)
    {
        var currentMenu = this.session.Back();

        if (currentMenu is IPaginatedMenu paginatedMenu)
        {
            paginatedMenu.ChangePage();
        }

        return currentMenu;
    }
}