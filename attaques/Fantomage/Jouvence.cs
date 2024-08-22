public class Jouvence : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Jouvence(Perso perso)
        : base(perso)
    {
        cout = 2;
        porteeMin = 1;
        porteeMax = 5;
        ligneDeVue = false;
        typeCible = Jeu.CibleType.soin;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        attaqueBasiqueSoin(cible, 2);
    }
}
