public class Attire : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Attire(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 2;
        porteeMax = 5;
        ligneDeVue = true;
        aligne = true;
        typeCible = Jeu.CibleType.attireRepousse;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (cible == null || perso.myCase == null)
            return;

        if (cible is InvocationSimpleBloquante) // Cas : Cible est un clone adverse
            ((InvocationSimpleBloquante)cible).estKO();
        else
        {
            Perso? ciblePerso;

            if (cible is Perso) // Cas : Cible est un perso
                ciblePerso = (Perso)cible;
            else // Cas : Cible est booléen
            {
                ciblePerso = (bool)cible ? myCase.persoOver() : myCase.perso();
                if (ciblePerso != null)
                    ciblePerso.reveal();
            }
            if (ciblePerso == null || ciblePerso.myCase == null) // Cas : Cible est absente
                return;

            int direction = ciblePerso.myCase.directionTo(perso.myCase);

            if (ciblePerso.canMoveDirection(direction))
                ciblePerso.moveDirection(direction, attire: true);
        }
    }
}
