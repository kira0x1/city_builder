using TMPro;
using UnityEngine;

namespace Kira
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private KeyCode toggleUiKey = KeyCode.H;
        [SerializeField] private TextMeshProUGUI moneyText;
        [SerializeField] private CanvasGroup hudCanvas;

        private PlayerStats playerStats;
        private Stat moneyStat;
        private bool isUIVisible;

        private void Start()
        {
            playerStats = FindObjectOfType<PlayerStats>();
            moneyStat = playerStats.moneyStat;
            moneyStat.onValueChanged += OnMoneyChanged;
            RefreshMoneyText();
            ShowUI();
        }

        private void OnDisable()
        {
            if (moneyStat != null)
                moneyStat.onValueChanged -= OnMoneyChanged;
        }

        private void Update()
        {
            if (Input.GetKeyDown(toggleUiKey))
            {
                ToggleUI();
            }
        }

        private void RefreshMoneyText()
        {
            moneyText.text = moneyStat.CurValue.ToString("C0");
        }

        private void OnMoneyChanged(float prev, float cur)
        {
            RefreshMoneyText();
        }

        private void ToggleUI()
        {
            if (isUIVisible) HideUI();
            else ShowUI();
        }

        [ContextMenu("Show UI")]
        private void ShowUI()
        {
            hudCanvas.alpha = 1f;
            hudCanvas.interactable = true;
            hudCanvas.blocksRaycasts = true;
            isUIVisible = true;
        }

        [ContextMenu("Hide UI")]
        private void HideUI()
        {
            hudCanvas.alpha = 0f;
            hudCanvas.blocksRaycasts = false;
            hudCanvas.interactable = false;
            isUIVisible = false;
        }
    }
}