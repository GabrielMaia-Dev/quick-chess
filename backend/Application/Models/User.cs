using System;

namespace Application;

public class User
{
    public string Id { get; }
    public string Name { get; }
    public User(string name, string? id = null)
    {
        Name = name;
        Id = id ?? Guid.NewGuid().ToString();
    }
}
