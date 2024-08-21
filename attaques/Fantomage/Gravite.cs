public class Gravite : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public Gravite(Perso perso) : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = false;
        typeCible = "gravite";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }

    public static void activer(Perso perso, Case caseTrou)
    {
        // TODO
    }
}