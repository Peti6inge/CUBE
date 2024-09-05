public class PoudreSoporifique : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public PoudreSoporifique(Perso perso)
        : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = Jeu.CibleType.persoEnnemy;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (cible is Perso)
            ((Perso)cible).passeTour = true;
        else if (cible is bool)
        {
            Perso? persoCible = (bool)cible ? myCase.persoOver() : myCase.perso();
            if (persoCible != null)
            {
                persoCible.passeTour = true;
                persoCible.reveal();
            }
        }
    }
}
