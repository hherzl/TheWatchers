namespace TheWatchers.Domain.Entities;

public partial class Environment
{
    public Environment(string name)
    {
        Active = true;

        Name = name;
    }
}
