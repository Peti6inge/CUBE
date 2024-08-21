public class Poudre : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Poudre(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = "freeOnPerso";
        limitParTour = 1;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        myCase.containsPoudre = true;
        perso.poudre = true;
    }
}