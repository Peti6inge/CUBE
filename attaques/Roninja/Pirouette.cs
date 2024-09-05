public class Pirouette : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Pirouette(Perso perso)
        : base(perso)
    {
        cout = 1;
        porteeMin = 0;
        porteeMax = 0;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.freeOnPerso;
        limitParTour = 1;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        perso.pirouette = true;
    }

    public Jeu.EtatType activer() // DONE
    {
        if (perso.myCase == null)
            return Jeu.EtatType.ko;

        Face facePrecedente = perso.myCase.face;

        bool leaveCamouflage = perso.myCase.persoLeaveCase(perso);

        if (perso.isHost)
        {
            perso.desactiverHarpons(facePrecedente, Jeu.host);
            Jeu.host.grid[2, 2].persoEnterCase(perso, newFace: facePrecedente != Jeu.host, leaveCamouflage: leaveCamouflage);
        }
        else
        {
            perso.desactiverHarpons(facePrecedente, Jeu.client);
            Jeu
                .client.grid[2, 2]
                .persoEnterCase(perso, newFace: facePrecedente != Jeu.client, leaveCamouflage: leaveCamouflage);
        }
        return Jeu.EtatType.caseLeaved;
    }
}
