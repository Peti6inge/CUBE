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
        typeCible = (int)Jeu.CibleType.freeOnCase";
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
            pousser(persoCible, "up");
            if (caseCible.invocationSimpleBloquante != null && caseCible.invocationSimpleBloquante.type == "Clone")
                caseCible.invocationSimpleBloquante.estKO();
        }
        if (myCase.row != 7)
        {
            caseCible = myCase.face.grid[myCase.row + 1, myCase.col];
            persoCible = caseCible.perso();
            pousser(persoCible, "down");
            if (caseCible.invocationSimpleBloquante != null && caseCible.invocationSimpleBloquante.type == "Clone")
                caseCible.invocationSimpleBloquante.estKO();
        }
        if (myCase.col != 0)
        {
            caseCible = myCase.face.grid[myCase.row, myCase.col - 1];
            persoCible = caseCible.perso();
            pousser(persoCible, "left");
            if (caseCible.invocationSimpleBloquante != null && caseCible.invocationSimpleBloquante.type == "Clone")
                caseCible.invocationSimpleBloquante.estKO();
        }
        if (myCase.col != 7)
        {
            caseCible = myCase.face.grid[myCase.row, myCase.col + 1];
            persoCible = caseCible.perso();
            pousser(persoCible, "right");
            if (caseCible.invocationSimpleBloquante != null && caseCible.invocationSimpleBloquante.type == "Clone")
                caseCible.invocationSimpleBloquante.estKO();
        }
    }

    // Méthodes private

    private void pousser(Perso? persoCible, string direction) // DONE
    {
        if (persoCible != null && persoCible.canMoveDirection(direction) && !persoCible.getAncre())
            persoCible.moveDirection(direction, bondDuTitan: true);
    }
}
