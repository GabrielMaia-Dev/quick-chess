using Application;

namespace Tests;


public class UserGenerator
{
    public static User Create()
    {
        return new User("nome");
    }
}