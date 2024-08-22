public class Tonneau : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Tonneau(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.tonneauOuClone;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (!missAndReveal(myCase))
        {
            myCase.invocationSimpleBloquante = new InvocationSimpleBloquante(Jeu.InvocationType.Tonneau, perso.isHost, myCase);
            if (myCase.piegeClient != null)
                myCase.piegeClient.activer(myCase.invocationSimpleBloquante);

            if (myCase.piegeHost != null)
                myCase.piegeHost.activer(myCase.invocationSimpleBloquante);

        }
    }
}