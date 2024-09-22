using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBase : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public int key = 1;

    private bool checkpointActived = false;
    private string checkpointKey = "CheckpointKey";

    private void OnTriggerEnter(Collider other)
    {
        if(!checkpointActived && other.transform.tag == "Player")
        {
            CheckCheckpoint();
        }
    }

    private void CheckCheckpoint()
    {
        TurnItOn();
        SaveCheckpoint();
    }


    private void TurnItOn()
    {
        meshRenderer.material.SetColor("_EmissionColor", Color.white);
    }

    private void SaveCheckpoint()
    {
        /*if(PlayerPrefs.GetInt(checkpointKey, 0) > key)
        PlayerPrefs.SetInt(checkpointKey, key);*/

        CheckpointManager.Instance.SaveCheckPoint(key);
        checkpointActived = true;
    }

}
