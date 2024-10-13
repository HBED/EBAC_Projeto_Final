using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveProcess : MonoBehaviour
{
    public void StartSave()
    {
        SaveManager.Instance.SaveGame();
    }
}
