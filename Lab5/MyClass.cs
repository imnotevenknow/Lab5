namespace Lab5;

internal class MyClass
{
    public static T Factory<T>() where T : new() => new();
}