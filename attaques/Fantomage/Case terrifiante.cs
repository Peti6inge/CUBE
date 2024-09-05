public class CaseTerrifiante : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public CaseTerrifiante(Perso perso)
        : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.piegeSimple;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        Perso? persoToReveal = myCase.perso();
        if (persoToReveal != null)
            missAndReveal(myCase);
        else
        {
            if (perso.isHost)
                myCase.piegeHost = new Piege(
                    Jeu.PiegeType.CaseTerrifiante,
                    perso.isHost,
                    myCase
                );
            else
                myCase.piegeClient = new Piege(
                    Jeu.PiegeType.CaseTerrifiante,
                    perso.isHost,
                    myCase
                );
        }
    }
}
