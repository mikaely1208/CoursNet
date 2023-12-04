namespace ConsoleNoImplicitUsings;

class Program
{
    static void Main(string[] args)
    {
       
        Console.WriteLine("Hello, World!");
        String? s = null; 
        Console.WriteLine(s);
        int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        var maRange = array[4..^2];
        Console.WriteLine(string.Join(", ", maRange)); 
        
    }
}

public class Eleve {

     // En c# on utilise les property et les fileds
        // les property donnent accès a des methodes qui permettent de manipuler les fields on a des getters et des setters
        // les fields sont des variables qui stockent des valeurs


    // this is a property
    public required string Nom { get; set; }
    public required string Prenom { get; set; }
    public int Age { get; set; }

    // this is a field
    private string? _sexe;
}

public class Teacher {
    public required string Nom { get; set; }
    public required string Prenom { get; set; }

    public int Age { get; set; }

}

public interface ISelfLunching
{
    public void SelfLunch();
    public void SelfLunch(string plat);
    public void SelfLunch(string plat, string boisson);
    public void SelfLunch(string plat, string boisson, string dessert);
}

//test 


