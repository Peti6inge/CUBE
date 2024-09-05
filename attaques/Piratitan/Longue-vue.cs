public class LongueVue : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public LongueVue(Perso perso) : base(perso)
    {
        cout = 1;
        cooldown = 0;
        porteeMin = 0;
        porteeMax = 0;
        typeCible = Jeu.CibleType.freeOnFace;
    }

    // Méthodes public

    public override void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();

        if (cible == null)
            return;
            
        Face faceLancee = (Face)cible;

        facesLances.Add(faceLancee);
        if (perso.isHost)
            faceLancee.longueVueHost = true;
        else
            faceLancee.longueVueClient = true;
    }

    public void desactiver() // DONE
    {
        if (perso.isHost)
        {
            foreach (Face face in facesLances)
                face.longueVueHost = false;
        }
        else
        {
            foreach (Face face in facesLances)
                face.longueVueClient = false;
        }
        
        facesLances.Clear();
    }
}