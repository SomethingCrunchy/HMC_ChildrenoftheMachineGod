using Verse;
using RimWorld;
using ChildrenOfTheMachineGod;


namespace Extension
{
    public static class ExtentionFactionManager
    {
        public static Faction OfNewMechanoids;
        public static Faction OfCotMG(this FactionManager fm) => OfNewMechanoids;
        static ExtentionFactionManager()
        {
            OfNewMechanoids = Find.FactionManager.FirstFactionOfDef(CotMG_FactionDefOf.ChildrenOfTheMachineGod);
        }
    }
    
}
