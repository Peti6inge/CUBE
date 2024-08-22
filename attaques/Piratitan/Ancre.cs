public class Ancre : Attaque
{
    // Attributs // DONE

    private Dictionary<Perso, int> targets;

    // Constructeur // DONE
    public Ancre(Perso perso)
        : base(perso)
    {
        cout = 2;
        limitParCible = 1;
        porteeMin = 0;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.ancre;
        targets = new Dictionary<Perso, int>();
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (cible is Perso)
            targets[(Perso)cible] = 2;
        else if (cible is bool)
        {
            Perso? persoCible = myCase.perso();
            if (persoCible != null)
                targets[persoCible] = 2;
        }
    }

    public override void debutTour() // DONE
    {
        base.debutTour();
        
        foreach (KeyValuePair<Perso, int> target in targets.ToList())
        {
            targets[target.Key]--;
            if (targets[target.Key] == 0)
                desactiverAncre(target.Key);
        }
    }

    public void desactiverAncre(Perso p) // DONE
    {
        targets.Remove(p);
    }

    public List<Perso> getTargets() // DONE
    {
        return targets.Keys.ToList();
    }
}
