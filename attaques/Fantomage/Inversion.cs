public class Inversion : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Inversion(Perso perso)
        : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.inversion;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (perso.myCase == null)
            return;

        if (cible is InvocationSimpleBloquante) // Cas : Inversion avec le clone
        {
            if (perso.pierre != null)
                perso.dropPierre();

            InvocationSimpleBloquante clone = (InvocationSimpleBloquante)cible;
            Case caseClone = clone.myCase;
            Case casePerso = perso.myCase;
            casePerso.persoLeaveCase(perso);
            clone.myCase = casePerso;
            caseClone.persoEnterCase(perso);
        }
        else
        {
            Perso? ciblePerso;

            if (cible is Perso) // Cas : Cible est un perso visible
                ciblePerso = (Perso)cible;
            else // Cas : Cible est un perso invisible
                ciblePerso = myCase.perso();

            if (ciblePerso == null) // Cas : Il n'y a personne
                return;

            if (ciblePerso.myCase == null)
                return;

            if (ciblePerso.invisibilite > 0) // Cas : Cible est invisible
                ciblePerso.reveal();

            if (ciblePerso.isAncre()) // Cas : Cible est ancrée
            {
                perso.energieActive += cout - 1;
                perso.miss();
                return;
            }

            Perso? persoPorte = ciblePerso.porte;

            if (persoPorte != null) // Cas : Cible est porteur
            {
                perso.energieActive += cout - 1;
                perso.miss();
                persoPorte.reveal();
                return;
            }

            if (perso.pierre != null)
                perso.dropPierre();

            if (ciblePerso.pierre != null)
                ciblePerso.dropPierre();

            Case casePerso = perso.myCase;
            Case caseCible = ciblePerso.myCase;

            casePerso.persoLeaveCase(perso);
            caseCible.persoLeaveCase(ciblePerso);

            casePerso.persoEnterCase(ciblePerso);
            caseCible.persoEnterCase(perso);
        }
    }
}
