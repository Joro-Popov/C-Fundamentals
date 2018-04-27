public class Robot : IIdentifiable
{
    private string id;
    private string model;

    public Robot(string model, string id)
    {
        this.Model = model;
        this.Id = id;
    }

    public string Model
    {
        get { return model; }
        private set { model = value; }
    }

    public string Id
    {
        get { return id; }
        private set { id = value; }
    }
}