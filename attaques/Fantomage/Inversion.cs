public class Inversion : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Inversion(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.inversion;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
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
            bool leaveCamouflage = casePerso.persoLeaveCase(perso);
            caseClone.invocationSimpleBloquante = null;
            clone.myCase = casePerso;
            clone.myCase.invocationSimpleBloquante = clone;
            caseClone.persoEnterCase(perso, leaveCamouflage: leaveCamouflage);
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
            {
                if (ciblePerso.reveal() == Jeu.EtatType.ko) // Cas : Cible est révélée et KO
                    return;
            }

            InvocationSimpleBloquante? clone = myCase.invocationSimpleBloquante;

            if (clone != null) // Cas : Le reveal a activé Feinte, ce qui a fait pop un clone
            {
                if (perso.pierre != null)
                    perso.dropPierre();

                Case myCaseClone = clone.myCase;
                Case myCasePerso = perso.myCase;
                bool leaveCamouflage = myCasePerso.persoLeaveCase(perso);
                myCaseClone.invocationSimpleBloquante = null;
                clone.myCase = myCasePerso;
                clone.myCase.invocationSimpleBloquante = clone;
                myCaseClone.persoEnterCase(perso, leaveCamouflage: leaveCamouflage);
                
                return;
            }

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

            bool persoLeaveCamouflage = casePerso.persoLeaveCase(perso);
            bool cibleLeaveCamouflage = caseCible.persoLeaveCase(ciblePerso);

            casePerso.persoEnterCase(ciblePerso, leaveCamouflage: cibleLeaveCamouflage);
            caseCible.persoEnterCase(perso, leaveCamouflage: persoLeaveCamouflage);
        }
    }
}
