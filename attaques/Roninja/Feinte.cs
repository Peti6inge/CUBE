public class Feinte : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Feinte(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = Jeu.CibleType.freeOnPerso;
        limitParTour = 1;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
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
                return Jeu.EtatType.ok;

            perso.feinte = false;

            if (perso.pierre != null)
                perso.dropPierre();

            Case caseClone = clone.myCase;
            Case casePerso = perso.myCase;
            bool leaveCamouflage = casePerso.persoLeaveCase(perso);
            perso.desactiverHarpons(caseClone.face, casePerso.face);
            caseClone.invocationSimpleBloquante = null;
            clone.myCase = casePerso;
            clone.myCase.invocationSimpleBloquante = clone;
            caseClone.persoEnterCase(perso, leaveCamouflage: leaveCamouflage);
            return Jeu.EtatType.caseLeaved;
        }
        return Jeu.EtatType.ok;
    }
}
