public class PetitSoin : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public PetitSoin(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 0;
        porteeMax = 5;
        ligneDeVue = true;
        typeCible = Jeu.CibleType.soin;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueSoin(cible, 2);
    }
}