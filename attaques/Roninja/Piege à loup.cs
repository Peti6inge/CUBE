public class PiegeALoup : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public PiegeALoup(Perso perso)
        : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 2;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.piegeSimple;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        Perso? persoToReveal = myCase.perso();
        if (persoToReveal != null)
            missAndReveal(myCase);
        else
        {
            if (perso.isHost)
                myCase.piegeHost = new Piege(Jeu.PiegeType.PiegeALoup, perso.isHost, myCase);
            else
                myCase.piegeClient = new Piege(Jeu.PiegeType.PiegeALoup, perso.isHost, myCase);
        }
    }
}
