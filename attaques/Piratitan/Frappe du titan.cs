public class FrappeDuTitan : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public FrappeDuTitan(Perso perso)
        : base(perso)
    {
        cout = 8;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.frappeDuTitan;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (!missAndReveal(myCase))
        {
            myCase.containsGlissante = false;

            myCase.containsCamouflage = false;

            if (myCase.piegeHost != null)
                myCase.piegeHost.estDetruit();

            if (myCase.piegeClient != null)
                myCase.piegeClient.estDetruit();

            myCase.containsPoudre = false;

            myCase.detruireCasesRappatriement();

            myCase.detruireTPsRoninja();

            myCase.containsTrou = true;
        }
    }
}
