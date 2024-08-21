public class Teleport : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Teleport(Perso perso) : base(perso)
    {
        cout = 3;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = (int)Jeu.CibleType.teleport";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        Case? caseMemoire = ((Memoire)perso.attaques["Memoire"]).getTp();

        if (caseMemoire == null || perso.myCase == null)
            return;

        if (caseMemoire.containsSimpleObstacle
         || caseMemoire.containsDoubleObstacle
         || caseMemoire.invocationSimpleBloquante != null
         || caseMemoire.invocationDoubleBloquante != null
         || caseMemoire.containsTableClient
         || caseMemoire.containsTableHost
         || caseMemoire.obstacleSpawn != "") // Cas : Le tp est bloqué par un obstacle
        {
            perso.energieActive += cout - 1;
            perso.miss();
            return;
        }

        Perso? persoSurCaseMemoire = caseMemoire.perso();

        if (persoSurCaseMemoire != null) // Cas : Le tp est bloqué par un perso
        {
            perso.energieActive += cout - 1;
            perso.miss();

            bool containsBrumeAdverse = perso.isHost ? caseMemoire.containsBrumeRoninjaClient : caseMemoire.containsBrumeRoninjaHost;
            if (caseMemoire.face.faceVisible(persoSurCaseMemoire.isHost) && !containsBrumeAdverse) // Cas : Le perso est visible si reveal
                persoSurCaseMemoire.reveal();

            else // Cas : Le perso sera toujours invisible si reveal
                persoSurCaseMemoire.temoinDePosition = caseMemoire;

            return;
        }

        // Cas : Le tp est réussi

        if (perso.pierre != null)
            perso.dropPierre();

        Face facePrecedente = perso.myCase.face;
        Face nouvelleFace = caseMemoire.face;

        ((Memoire)perso.attaques["Memoire"]).setTp(perso.myCase);

        perso.myCase.persoLeaveCase(perso);
        perso.desactiverHarpons(facePrecedente, nouvelleFace);
        caseMemoire.persoEnterCase(perso, newFace: facePrecedente != nouvelleFace);
    }
}