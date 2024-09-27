using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUIBoolUpdate : MonoBehaviour
{
    public SOBool soBool;
    public TextMeshProUGUI uiTextValue;

    private void FixedUpdate()
    {
        uiTextValue.text = soBool.value.ToString();
    }
}
