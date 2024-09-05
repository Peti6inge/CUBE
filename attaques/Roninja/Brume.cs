public class Brume : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Brume(Perso perso)
        : base(perso)
    {
        cout = 4;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = Jeu.CibleType.freeOnFace;
        limitParTour = 1;
    }

    // Méthodes public
    
    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (perso.isHost)
            myCase.face.activerBrumeHost();
        else
            myCase.face.activerBrumeClient();
    }

    public void desactiver() // DONE
    {
        foreach (Face face in Jeu.getFaces())
        {
            if (perso.isHost)
                face.desactiverBrumeHost();
            else
                face.desactiverBrumeClient();
        }
    }
}
