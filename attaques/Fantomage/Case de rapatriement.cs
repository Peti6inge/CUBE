public class CaseDeRapatriement : Attaque
{
    // Attributs // DONE
    private Case? myCase;

    // Constructeur // DONE
    public CaseDeRapatriement(Perso perso)
        : base(perso)
    {
        cout = 1;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.caseDeRapatriement;
        myCase = null;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible)  // DONE
    {
        uses();
        if (!missAndReveal(myCase))
            this.myCase = myCase;
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
