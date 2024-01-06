using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_man : MonoBehaviour
{
    public void Reset_scene(int scennumber)
    {
        SceneManager.LoadScene(scennumber);
    }
}
