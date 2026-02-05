namespace DemoDBConnection;


internal class ToDoItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }


    public override string ToString()
    {
        return $"{Title}: {Content}";
    }
}
