public class CaseTerrifiante : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public CaseTerrifiante(Perso perso) : base(perso)
    {
        cout = 6;
        porteeMin = 1;
        porteeMax = 3;
        ligneDeVue = false;
        typeCible = "piegeSimple";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}