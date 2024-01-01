using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soda_detect : MonoBehaviour
{
    [SerializeField] soda_game soda_Game;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag  == "groung_ball_soda" && this.gameObject.tag == "soda")
        {
            gameObject.SetActive(false);
            soda_Game.Soda++;
            soda_Game.check_for_win();
        }
        if (collision.gameObject.tag == "groung_ball_soda" && this.gameObject.tag == "ball")
        {
            gameObject.SetActive(false);
            soda_Game._ball_count++;
            soda_Game.check_for_win();
        }
    }
}
