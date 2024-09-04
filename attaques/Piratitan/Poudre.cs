public class Poudre : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Poudre(Perso perso) : base(perso)
    {
        cout = 0;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = Jeu.CibleType.freeOnPerso;
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