public class SoinTotal : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public SoinTotal(Perso perso) : base(perso)
    {
        cout = 6;
        porteeMin = 0;
        porteeMax = 2;
        ligneDeVue = true;
        typeCible = (int)Jeu.CibleType.soin;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueSoin(cible, 100);
    }
}