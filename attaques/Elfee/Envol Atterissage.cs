public class EnvolAtterissage : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public EnvolAtterissage(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = (int)Jeu.CibleType.envolAtterissage;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (perso.enVol) // L'Elfée tente d'atterrir
        {
            if (!missAndReveal(myCase)) // Si l'atterissage est un succès
            {
                perso.enVol = false;
                myCase.persoEnterCase(perso);
            }
        }
        else // L'Elfée tente de s'envoler
        {
            Perso? persoToReveal = myCase.persoOver();
            if (persoToReveal != null) // Si l'envol est un échec
            {
                perso.energieActive += cout - 1;
                perso.miss();
                persoToReveal.reveal();
            }
            else // Si l'envol est un succès
            {
                perso.enVol = true;
            }
        }
    }
}