using Cards;

Main.main();

public class Main
{
    public static void main()
    {
        Game game = new Game(5);
        Console.WriteLine(game.StartGame() + " WIN!");
    }
}
