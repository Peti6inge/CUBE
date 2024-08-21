public class PorterDeposer : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public PorterDeposer(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = "porterDeposer";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (perso.porte != null && perso.porte.myCase != null) // Déposer
        {
            string direction;
            if (perso.porte.myCase.row == myCase.row - 1)
                direction = "down";
            else if (perso.porte.myCase.row == myCase.row + 1)
                direction = "up";
            else if (perso.porte.myCase.col == myCase.col - 1)
                direction = "right";
            else
                direction = "left";

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
                persoMonteSurMonDos((Perso)cible);

        }
    }

    // Méthodes privées

    private void persoMonteSurMonDos(Perso p) // DONE
    {
        if (p.myCase == null || perso.myCase == null)
            return;

        p.myCase.persoLeaveCase(p);
        perso.porte = p;
        p.myCase = perso.myCase;

        if (p.myCase.containsCamouflage)
            p.invisibilite++;

    }
}