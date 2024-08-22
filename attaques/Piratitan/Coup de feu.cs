public class CoupDeFeu : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public CoupDeFeu(Perso perso) : base(perso)
    {
        cout = 2;
        limitParCible = 3;
        porteeMin = 1;
        porteeMax = 4;
        ligneDeVue = true;
        typeCible = (int)Jeu.CibleType.persoEtInvocEnnemy;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueDegats(myCase, cible, 2);
    }
}