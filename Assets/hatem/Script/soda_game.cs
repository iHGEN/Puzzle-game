using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class soda_game : MonoBehaviour
{
    public int Soda = 0;
    public int _ball_count = 0;
    [SerializeField] coins _coins;
    [SerializeField] GameObject[] _ball;
    [SerializeField] GameObject[] _soda;
    [SerializeField] GameObject[] _all_object_to_reset;
    [SerializeField] GameObject menu_error;
    [SerializeField] TextMeshProUGUI menu_text;
    [SerializeField] GameObject _start_button;
    private Vector3[] _ball_location;
    private Vector3[] _soda_location;
    private Quaternion[] _quaternions;
    int alert_number = 0;
    void Start()
    {
        _ball_location = new Vector3[_ball.Length];
        _soda_location = new Vector3[_soda.Length];
        _quaternions = new Quaternion[_soda.Length];
        get_soda_ball_location();
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
            _quaternions[x] = _soda[x].transform.rotation;
        }
    }
    void Reset_all()
    {
        for (int i = 0; i < _ball.Length; i++)
        {
            _ball[i].GetComponent<Rigidbody>().isKinematic = true;
            _ball[i].transform.position = _ball_location[i];
            _ball[i].GetComponent<Rigidbody>().isKinematic = false;
        }
        for (int x = 0; x < _soda.Length; x++)
        {
            _soda[x].GetComponent<Rigidbody>().isKinematic = true;
            _soda[x].transform.position = _soda_location[x];
            _soda[x].transform.rotation = _quaternions[x];
            _soda[x].GetComponent<Rigidbody>().isKinematic = false;
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
        if (_coins.check_coins())
        {
            menu_error.SetActive(false);
            _coins.take_conis(1);
            Reset_all();
            Soda = 0;
            _ball_count = 0;
            return;
        }
        menu_mesg("There's not enough coins to play");
        _start_button.gameObject.SetActive(true);
        menu_error.SetActive(true);
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
        _start_button.gameObject.SetActive(false);
        menu_text.text = text;
    }
   public void opition_index(bool isyes)
    {
        Soda = 0;
        _ball_count = 0;
        switch (alert_number)
        {
            case 0:
                if (isyes)
                {
                    get_start();
                    return;
                }
                menu_mesg("baling tin Game");
                _start_button.gameObject.SetActive(true);
                menu_error.SetActive(true);
                break;
            case 1:
                if (isyes)
                {
                    get_start();
                    return;
                }
                menu_mesg("baling tin Game");
                _start_button.gameObject.SetActive(true);
                menu_error.SetActive(true);
                break;
        }
    }
    public async void check_for_win()
    {

        if(is_run_out_of_ball(_ball))
        {
            await Task.Delay(1500);
        }
        if (Soda != 6 & is_run_out_of_ball(_ball))
        {
            menu_mesg("You Lost \r\n\r\n do you want to try again ?");
            alert_number = 0;
            menu_error.SetActive(true);
            return;
        }
        if(Soda == 6)
        {
            _coins.add_coins(2);
            alert_number = 1;
            menu_mesg("You Win do you want to play agian ?");
            menu_error.SetActive(true);
        }
    }
}
