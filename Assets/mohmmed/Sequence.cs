using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Sequence : MonoBehaviour
{
    public string[] buttonNames = new string [4];
    public string[] spotLightNames = new string[4];
    bool[] is_right = new bool[4];
    [SerializeField] ParticleSystem particle;
    [SerializeField] GameObject[] buttons;
    [SerializeField] GameObject[] _Socket;
    [SerializeField] GameObject[] _cables;
    Vector3[] _orginal;
    public bool submit_result;
    int num = 0;
    private void Start()
    {
        get_cables_locations();
    }
    void get_cables_locations()
    {
        _orginal = new Vector3[_cables.Length];
        for (int i = 0;i < _orginal.Length;i++)
        {
            _orginal[i] = _cables[i].transform.position;
        }
    }
    void check_win()
    {
       bool  final_submit = false;
        for(int i = 0; i < is_right.Length;i++)
        {
            if (!is_right[i])
            {
                final_submit = true;
                submit_result = false;
                break;
            }
        }
        if (!final_submit)
        {
            submit_result = true;
            particle.Play();
        }
    }
    void button_reset()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] != null)
            {
                _Socket[i].SetActive(false);
                _cables[i].transform.position = _orginal[i];

                buttons[i].SetActive(true);
                spotLightNames[i] = string.Empty;
                buttonNames[i] = string.Empty;
                _Socket[i].SetActive(true);
            }
        }
    }
    public void check_seq(GameObject gameObject)
    {
        if (num > spotLightNames.Length)
        {
            button_reset();
            num = 0;
            return;
        }
        buttonNames[num] = gameObject.name.Replace("Button","");
        if (spotLightNames[num].Contains(buttonNames[num]))
        {
            is_right[num] = true;
            gameObject.SetActive(false);
            check_win();
        }
        else
        {
            button_reset();
            num = 0;
            return;
        }
        num++;
    }
}
