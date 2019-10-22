using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RmedialOOP
{
    public enum BattleDomain { Air, Land, Sea}
    public interface FightingUnit
    {
        int Count { get; set; }
        BattleDomain Domain { get; }
    }

    public class AirSquadron : FightingUnit
    {
        public BattleDomain Domain => BattleDomain.Air;
        public int Count { get; set; }
    }

    public class TankUnit : FightingUnit
    {
        public BattleDomain Domain => BattleDomain.Land;
        public int Count { get; set; }
    }

    public abstract class Ship
    {
        public int CrewCount { get; protected set; }
    }

    public class Submarine : Ship
    {

    }

    public class Destroyer : Ship
    {

    }

    public class AircraftCarrier : Ship
    {

    }

    public class Fleet : List<FightingUnit>, FightingUnit
    {
        public BattleDomain Domain => BattleDomain.Sea;

        int FightingUnit.Count { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
