class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("-----------------------------------------------------------");
        Jeu.InitJeu();
        showGrid();
    }

    // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓ POUR DEBOGAGE ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    private static void showGrid()
    {
        String faceNorth = Jeu.north.toString();
        String faceSouth = Jeu.south.toString();
        String faceEast = Jeu.east.toString();
        String faceWest = Jeu.west.toString();
        String faceHost = Jeu.host.toString();
        String faceClient = Jeu.client.toString();
        String grid = "                               ________________\n";
        for (int i = 0; i < 8; i++)
        {
            grid += "                              |";
            grid += faceClient.Substring(i * 17, 16);
            grid += "|\n";
        }
        grid += "                               ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾\n";
        grid += "________________     ________________     ________________     ________________\n";
        for (int i = 0; i < 8; i++)
        {
            grid += faceSouth.Substring(i * 17, 16);
            grid += "|   |";
            grid += faceWest.Substring(i * 17, 16);
            grid += "|   |";
            grid += faceNorth.Substring(i * 17, 16);
            grid += "|   |";
            grid += faceEast.Substring(i * 17, 16);
            grid += "\n";
        }
        grid += "‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾     ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾     ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾     ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾\n";
        grid += "                               ________________\n";
        for (int i = 0; i < 8; i++)
        {
            grid += "                              |";
            grid += faceHost.Substring(i * 17, 16);
            grid += "|\n";
        }
        grid += "                               ‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾";
        Console.WriteLine(grid);
    }

    // ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑ POUR DEBOGAGE ↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑↑
}