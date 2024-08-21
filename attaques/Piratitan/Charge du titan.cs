public class ChargeDuTitan : Attaque
{
    // Attributs // DONE
    private Dictionary<Face, Dictionary<string, string>> directionsAbsoluesToRelatives;

    // Constructeur // DONE
    public ChargeDuTitan(Perso perso)
        : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.chargeDuTitan";
        directionsAbsoluesToRelatives = new Dictionary<Face, Dictionary<string, string>>()
        {
            {
                Jeu.host,
                new Dictionary<string, string>
                {
                    { "up", "up" },
                    { "down", "down" },
                    { "left", "left" },
                    { "right", "right" },
                    { "rotLeft", "rotLeft" },
                    { "rotRight", "rotRight" }
                }
            },
            {
                Jeu.client,
                new Dictionary<string, string>
                {
                    { "up", "down" },
                    { "down", "up" },
                    { "left", "left" },
                    { "right", "right" }
                }
            },
            {
                Jeu.north,
                new Dictionary<string, string>
                {
                    { "up", "up" },
                    { "down", "down" },
                    { "rotLeft", "left" },
                    { "rotRight", "right" }
                }
            },
            {
                Jeu.south,
                new Dictionary<string, string>
                {
                    { "up", "down" },
                    { "down", "up" },
                    { "rotLeft", "left" },
                    { "rotRight", "right" }
                }
            },
            {
                Jeu.east,
                new Dictionary<string, string>
                {
                    { "right", "up" },
                    { "left", "down" },
                    { "rotLeft", "left" },
                    { "rotRight", "right" }
                }
            },
            {
                Jeu.west,
                new Dictionary<string, string>
                {
                    { "left", "up" },
                    { "right", "down" },
                    { "rotLeft", "left" },
                    { "rotRight", "right" }
                }
            }
        };
    }

    // Méthodes public

    public void lancerAttaque(Case myCase, Object? cible) // DONE
    {
        uses();
        if (!missAndReveal(myCase))
        {
            if (perso.myCase == null)
                return;

            string direction = perso.myCase.directionTo(myCase);

            string absoluteDirection = getAbsoluteDirection(direction);
            int casesParcourues = 0;
            while (casesParcourues < 32)
            {
                string relativeDirection = getRelativeDirection(absoluteDirection);

                if (perso.harponne.Count > 0 && perso.myCase.face != perso.myCase.nextCaseDirection(relativeDirection).face)
                    break;

                if (perso.canMoveDirection(relativeDirection))
                {
                    perso.moveDirection(relativeDirection, chargeDuTitan: true);
                    casesParcourues++;
                    if (perso.myCase.obstacleSpawn == "Piratitan")
                        break;
                }
                else
                {
                    perso.recoitDegats(casesParcourues);

                    Object? obstacleRencontre = perso.nextObstacleDirection(relativeDirection);
                    if (obstacleRencontre != null)
                        perso.infligeDegats((int)(casesParcourues / 2), obstacleRencontre);

                    break;
                }
            }
        }
    }

    // Méthodes privées

    private string getRelativeDirection(string direction) // DONE
    {
        if (perso.myCase != null)
            return directionsAbsoluesToRelatives[perso.myCase.face][direction];
        return "";
    }

    private string getAbsoluteDirection(string direction) // DONE
    {
        if (perso.myCase != null)
            return directionsAbsoluesToRelatives[perso.myCase.face]
                .FirstOrDefault(x => x.Value == direction)
                .Key;
        return "";
    }
}
