public class DerniereVolonte : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public DerniereVolonte(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = "freeOnPerso";
        limitParTour = 1;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        perso.derniereVolonte = true;
    }
}