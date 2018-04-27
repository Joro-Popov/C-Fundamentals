namespace EventImplementation
{
    public interface IHandler
    {
        void OnDispatcherNameChange(object sender, NameChangeEventArgs args);
    }
}