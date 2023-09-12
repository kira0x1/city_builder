using System;

namespace Kira
{
    public class Stat
    {
        private readonly string displayName;
        private string toolTip;
        private float curValue;
        private readonly float maxValue;
        public string DisplayName => displayName;
        public float CurValue => curValue;
        public float MaxValue => maxValue;

        public delegate void OnValueChanged(float prev, float cur);
        public OnValueChanged onValueChanged;

        public Stat(string displayName, float curValue, float maxValue = 1000, string toolTip = "")
        {
            this.displayName = displayName;
            this.curValue = curValue;
            this.maxValue = maxValue;
            this.toolTip = toolTip;
        }

        public void Add(float amount)
        {
            float prev = curValue;
            if (curValue + amount > maxValue) curValue = maxValue;
            else curValue += amount;

            if (Math.Abs(prev - curValue) > 0.01f)
            {
                onValueChanged?.Invoke(prev, curValue);
            }
        }
    }
}