public class Acide : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Acide(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = Jeu.CibleType.acide;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        myCase.containsGlissante = false;
        myCase.containsCamouflage = false;
        myCase.containsTrou = true;
        if (myCase.piegeClient != null)
            myCase.piegeClient.estDetruit();
        if (myCase.piegeHost != null)
            myCase.piegeHost.estDetruit();
        if (myCase.invocationSimpleBloquante != null)
            myCase.invocationSimpleBloquante.estKO();
        if (myCase.invocationDoubleBloquante != null)
            myCase.invocationDoubleBloquante.estKO();
        myCase.containsPoudre = false;
        myCase.detruireCasesRappatriement();
        if (myCase.invocationsNonBloquantes().Count > 0)
        {
            foreach (InvocationNonBloquante invoc in myCase.invocationsNonBloquantes())
                invoc.estKO(bombeExplose: false);
        }

        Perso? persoQuiTombe = myCase.perso();
        if (persoQuiTombe != null)
            persoQuiTombe.tombeDansTrou();

        InvocationSimpleBloquante? coffreLePlusPres = myCase.face.coffreLePlusPres(myCase);
        foreach (Pierre p in myCase.getContainsPierre())
        {
            if (coffreLePlusPres != null)
                coffreLePlusPres.activerCoffre(p);
            else
                Jeu.PierreToTable(p);
        }
    }
}
