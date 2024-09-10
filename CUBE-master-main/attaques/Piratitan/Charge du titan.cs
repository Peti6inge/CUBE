public class ChargeDuTitan : Attaque
{
    // Attributs // DONE
    private Dictionary<
        Face,
        Dictionary<Jeu.DirectionType, Jeu.DirectionType>
    > directionsAbsoluesToRelatives;

    // Constructeur // DONE
    public ChargeDuTitan(Perso perso)
        : base(perso)
    {
        cout = 3;
        porteeMin = 1;
        porteeMax = 1;
        typeCible = Jeu.CibleType.chargeDuTitan;
        directionsAbsoluesToRelatives = new Dictionary<
            Face,
            Dictionary<Jeu.DirectionType, Jeu.DirectionType>
        >()
        {
            {
                Jeu.host,
                new Dictionary<Jeu.DirectionType, Jeu.DirectionType>
                {
                    { Jeu.DirectionType.Up, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.Down, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.Left, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.Right, Jeu.DirectionType.Right },
                    { Jeu.DirectionType.RotLeft, Jeu.DirectionType.RotLeft },
                    { Jeu.DirectionType.RotRight, Jeu.DirectionType.RotRight }
                }
            },
            {
                Jeu.client,
                new Dictionary<Jeu.DirectionType, Jeu.DirectionType>
                {
                    { Jeu.DirectionType.Up, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.Down, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.Left, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.Right, Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.north,
                new Dictionary<Jeu.DirectionType, Jeu.DirectionType>
                {
                    { Jeu.DirectionType.Up, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.Down, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.RotLeft, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.RotRight, Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.south,
                new Dictionary<Jeu.DirectionType, Jeu.DirectionType>
                {
                    { Jeu.DirectionType.Up, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.Down, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.RotLeft, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.RotRight, Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.east,
                new Dictionary<Jeu.DirectionType, Jeu.DirectionType>
                {
                    { Jeu.DirectionType.Right, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.Left, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.RotLeft, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.RotRight, Jeu.DirectionType.Right }
                }
            },
            {
                Jeu.west,
                new Dictionary<Jeu.DirectionType, Jeu.DirectionType>
                {
                    { Jeu.DirectionType.Left, Jeu.DirectionType.Up },
                    { Jeu.DirectionType.Right, Jeu.DirectionType.Down },
                    { Jeu.DirectionType.RotLeft, Jeu.DirectionType.Left },
                    { Jeu.DirectionType.RotRight, Jeu.DirectionType.Right }
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

            Jeu.DirectionType direction = perso.myCase.directionTo(myCase);

            Jeu.DirectionType absoluteDirection = getAbsoluteDirection(direction);
            int casesParcourues = 0;
            while (casesParcourues < 32)
            {
                Jeu.DirectionType relativeDirection = getRelativeDirection(absoluteDirection);

                if (
                    perso.harponne.Count > 0
                    && perso.myCase.face != perso.myCase.nextCaseDirection(relativeDirection).face
                )
                    break;

                if (perso.canMoveDirection(relativeDirection))
                {
                    if (
                        perso.moveDirection(relativeDirection, chargeDuTitan: true)
                        == Jeu.EtatType.ko
                    )
                        break;
                    casesParcourues++;
                    if (perso.myCase.obstacleSpawn == Jeu.SpawnType.Piratitan)
                        break;
                }
                else
                {
                    Object? obstacleRencontre = perso.nextObstacleDirection(relativeDirection);
                    if (obstacleRencontre != null)
                        perso.infligeDegats(casesParcourues / 2, obstacleRencontre);

                    perso.recoitDegats(casesParcourues);
                    break;
                }
            }
        }
    }

    // Méthodes privées

    private Jeu.DirectionType getRelativeDirection(Jeu.DirectionType direction) // DONE
    {
        if (perso.myCase != null)
            return directionsAbsoluesToRelatives[perso.myCase.face][direction];
        return Jeu.DirectionType.none;
    }

    private Jeu.DirectionType getAbsoluteDirection(Jeu.DirectionType direction) // DONE
    {
        if (perso.myCase != null)
            return directionsAbsoluesToRelatives[perso.myCase.face]
                .FirstOrDefault(x => x.Value == direction)
                .Key;
        return Jeu.DirectionType.none;
    }
}
