public class Feinte : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Feinte(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = "freeOnPerso";
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

        if (perso.attaques.ContainsKey("Clone"))
        {
            InvocationSimpleBloquante? clone = ((Clone)perso.attaques["Clone"]).getClone();

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