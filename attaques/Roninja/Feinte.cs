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

    public Jeu.EtatType activerFeinte() // DONE
    {
        if (perso.myCase == null)
            return Jeu.EtatType.ko;

        if (perso.attaques.ContainsKey(Jeu.AttaqueType.clone))
        {
            InvocationSimpleBloquante? clone = (
                (Clone)perso.attaques[Jeu.AttaqueType.clone]
            ).getClone();

            if (clone == null)
                return Jeu.EtatType.normal;

            perso.feinte = false;

            if (perso.pierre != null)
                perso.dropPierre();

            Case caseClone = clone.myCase;
            Case casePerso = perso.myCase;
            casePerso.persoLeaveCase(perso);
            perso.desactiverHarpons(caseClone.face, casePerso.face);
            clone.myCase = casePerso;
            return caseClone.persoEnterCase(perso);
        }
        return Jeu.EtatType.normal;
    }
}
