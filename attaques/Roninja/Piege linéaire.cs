public class PiegeLineaire : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public PiegeLineaire(Perso perso)
        : base(perso)
    {
        cout = 2;
        limitParTour = 2;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.piegeLineaire;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();

        if (perso.myCase == null)
            return;

        Perso? persoToReveal;

        foreach (Case c in myCase.GetLine(myCase.face, perso.myCase, myCase))
        {
            persoToReveal = c.perso();
            if (persoToReveal != null)
            {
                missAndReveal(c);
                return;
            }
        }
        persoToReveal = myCase.perso();
        if (persoToReveal != null)
        {
            missAndReveal(myCase);
            return;
        }

        Jeu.DirectionType direction = perso.myCase.directionTo(myCase);
        Case caseNextToPerso = perso.myCase.nextCaseDirection(direction);

        Piege piegeAPoser = new Piege(
            Jeu.PiegeType.PiegeLineaire,
            perso.isHost,
            caseNextToPerso,
            myCase
        );

        if (perso.isHost)
            myCase.piegeHost = piegeAPoser;
        else
            myCase.piegeClient = piegeAPoser;

        foreach (Case c in myCase.GetLine(myCase.face, perso.myCase, myCase))
        {
            if (perso.isHost)
                c.piegeHost = piegeAPoser;
            else
                c.piegeClient = piegeAPoser;
        }
    }
}
