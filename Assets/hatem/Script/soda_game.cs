using UnityEngine;
using TMPro;

public class soda_game : MonoBehaviour
{
    public int Soda = 0;
    public int _ball_count = 0;
    [SerializeField] GameObject[] _ball;
    [SerializeField] GameObject[] _soda;
    [SerializeField] GameObject[] _all_object_to_reset;
    [SerializeField] GameObject menu_error;
    [SerializeField] TextMeshProUGUI menu_text;
    private Vector3[] _ball_location;
    private Vector3[] _soda_location;
    void Start()
    {
        _ball_location = new Vector3[_ball.Length];
        _soda_location = new Vector3[_soda.Length];
    }
    void get_soda_ball_location()
    {
        for(int i = 0; i < _ball.Length;i++)
        {
            _ball_location[i] = _ball[i].transform.position;
        }
        for (int x = 0; x < _soda.Length; x++)
        {
            _soda_location[x] = _soda[x].transform.position;
        }
    }
    void Reset_all()
    {
        for (int i = 0; i < _ball.Length; i++)
        {
            _ball[i].transform.position = _ball_location[i];
        }
        for (int x = 0; x < _soda.Length; x++)
        {
            _soda[x].transform.position = _soda_location[x];
        }
        for(int c = 0; c < _all_object_to_reset.Length;c++)
        {
            if(!_all_object_to_reset[c].activeInHierarchy)
            {
                _all_object_to_reset[c].SetActive(true);
            }
        }
    }
    public void get_start()
    {
        Reset_all();
    }
    bool is_run_out_of_ball(GameObject[] ball)
    {
        for(int i = 0; i < ball.Length;i++)
        {
            if (ball[i].activeInHierarchy)
            {
                return false;
            }
        }
        return true;
    }
    public void Game_over(bool tryagain)
    {
        if(tryagain)
        {
            Reset_all();
            menu_error.SetActive(false);
            return;
        }
        menu_error.SetActive(false);
    }
    public void menu_mesg(string text)
    {
        menu_text.text = text;
    }
    public void check_for_win()
    {
        if (Soda != 6 && is_run_out_of_ball(_ball))
        {
            menu_mesg("You Lost \r\n\r\n do you want to try again ?");
            menu_error.SetActive(true);
            return;
        }
        if(Soda == 6)
        {
            menu_mesg("You Win");
            menu_error.SetActive(true);
        }
    }
}
