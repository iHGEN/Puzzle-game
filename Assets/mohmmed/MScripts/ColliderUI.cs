using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallCollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI firstText;
    public TextMeshProUGUI secondText;
    public TextMeshProUGUI  thirdText;
    public TextMeshProUGUI  fourthText;
    public TextMeshProUGUI fifthText;
    public TextMeshProUGUI sixthText;

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("BallDetector"))
        {
            
            firstText.text = "7";
            secondText.text = "5";
            thirdText.text  = "9";
            fourthText.text = "2";
            fifthText.text = "1";
            sixthText.text = "3";
        }
    }
}
