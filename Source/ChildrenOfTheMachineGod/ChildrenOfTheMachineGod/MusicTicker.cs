using System.Reflection;
using RimWorld;
using Verse;

namespace ChildrenOfTheMachineGod
{
    class CotMG_MusicTicker : Building
    {
        private int musicticker = 0;

        private int tickcheker = 6780;

        public static readonly FieldInfo lastStartedSongInfo = typeof(MusicManagerPlay).GetField("lastStartedSong", BindingFlags.Instance | BindingFlags.NonPublic);
        public override void SpawnSetup(Map map, bool respawningAfterLoad)
        {
            base.SpawnSetup(map, respawningAfterLoad);
        }
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look<int>(ref this.musicticker, "musicticker", 0, false);
            Scribe_Values.Look<int>(ref this.tickcheker, "tickcheker", 6780, false);
        }
        public override void Tick()
        {
            base.Tick();
            if (this.musicticker == 0)
            {
                Find.MusicManagerPlay.ForceStartSong(CotMG_SongDefOf.CotMG_areHere, false);
                this.musicticker++;
            }
            if (this.musicticker == this.tickcheker)
            {
                if (MechFinder.AnyMechsOnMap(this.Map))
                {
                    this.tickcheker += 6780;
                    Find.MusicManagerPlay.ForceStartSong(CotMG_SongDefOf.CotMG_areHere, false);
                }
                else
                {
                 this.Destroy(0);
                }
            }
        }
    }
}
