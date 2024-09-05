public class Clone : Attaque
{
    // Attributs // DONE
    private InvocationSimpleBloquante? myClone;

    // Constructeur // DONE
    public Clone(Perso perso)
        : base(perso)
    {
        cout = 1;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = Jeu.CibleType.tonneauOuClone;
        myClone = null;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (!missAndReveal(myCase))
        {
            if (myClone != null)
                myClone.estKO();

            myClone = new InvocationSimpleBloquante(
                Jeu.InvocationType.Clone,
                perso.isHost,
                myCase
            );

            myCase.invocationSimpleBloquante = myClone;

            Piege? piege1 = perso.isHost ? myCase.piegeClient : myCase.piegeHost;
            Piege? piege2 = perso.isHost ? myCase.piegeHost : myCase.piegeClient;

            if (piege1 != null)
                if (piege1.activer(myCase.invocationSimpleBloquante) == Jeu.EtatType.ko)
                    return;

            if (piege2 != null)
                if (piege2.activer(myCase.invocationSimpleBloquante) == Jeu.EtatType.ko)
                    return;
        }
    }

    public InvocationSimpleBloquante? getClone() // DONE
    {
        return myClone;
    }
}
