public class Clone : Attaque
{
    // Attributs // DONE
    private InvocationSimpleBloquante? myClone;

    // Constructeur // DONE
    public Clone(Perso perso)
        : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = Jeu.CibleType.tonneauOuClone;
        myClone = null;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (!missAndReveal(myCase))
        {
            myCase.invocationSimpleBloquante = new InvocationSimpleBloquante(
                Jeu.InvocationType.Clone,
                perso.isHost,
                myCase
            );
            if (myCase.piegeClient != null)
                myCase.piegeClient.activer(myCase.invocationSimpleBloquante);

            if (myCase.piegeHost != null)
                myCase.piegeHost.activer(myCase.invocationSimpleBloquante);
        }
    }

    public InvocationSimpleBloquante? getClone() // DONE
    {
        return myClone;
    }
}
