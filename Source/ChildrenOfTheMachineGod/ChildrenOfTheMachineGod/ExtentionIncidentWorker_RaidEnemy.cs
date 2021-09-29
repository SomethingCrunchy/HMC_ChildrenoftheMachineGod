using RimWorld;
using Verse;

namespace ChildrenOfTheMachineGod
{
    public class ExtentionIncidentWorker_RaidEnemy : IncidentWorker_RaidEnemy
    {
        protected override bool TryExecuteWorker(IncidentParms parms)
        {
            Map map = (Map)parms.target;

            if (!base.TryExecuteWorker(parms))
            {
                return false;
            }
            Find.TickManager.slower.SignalForceNormalSpeedShort();
            Find.StoryWatcher.statsRecord.numRaidsEnemy++;
            if (MechFinder.AnyMechsOnMap(map))
            {
                IntVec3 intVec = CellFinderLoose.RandomCellWith((IntVec3 sq) => GenGrid.Standable(sq, map) && !map.roofGrid.Roofed(sq) && !map.fogGrid.IsFogged(sq), map, 1000);
                Thing thing = ThingMaker.MakeThing(ThingDefOfSong.CotMG_MusicTicker, null);
                GenSpawn.Spawn(thing, intVec, map, 0);
            }
            return true;
        }
    }
}
