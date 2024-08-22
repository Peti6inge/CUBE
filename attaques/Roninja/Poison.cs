public class Poison : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Poison(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 2;
        ligneDeVue = true;
        limitParCible = 1;
        typeCible = (int)Jeu.CibleType.persoEnnemy;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        Perso? persoCible;
        if (cible is Perso)
        {
            persoCible = (Perso)cible;
            for (int i = 1; i <= 5; i++)
            {
                if (persoCible.buffHp.ContainsKey(i))
                    persoCible.buffHp[i] -= 1;
                else
                    persoCible.buffHp.Add(i, -1);
            }
        }
        else if (cible is bool)
        {
            persoCible = (bool)cible ? myCase.persoOver() : myCase.perso();
            if (persoCible != null)
            {
                persoCible.reveal();
                for (int i = 1; i <= 5; i++)
                {
                    if (persoCible.buffHp.ContainsKey(i))
                        persoCible.buffHp[i] -= 1;
                    else
                        persoCible.buffHp.Add(i, -1);
                }
            }
        }
    }
}
