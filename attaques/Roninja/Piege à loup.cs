public class PiegeALoup : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public PiegeALoup(Perso perso)
        : base(perso)
    {
        cout = 5;
        porteeMin = 1;
        porteeMax = 2;
        ligneDeVue = true;
        typeCible = (int)Jeu.CibleType.piegeSimple;
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
                myCase.piegeHost = new Piege((int)Jeu.PiegeType.PiegeALoup, perso.isHost, myCase);
            else
                myCase.piegeClient = new Piege((int)Jeu.PiegeType.PiegeALoup, perso.isHost, myCase);
        }
    }
}
