public class PorterDeposer : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public PorterDeposer(Perso perso)
        : base(perso)
    {
        cout = 1;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = Jeu.CibleType.porterDeposer;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (perso.porte != null && perso.porte.myCase != null) // Déposer
        {
            int direction = perso.porte.myCase.directionTo(myCase);
            perso.porte.moveDirection(direction, porterDeposer: true);
        }
        else if (cible != null && perso.myCase != null) // Porter
        {
            Perso? persoToReveal = perso.myCase.persoOver();
            if (persoToReveal != null)
            {
                perso.energieActive += cout - 1;
                perso.miss();
                persoToReveal.reveal();
            }
            else
                monteSurMonDos((Perso)cible);
        }
    }

    // Méthodes privées

    private void monteSurMonDos(Perso p) // DONE
    {
        if (p.myCase == null || perso.myCase == null)
            return;

        p.myCase.persoLeaveCase(p);
        perso.porte = p;
        p.myCase = perso.myCase;

        if (p.myCase.containsCamouflage)
            p.invisibilite++;

        p.myCase.face.maJEmbrumage();
    }
}
