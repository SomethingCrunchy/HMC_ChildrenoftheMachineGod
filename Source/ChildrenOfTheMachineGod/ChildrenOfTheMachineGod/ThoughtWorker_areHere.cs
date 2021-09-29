using RimWorld;
using Verse;

namespace ChildrenOfTheMachineGod
{
    public class ThoughtWorker_CotMG_areHere : ThoughtWorker
    {
        protected override ThoughtState CurrentStateInternal(Pawn p)
        {
            return MechFinder.AnyMechsOnMap(p.Map);
        }
    }
}