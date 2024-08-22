public class PoudreBienfaisante : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public PoudreBienfaisante(Perso perso)
        : base(perso)
    {
        cout = 3;
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

        for (int i = 1; i <= 3; i++)
        {
            if (persoCible.buffHp.ContainsKey(i))
                persoCible.buffHp[i] += 2;
            else
                persoCible.buffHp.Add(i, 2);
        }
    }
}
