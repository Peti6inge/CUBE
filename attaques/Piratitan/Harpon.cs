public class Harpon : Attaque
{
    // Attributs // DONE
    private Perso? cibleHarponnee;

    // Constructeur // DONE
    public Harpon(Perso perso)
        : base(perso)
    {
        cout = 4;
        limitParCible = 1;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = true;
        typeCible = (int)Jeu.CibleType.persoEnnemy";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (cible is Perso)
        {
            cibleHarponnee = (Perso)cible;
            cibleHarponnee.harponne.Add(perso);
            perso.harponne.Add(cibleHarponnee);
        }

        else if (cible is InvocationSimpleBloquante)
            ((InvocationSimpleBloquante)cible).estKO();

        else if (cible != null)
        {
            Perso? persoCible = (bool)cible ? myCase.persoOver() : myCase.perso();

            if (persoCible != null)
            {
                persoCible.reveal();
                cibleHarponnee = persoCible;
                cibleHarponnee.harponne.Add(perso);
                perso.harponne.Add(cibleHarponnee);
            }
        }
    }

    public void desactiver() // DONE
    {
        if (cibleHarponnee != null)
        {
            cibleHarponnee.harponne.Remove(perso);
            perso.harponne.Remove(cibleHarponnee);
            cibleHarponnee = null;
        }
    }
}
