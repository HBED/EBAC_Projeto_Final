using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Itens
{
    public class ItemLayout : MonoBehaviour
    {
        private ItemSetup _currSetup;

        public Image uiIcon;
        public TextMeshProUGUI uiValue;
        public TextMeshProUGUI uiUseKey;

        public void Load(ItemSetup setup)
        {
            _currSetup = setup;
            UpdateUI();
        }


        private void UpdateUI()
        {
            uiIcon.sprite = _currSetup.icon;
            uiUseKey.text = _currSetup.useKey;
        }

        // É mais eficiente usar CALLBACKS
        private void Update()
        {
            uiValue.text = _currSetup.soInt.value.ToString();
        }
    }
}


