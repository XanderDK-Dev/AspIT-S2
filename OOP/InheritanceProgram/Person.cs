namespace InheritanceProgram;

public class Person
{
    private int id;
    private string name;

    public Person(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id
    {
        get => id;
        set
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            else if(value != id)
            {
                id = value;
            }
        }
    }

    public string Name
    {
        get => name;
        set
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Invalid name", nameof(Name));
            }
            else if (value != name)
            {
                name = value;
            }
        }
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}";
    }
}
