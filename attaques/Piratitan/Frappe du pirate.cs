public class FrappeDuPirate : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public FrappeDuPirate(Perso perso)
        : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = Jeu.CibleType.frappeDuPirate;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (!missAndReveal(myCase))
        {
            if (myCase.containsSimpleObstacle || myCase.containsDoubleObstacle)
                myCase.destroyObstacle();

            if (myCase.invocationSimpleBloquante != null)
                myCase.invocationSimpleBloquante.estKO();

            if (myCase.invocationDoubleBloquante != null)
                myCase.invocationDoubleBloquante.estKO();

            foreach (InvocationNonBloquante invoc in myCase.invocationsNonBloquantes())
            {
                if (invoc.hp > 0)
                    invoc.estKO();
            }
        }
    }
}
