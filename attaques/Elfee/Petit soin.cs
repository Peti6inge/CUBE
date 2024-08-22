public class PetitSoin : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public PetitSoin(Perso perso) : base(perso)
    {
        cout = 2;
        porteeMin = 0;
        porteeMax = 5;
        ligneDeVue = true;
        typeCible = (int)Jeu.CibleType.soin;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueSoin(cible, 2);
    }
}