using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void Load(int i)
    {
        SceneManager.LoadScene(i);
        Debug.Log("ENTROU NA FUN��O");
    }

    public void Load(string s)
    {
        SceneManager.LoadScene(s);
    }


}
