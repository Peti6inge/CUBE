public class Brume : Attaque
{
    // Attributs // DONE
    private Face? face;

    // Constructeur // DONE
    public Brume(Perso perso)
        : base(perso)
    {
        cout = 7;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = "freeOnFace";
        limitParTour = 1;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }

    public void desactiver()
    {
        if (face != null)
        {
            if (perso.isHost)
            {
                face.desactiverBrumeHost();
            }
            else
            {
                face.desactiverBrumeClient();
            }
            face = null;
        }
    }
}
