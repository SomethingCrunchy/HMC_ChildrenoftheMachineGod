using RimWorld;
using Verse;
using ChildrenOfTheMachineGod;

namespace Extension
{
    public static class FactionExtention
    {
        public static Faction OfCotMG(this Faction f)
             => Find.FactionManager.FirstFactionOfDef(CotMG_FactionDefOf.ChildrenOfTheMachineGod);
    }
}
