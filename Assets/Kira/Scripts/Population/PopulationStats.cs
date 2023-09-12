using UnityEngine;

namespace Kira
{
    public class PopulationStats : MonoBehaviour
    {
        public readonly Stat populationCount = new Stat("Population Count", 10, 1000, "How many people in your city :p");
        public readonly Stat populationGrowth = new Stat("Population Growth", 6.5f, 100f, "How fast your population grows");
    }
}