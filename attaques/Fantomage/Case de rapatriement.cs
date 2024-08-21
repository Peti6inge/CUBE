public class CaseDeRapatriement : Attaque
{
    // Attributs // DONE
    private Case? myCase;

    // Constructeur // DONE
    public CaseDeRapatriement(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = false;
        typeCible = "caseDeRapatriement";
        myCase = null;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }

    public void activer(Perso perso)
    {
        // TODO
    }

    public Case? getCase() // DONE
    {
        return myCase;
    }
    public void detruire() // DONE
    {
        myCase = null;
    }
}