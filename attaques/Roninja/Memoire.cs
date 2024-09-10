public class Memoire : Attaque
{
    // Attributs // DONE
    private Case? tp;
    
    // Constructeur // DONE
    public Memoire(Perso perso) : base(perso)
    {
        cout = 0;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = Jeu.CibleType.memoire;
        tp = null;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        tp = myCase;
    }

    public Case? getTp() // DONE
    {
        return tp;
    }

    public void setTp(Case? tp) // DONE
    {
        this.tp = tp;
    }

    public void detruire() // DONE
    {
        tp = null;
    }
}