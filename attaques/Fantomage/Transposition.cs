public class Transposition : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Transposition(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.transposition;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (perso.myCase == null)
            return;

        if (perso.pierre != null)
            perso.dropPierre();

        if (cible is InvocationSimpleBloquante) // Cas : Transposition avec le clone
        {
            InvocationSimpleBloquante clone = (InvocationSimpleBloquante)cible;
            Case caseClone = clone.myCase;
            Case casePerso = perso.myCase;
            bool leaveCamouflage = casePerso.persoLeaveCase(perso);
            clone.myCase = casePerso;
            caseClone.persoEnterCase(perso, leaveCamouflage: leaveCamouflage);
        }
        else if (cible is Perso) // Cas : Transposition avec un allié
        {
            Perso ciblePerso = (Perso)cible;

            if (ciblePerso.myCase == null)
                return;

            if (ciblePerso.pierre != null)
                ciblePerso.dropPierre();

            Case casePerso = perso.myCase;
            Case caseCible = ciblePerso.myCase;

            Perso? persoQuiPorteFantomage = perso.estPortePar();
            Perso? persoQuiPorteCible = ciblePerso.estPortePar();

            bool persoLeaveCamouflage = casePerso.persoLeaveCase(perso);
            bool cibleLeaveCamouflage = caseCible.persoLeaveCase(ciblePerso);

            if (persoQuiPorteFantomage != null)
            {
                persoQuiPorteFantomage.porte = ciblePerso;

                ciblePerso.myCase = casePerso;

                if (cibleLeaveCamouflage)
                    ciblePerso.reveal();

                casePerso.face.maJEmbrumage();
            }
            else
                casePerso.persoEnterCase(ciblePerso, cibleLeaveCamouflage);

            if (persoQuiPorteCible != null)
            {
                persoQuiPorteCible.porte = perso;

                perso.myCase = caseCible;

                if (persoLeaveCamouflage)
                    perso.reveal();

                caseCible.face.maJEmbrumage();
            }
            else
                caseCible.persoEnterCase(perso, persoLeaveCamouflage);
        }
    }
}
