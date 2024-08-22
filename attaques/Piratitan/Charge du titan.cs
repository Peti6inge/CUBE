public class ChargeDuTitan : Attaque
{
    // Attributs // DONE
    private Dictionary<Face, Dictionary<int, int>> directionsAbsoluesToRelatives;

    // Constructeur // DONE
    public ChargeDuTitan(Perso perso)
        : base(perso)
    {
        cout = 4;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = (int)Jeu.CibleType.chargeDuTitan;
        directionsAbsoluesToRelatives = new Dictionary<Face, Dictionary<int, int>>()
        {
            {
                Jeu.host,
                new Dictionary<int, int>
                {
                    { (int)Jeu.DirectionType.Up, (int)Jeu.DirectionType.Up },
                    { (int)Jeu.DirectionType.Down, (int)Jeu.DirectionType.Down },
                    { (int)Jeu.DirectionType.Left, (int)Jeu.DirectionType.Left },
                    { (int)Jeu.DirectionType.Right, (int)Jeu.DirectionType.Right },
                    { (int)Jeu.DirectionType.RotLeft, (int)Jeu.DirectionType.RotLeft },
                    { (int)Jeu.DirectionType.RotRight, (int)Jeu.DirectionType.RotRight }
                }
            },
            {
                Jeu.client,
                new Dictionary<int, int>
                {
                    { (int)Jeu.DirectionType.Up, (int)Jeu.DirectionType.Down },
                    { (int)Jeu.DirectionType.Down, (int)Jeu.DirectionType.Up },
                    { (int)Jeu.DirectionType.Left, (int)Jeu.DirectionType.Left },
                    { (int)Jeu.DirectionType.Right, (int)Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.north,
                new Dictionary<int, int>
                {
                    { (int)Jeu.DirectionType.Up, (int)Jeu.DirectionType.Up },
                    { (int)Jeu.DirectionType.Down, (int)Jeu.DirectionType.Down },
                    { (int)Jeu.DirectionType.RotLeft, (int)Jeu.DirectionType.Left },
                    { (int)Jeu.DirectionType.RotRight, (int)Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.south,
                new Dictionary<int, int>
                {
                    { (int)Jeu.DirectionType.Up, (int)Jeu.DirectionType.Down },
                    { (int)Jeu.DirectionType.Down, (int)Jeu.DirectionType.Up },
                    { (int)Jeu.DirectionType.RotLeft, (int)Jeu.DirectionType.Left },
                    { (int)Jeu.DirectionType.RotRight, (int)Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.east,
                new Dictionary<int, int>
                {
                    { (int)Jeu.DirectionType.Right, (int)Jeu.DirectionType.Up },
                    { (int)Jeu.DirectionType.Left, (int)Jeu.DirectionType.Down },
                    { (int)Jeu.DirectionType.RotLeft, (int)Jeu.DirectionType.Left },
                    { (int)Jeu.DirectionType.RotRight, (int)Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.west,
                new Dictionary<int, int>
                {
                    { (int)Jeu.DirectionType.Left, (int)Jeu.DirectionType.Up },
                    { (int)Jeu.DirectionType.Right, (int)Jeu.DirectionType.Down },
                    { (int)Jeu.DirectionType.RotLeft, (int)Jeu.DirectionType.Left },
                    { (int)Jeu.DirectionType.RotRight, (int)Jeu.DirectionType.Right }
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

            int direction = perso.myCase.directionTo(myCase);

            int absoluteDirection = getAbsoluteDirection(direction);
            int casesParcourues = 0;
            while (casesParcourues < 32)
            {
                int relativeDirection = getRelativeDirection(absoluteDirection);

                if (
                    perso.harponne.Count > 0
                    && perso.myCase.face != perso.myCase.nextCaseDirection(relativeDirection).face
                )
                    break;

                if (perso.canMoveDirection(relativeDirection))
                {
                    perso.moveDirection(relativeDirection, chargeDuTitan: true);
                    casesParcourues++;
                    if (perso.myCase.obstacleSpawn == (int)Jeu.PersoType.Piratitan)
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

    private int getRelativeDirection(int direction) // DONE
    {
        if (perso.myCase != null)
            return directionsAbsoluesToRelatives[perso.myCase.face][direction];
        return -1;
    }

    private int getAbsoluteDirection(int direction) // DONE
    {
        if (perso.myCase != null)
            return directionsAbsoluesToRelatives[perso.myCase.face]
                .FirstOrDefault(x => x.Value == direction)
                .Key;
        return -1;
    }
}
