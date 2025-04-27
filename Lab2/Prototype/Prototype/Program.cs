
public class Virus : ICloneable
{
    public string Name { get; set; }
    public string Type { get; set; }
    public double Weight { get; set; }
    public int Age { get; set; }
    public List<Virus> Children { get; set; } = new List<Virus>();

    public Virus(string name, string type, double weight, int age)
    {
        Name = name;
        Type = type;
        Weight = weight;
        Age = age;
    }

    public object Clone()
    {
        Virus clone = new Virus(Name, Type, Weight, Age);
        foreach (var child in Children)
        {
            clone.Children.Add((Virus)child.Clone());
        }
        return clone;
    }

    public void ShowInfo(int level = 0)
    {
        Console.WriteLine(new string('-', level * 2) + $"> Virus: {Name}, Type: {Type}, Weight: {Weight}, Age: {Age}");
        foreach (var child in Children)
        {
            child.ShowInfo(level + 1);
        }
    }
}

class Program
{
    static void Main()
    {
        Virus parentVirus = new Virus("Alpha", "RNA", 2.5, 5);
        Virus child1 = new Virus("Beta", "RNA", 1.2, 3);
        Virus child2 = new Virus("Gamma", "RNA", 1.0, 2);
        Virus grandchild1 = new Virus("Delta", "RNA", 0.8, 1);
        Virus grandchild2 = new Virus("Epsilon", "RNA", 0.7, 1);
        Virus greatGrandchild = new Virus("Zeta", "RNA", 0.5, 0);

        grandchild1.Children.Add(greatGrandchild);
        child1.Children.Add(grandchild1);
        child1.Children.Add(grandchild2);
        parentVirus.Children.Add(child1);
        parentVirus.Children.Add(child2);

        Console.WriteLine("Original Family:");
        parentVirus.ShowInfo();

        Virus clonedVirus = (Virus)parentVirus.Clone();

        Console.WriteLine("\nCloned Family:");
        clonedVirus.ShowInfo();
    }
}