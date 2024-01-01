using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soda_detect : MonoBehaviour
{
    [SerializeField] soda_game soda_Game;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag  == "soda")
        {
            soda_Game.Soda++;
            gameObject.SetActive(false);
        }
    }
}
