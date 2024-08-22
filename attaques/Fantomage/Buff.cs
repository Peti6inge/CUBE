public class Buff : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Buff(Perso perso)
        : base(perso)
    {
        cout = 2;
        limitParCible = 1;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = false;
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
            persoCible.buffEnergie[1] += 4;
        else
            persoCible.buffEnergie.Add(1, 4);
    }
}
