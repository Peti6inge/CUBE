public class Feinte : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Feinte(Perso perso)
        : base(perso)
    {
        cout = 3;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = Jeu.CibleType.freeOnPerso;
        limitParTour = 1;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        perso.feinte = true;
    }

    public void activerFeinte() // DONE
    {
        if (perso.myCase == null)
            return;

        if (perso.attaques.ContainsKey(Jeu.AttaqueType.clone))
        {
            InvocationSimpleBloquante? clone = (
                (Clone)perso.attaques[Jeu.AttaqueType.clone]
            ).getClone();

            if (clone == null)
                return;

            perso.feinte = false;

            if (perso.pierre != null)
                perso.dropPierre();

            Case caseClone = clone.myCase;
            Case casePerso = perso.myCase;
            casePerso.persoLeaveCase(perso);
            perso.desactiverHarpons(caseClone.face, casePerso.face);
            clone.myCase = casePerso;
            caseClone.persoEnterCase(perso);
        }
    }
}
