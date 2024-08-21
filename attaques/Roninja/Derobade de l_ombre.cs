public class DerobadeDeLOmbre : Attaque
{
    // Attributs // DONE
    
    // Constructeur // DONE
    public DerobadeDeLOmbre(Perso perso) : base(perso)
    {
        cout = 4;
        porteeMin = 0;
        porteeMax = 100;
        ligneDeVue = true;
        typeCible = (int)Jeu.CibleType.derobadeDeLOmbre";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible)
    {
        uses();
        // TODO
    }
}