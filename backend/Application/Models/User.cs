using System;

namespace Application;

/// <summary> Modelo de usuário. </summary>
public class User
{
    /// <summary> Identificador do usuário. </summary>
    public Guid Id { get; }
    /// <summary> Nome do usuário. </summary>
    public string Name { get; }
    public User(string name, Guid? id = null)
    {
        Name = name;
        Id = id ?? Guid.NewGuid();
    }
}
