public class BouleDeFeu : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public BouleDeFeu(Perso perso) : base(perso)
    {
        cout = 2;
        limitParCible = 2;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = false;
        typeCible = "persoEtInvocEnnemy";
    }
    
    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}