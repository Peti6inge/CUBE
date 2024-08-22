public class PoudreStimulante : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public PoudreStimulante(Perso perso)
        : base(perso)
    {
        cout = 2;
        limitParTour = 2;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.persoFriendly;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        Perso? persoCible = (Perso?)cible;
        if (persoCible == null)
            return;

        if (persoCible.buffEnergie.ContainsKey(1))
            persoCible.buffEnergie[1] += 2;
        else
            persoCible.buffEnergie.Add(1, 2);

        if (persoCible.buffEnergie.ContainsKey(2))
            persoCible.buffEnergie[2] += 2;
        else
            persoCible.buffEnergie.Add(2, 2);
    }
}
