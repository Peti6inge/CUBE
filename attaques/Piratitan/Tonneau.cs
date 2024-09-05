public class Tonneau : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Tonneau(Perso perso) : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.tonneauOuClone;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (!missAndReveal(myCase))
        {
            myCase.invocationSimpleBloquante = new InvocationSimpleBloquante(Jeu.InvocationType.Tonneau, perso.isHost, myCase);

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
}