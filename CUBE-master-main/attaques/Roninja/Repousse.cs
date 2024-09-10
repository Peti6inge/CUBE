public class Repousse : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Repousse(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = true;
        aligne = true;
        typeCible = Jeu.CibleType.attireRepousse;
        limitParCible = 2;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)  // DONE
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
                {
                    Jeu.EtatType etatApresReveal = ciblePerso.reveal();
                    if (etatApresReveal == Jeu.EtatType.ko) // Cas : Cible est révélée et KO
                        return;

                    InvocationSimpleBloquante? clone = myCase.invocationSimpleBloquante;

                    if (clone != null) // Cas : Le reveal a activé Feinte, ce qui a fait pop un clone
                    {
                        clone.estKO();
                        return;
                    }
                }
            }
            if (ciblePerso == null || ciblePerso.myCase == null) // Cas : Cible est absente
                return;

            Jeu.DirectionType direction = ciblePerso.myCase.directionTo(perso.myCase, directionInverse: true);

            if (ciblePerso.canMoveDirection(direction))
                ciblePerso.moveDirection(direction, repousse: true);
        }
    }
}