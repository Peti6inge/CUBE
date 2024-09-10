public class BondDuTitan : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public BondDuTitan(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = Jeu.CibleType.freeOnCase;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        Case? caseCible;
        Perso? persoCible;
        if (myCase.row != 0)
        {
            caseCible = myCase.face.grid[myCase.row - 1, myCase.col];
            persoCible = caseCible.perso();
            if (persoCible != null)
                pousser(persoCible, Jeu.DirectionType.Up);
            else if (
                caseCible.invocationSimpleBloquante != null
                && caseCible.invocationSimpleBloquante.type == Jeu.InvocationType.Clone
            )
                caseCible.invocationSimpleBloquante.estKO();
        }
        if (myCase.row != 7)
        {
            caseCible = myCase.face.grid[myCase.row + 1, myCase.col];
            persoCible = caseCible.perso();
            if (persoCible != null)
                pousser(persoCible, Jeu.DirectionType.Up);
            else if (
                caseCible.invocationSimpleBloquante != null
                && caseCible.invocationSimpleBloquante.type == Jeu.InvocationType.Clone
            )
                caseCible.invocationSimpleBloquante.estKO();
        }
        if (myCase.col != 0)
        {
            caseCible = myCase.face.grid[myCase.row, myCase.col - 1];
            persoCible = caseCible.perso();
            if (persoCible != null)
                pousser(persoCible, Jeu.DirectionType.Up);
            else if (
                caseCible.invocationSimpleBloquante != null
                && caseCible.invocationSimpleBloquante.type == Jeu.InvocationType.Clone
            )
                caseCible.invocationSimpleBloquante.estKO();
        }
        if (myCase.col != 7)
        {
            caseCible = myCase.face.grid[myCase.row, myCase.col + 1];
            persoCible = caseCible.perso();
            if (persoCible != null)
                pousser(persoCible, Jeu.DirectionType.Up);
            else if (
                caseCible.invocationSimpleBloquante != null
                && caseCible.invocationSimpleBloquante.type == Jeu.InvocationType.Clone
            )
                caseCible.invocationSimpleBloquante.estKO();
        }
    }

    // Méthodes private

    private Jeu.EtatType pousser(Perso? persoCible, Jeu.DirectionType direction) // DONE
    {
        if (persoCible != null && persoCible.canMoveDirection(direction) && !persoCible.isAncre())
            return persoCible.moveDirection(direction, bondDuTitan: true);
        return Jeu.EtatType.ok;
    }
}
