using UnityEngine;

namespace Kira
{
    public class PlayerDebug : MonoBehaviour
    {
        [SerializeField]
        private KeyCode debugViewToggleKey = KeyCode.V;

        private PlayerStats playerStats;
        private PopulationStats populationStats;

        private Stat moneyStat;
        private Stat popGrowthStat;
        private Stat popStat;

        private bool isDebugViewOn = true;

        private void Start()
        {
            playerStats = FindObjectOfType<PlayerStats>();
            populationStats = FindObjectOfType<PopulationStats>();
            moneyStat = playerStats.moneyStat;
            popGrowthStat = populationStats.populationGrowth;
            popStat = populationStats.populationCount;
        }

        private void Update()
        {
            if (Input.GetKeyDown(debugViewToggleKey))
            {
                isDebugViewOn = !isDebugViewOn;
            }
        }

        private void OnGUI()
        {
            if (!isDebugViewOn) return;
            Rect boxRect = new Rect(15, 15, 400, 200);
            GUI.Box(boxRect, "Debug Info");

            Rect populationRect = new Rect(boxRect.position, boxRect.size / 2);
            GUI.TextField(populationRect, $"Pop: {popStat.CurValue}");

            Rect popGrowthRect = populationRect;
            popGrowthRect.y -= popGrowthRect.height * 2f;

            GUI.TextField(populationRect, $"Pop Growth: {popGrowthStat.CurValue}");
        }

        public void AddMoney()
        {
            int amount = 1;

            bool isHoldingCtrl = Input.GetKey(KeyCode.LeftControl);
            bool isHoldingShift = Input.GetKey(KeyCode.LeftShift);
            bool isHoldingAlt = Input.GetKey(KeyCode.LeftAlt);

            // if holding alt, increase by 10,0000
            // if holding both ctrl and shift, increase money by 1000
            // If holding ctrl, increase money by 100
            // if holding shift, increase money by 10
            // otherwise increase by 1

            if (isHoldingAlt)
                amount = 10000;
            else if (isHoldingCtrl && isHoldingShift)
                amount = 1000;
            else if (isHoldingCtrl)
                amount = 100;
            else if (isHoldingShift)
                amount = 10;

            moneyStat.Add(amount);
        }
    }
}