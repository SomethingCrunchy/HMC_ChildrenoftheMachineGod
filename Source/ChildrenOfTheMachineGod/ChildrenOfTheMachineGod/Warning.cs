using RimWorld;
using Verse;

namespace ChildrenOfTheMachineGod
{
	public class CotMG_LetterTracker : MapComponent
	{
		public CotMG_LetterTracker(Map map) : base(map)
		{
		}
		public override void MapComponentTick()
		{
			base.MapComponentTick();
			bool flag = !CotMG_LetterTracker.CotMG_sentWarning && (float)GenDate.DaysPassed >= Find.FactionManager.FirstFactionOfDef(CotMG_FactionDefOf.ChildrenOfTheMachineGod).def.earliestRaidDays * 0.9f;
			if (flag)
			{
				Pawn pawn = (Find.AnyPlayerHomeMap.mapPawns.FreeColonistsSpawnedCount != 0) ? GenCollection.RandomElement<Pawn>(Find.AnyPlayerHomeMap.mapPawns.FreeColonistsSpawned) : GenCollection.RandomElement<Pawn>(PawnsFinder.AllMapsCaravansAndTravelingTransportPods_Alive_Colonists);
				TaggedString taggedString = Translator.Translate("CotMG_WarningLabel");
				TaggedString taggedString2 = TranslatorFormattedStringExtensions.Translate("CotMG_WarningText");
				Find.LetterStack.ReceiveLetter(taggedString, taggedString2, LetterDefOf.NegativeEvent, null);
				CotMG_LetterTracker.CotMG_sentWarning = true;
			}
		}
		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look<bool>(ref CotMG_LetterTracker.CotMG_sentWarning, "sentMechWarning", false, false);
		}
		private static bool CotMG_sentWarning;
	}
}