public class Harpon : Attaque
{
    // Attributs // DONE
    private Perso? cibleHarponnee;

    // Constructeur // DONE
    public Harpon(Perso perso)
        : base(perso)
    {
        cout = 2;
        limitParCible = 1;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.persoEnnemy;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
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
                cibleHarponnee = persoCible;
                cibleHarponnee.harponne.Add(perso);
                perso.harponne.Add(cibleHarponnee);
                persoCible.reveal();
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
