public class BouletFantomatique : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public BouletFantomatique(Perso perso)
        : base(perso)
    {
        cout = 1;
        limitParCible = 3;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.persoEnnemy;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        Perso? persoCible;
        if (cible is Perso)
        {
            persoCible = (Perso)cible;
            if (persoCible.buffHp.ContainsKey(1))
                persoCible.buffHp[1] -= 1;
            else
                persoCible.buffHp.Add(1, -1);
        }
        else if (cible is bool)
        {
            persoCible = (bool)cible ? myCase.persoOver() : myCase.perso();
            if (persoCible != null)
            {
                if (persoCible.buffHp.ContainsKey(1))
                    persoCible.buffHp[1] -= 1;
                else
                    persoCible.buffHp.Add(1, -1);

                persoCible.reveal();
            }
        }
    }
}
