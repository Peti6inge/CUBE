public class Clairvoyance : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Clairvoyance(Perso perso) : base(perso)
    {
        cout = 4;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = "freeOnPerso";
        limitParTour = 1;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();

        List<Perso> persosAdverses;
        if (perso.isHost)
            persosAdverses = Jeu.PersosClient();
        else
            persosAdverses = Jeu.PersosHost();

        foreach (Perso p in persosAdverses)
        {
            if (p.myCase != null
                && !p.isVisibleForMe(perso.isHost, faceDoitEtreVisible: true, caseDoitEtreOffBrume: true))
                p.temoinDePosition = p.myCase;
        }
    }
}