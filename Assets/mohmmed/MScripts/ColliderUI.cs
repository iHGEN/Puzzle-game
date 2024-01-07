using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BallCollisionHandler : MonoBehaviour
{
    public ButtonSequenceDetector uibutton;
    Vector3 _ball_position;
    private void Start()
    {
        _ball_position = transform.position;
    }
    void OnCollisionEnter(Collision collision)
    {       
        if (collision.gameObject.CompareTag("BallDetector"))
        {
            uibutton.GenerateRandomSequence();
            transform.position = _ball_position;
        }
    }
}
