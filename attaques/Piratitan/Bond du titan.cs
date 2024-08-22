public class BondDuTitan : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public BondDuTitan(Perso perso)
        : base(perso)
    {
        cout = 4;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = (int)Jeu.CibleType.freeOnCase;
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
            pousser(persoCible, (int)Jeu.DirectionType.Up);
            if (
                caseCible.invocationSimpleBloquante != null
                && caseCible.invocationSimpleBloquante.type == (int)Jeu.InvocationType.Clone
            )
                caseCible.invocationSimpleBloquante.estKO();
        }
        if (myCase.row != 7)
        {
            caseCible = myCase.face.grid[myCase.row + 1, myCase.col];
            persoCible = caseCible.perso();
            pousser(persoCible, (int)Jeu.DirectionType.Down);
            if (
                caseCible.invocationSimpleBloquante != null
                && caseCible.invocationSimpleBloquante.type == (int)Jeu.InvocationType.Clone
            )
                caseCible.invocationSimpleBloquante.estKO();
        }
        if (myCase.col != 0)
        {
            caseCible = myCase.face.grid[myCase.row, myCase.col - 1];
            persoCible = caseCible.perso();
            pousser(persoCible, (int)Jeu.DirectionType.Left);
            if (
                caseCible.invocationSimpleBloquante != null
                && caseCible.invocationSimpleBloquante.type == (int)Jeu.InvocationType.Clone
            )
                caseCible.invocationSimpleBloquante.estKO();
        }
        if (myCase.col != 7)
        {
            caseCible = myCase.face.grid[myCase.row, myCase.col + 1];
            persoCible = caseCible.perso();
            pousser(persoCible, (int)Jeu.DirectionType.Right);
            if (
                caseCible.invocationSimpleBloquante != null
                && caseCible.invocationSimpleBloquante.type == (int)Jeu.InvocationType.Clone
            )
                caseCible.invocationSimpleBloquante.estKO();
        }
    }

    // Méthodes private

    private void pousser(Perso? persoCible, int direction) // DONE
    {
        if (persoCible != null && persoCible.canMoveDirection(direction) && !persoCible.isAncre())
            persoCible.moveDirection(direction, bondDuTitan: true);
    }
}
