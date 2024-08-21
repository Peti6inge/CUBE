public class Miniaturisation : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Miniaturisation(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = "miniaturisation";
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        perso.miniaturisation = true;
        perso.hp = 1;
        perso.hpMax = 1;
        perso.energie += 4;
    }
}