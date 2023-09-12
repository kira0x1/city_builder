using UnityEngine;

namespace Kira
{
    public class PlayerStats : MonoBehaviour
    {
        public readonly Stat moneyStat = new Stat("Money", 1000, 9999999, "money you have, you can use this to buy things :3");

        private void Start()
        {
            if (moneyStat != null)
                moneyStat.onValueChanged += OnMoneyChanged;
        }

        private void OnDisable()
        {
            if (moneyStat != null)
                moneyStat.onValueChanged -= OnMoneyChanged;
        }

        private void OnMoneyChanged(float prev, float cur)
        {
        }
    }
}