using Verse;
using Extension;
using System.Linq;

namespace ChildrenOfTheMachineGod
{
    public static class MechFinder
    {
        public static bool AnyMechsOnMap(Map map)
        {
            return map.mapPawns.AllPawns.Any(pwn => pwn.Faction != null && pwn.Faction.def == ExtentionFactionManager.OfNewMechanoids.def && pwn.Spawned && !pwn.Downed);
        }

    }
}
