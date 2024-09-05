public class FeuFollet : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public FeuFollet(Perso perso) : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 100;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.feuFollet;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueDegats(myCase, cible, 2);
    }
}