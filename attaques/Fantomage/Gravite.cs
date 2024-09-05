public class Gravite : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Gravite(Perso perso)
        : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.gravite;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (perso.isHost)
            myCase.containsGraviteFantomageHost = true;
        else
            myCase.containsGraviteFantomageClient = true;

        Perso? persoToAttract = myCase.nextCaseDirection(Jeu.DirectionType.Up).perso();
        if (persoToAttract != null && !persoToAttract.isAncre())
            myCase.activerGravite(persoToAttract);
        if (!myCase.containsGraviteFantomageHost && !myCase.containsGraviteFantomageClient)
            return;

        persoToAttract = myCase.nextCaseDirection(Jeu.DirectionType.Down).perso();
        if (persoToAttract != null && !persoToAttract.isAncre())
            myCase.activerGravite(persoToAttract);
        if (!myCase.containsGraviteFantomageHost && !myCase.containsGraviteFantomageClient)
            return;

        persoToAttract = myCase.nextCaseDirection(Jeu.DirectionType.Left).perso();
        if (persoToAttract != null && !persoToAttract.isAncre())
            myCase.activerGravite(persoToAttract);
        if (!myCase.containsGraviteFantomageHost && !myCase.containsGraviteFantomageClient)
            return;

        persoToAttract = myCase.nextCaseDirection(Jeu.DirectionType.Right).perso();
        if (persoToAttract != null && !persoToAttract.isAncre())
            myCase.activerGravite(persoToAttract);
    }
}
