public class Etincelle : Attaque
{
    // Attributs // DONE

    // Constructeur // DONE
    public Etincelle(Perso perso) : base(perso)
    {
        cout = 1;
        porteeMin = 0;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.etincelle;
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();

        List<Case> cases = new List<Case>() { myCase };
        int poudre = 0;

        while (cases.Count > 0)
        {
            foreach (Case c in cases)
            {
                c.containsPoudre = false;
                if (c.getBombes().Count > 0)
                {
                    foreach (InvocationNonBloquante b in c.getBombes())
                        b.activerBombe(poudre);
                }
            }

            foreach (Case c in cases.ToList())
            {
                foreach (Case voisin in c.getVoisins())
                {
                    if (voisin.containsPoudre && !cases.Contains(voisin))
                        cases.Add(voisin);
                }
                cases.Remove(c);
            }
            poudre++;
        }
    }
}