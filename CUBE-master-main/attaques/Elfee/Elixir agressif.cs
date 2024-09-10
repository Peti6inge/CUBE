public class ElixirAgressif : Attaque
{
    // Attributs // DONE
    private List<Tuple<Perso, int>> persosCibles;

    // Constructeur // DONE
    public ElixirAgressif(Perso perso) : base(perso)
    {
        cout = 1;
        limitParCible = 1;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.persoFriendly;
        persosCibles = new List<Tuple<Perso, int>>();
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (cible == null)
            return;

        Perso ciblePerso = (Perso)cible;
        ciblePerso.boostDegats += 0.4f;

        persosCibles.Add(new Tuple<Perso, int>(ciblePerso, 2));
    }

    public override void debutTour() // DONE
    {
        base.debutTour();

        List<Tuple<Perso, int>> persosCiblesPrevious = persosCibles.ToList();

        persosCibles.Clear();

        foreach (Tuple<Perso, int> persoCible in persosCiblesPrevious)
        {
            if (persoCible.Item2 >= 2)
            {
                persoCible.Item1.boostDegats -= 0.4f;
                persosCibles.Add(new Tuple<Perso, int>(persoCible.Item1, persoCible.Item2 - 1));
            }
        }
    }

    public void desactiver(Perso p) // DONE
    {
        foreach (Tuple<Perso, int> persoCible in persosCibles.ToList())
        {
            if (persoCible.Item1 == p)
            {
                persoCible.Item1.boostDegats -= 0.4f;
                persosCibles.Remove(persoCible);
            }
        }
    }

    public List<Perso> getPersosCibles() // DONE
    {
        List<Perso> persos = new List<Perso>();

        foreach (Tuple<Perso, int> persoCible in persosCibles)
        {
            if (!persos.Contains(persoCible.Item1))
                persos.Add(persoCible.Item1);
        }

        return persos;
    }
}