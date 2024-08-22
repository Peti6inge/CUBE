public class Reanimation : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Reanimation(Perso perso)
        : base(perso)
    {
        cout = 8;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.reanimation;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();

        Perso? persoToReanimate = null;
        switch (myCase.obstacleSpawn)
        {
            case (int)Jeu.SpawnType.Roninja:
                persoToReanimate = perso.isHost ? Jeu.roninjaHost : Jeu.roninjaClient;
                break;
            case (int)Jeu.SpawnType.Piratitan:
                persoToReanimate = perso.isHost ? Jeu.piratitanHost : Jeu.piratitanClient;
                break;
            case (int)Jeu.SpawnType.Elfee:
                persoToReanimate = perso.isHost ? Jeu.elfeeHost : Jeu.elfeeClient;
                break;
            case (int)Jeu.SpawnType.Fantomage:
                persoToReanimate = perso.isHost ? Jeu.fantomageHost : Jeu.fantomageClient;
                break;
        }
        if (persoToReanimate != null)
            persoToReanimate.respawn();
    }
}
