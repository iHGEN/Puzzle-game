using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading.Tasks;

public class coins : MonoBehaviour
{
    // Start is called before the first frame update
    public int _coins;
    public int _current_coins;
    [SerializeField] TELEPORT_TO_GAMES _teleport;
    [SerializeField] ParticleSystem _partical;
    [SerializeField] AudioClip _winsfx;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] int _wintime;
    [SerializeField] TextMeshProUGUI _coins_text;
    private void Start()
    {
        _current_coins = _coins;
        _coins_text.text = $"Coins : {_current_coins} / {_coins}";
    }
    public void take_conis(int number)
    {
        _current_coins -= number;
        _coins_text.text = $"Coins : {_current_coins} / {_coins}";
    }
    public async void add_coins(int number)
    {
        _current_coins += number;
        _coins = _current_coins > _coins ? _current_coins : _coins;
        _coins_text.text = $"Coins : {_current_coins} / {_coins}";
        _partical.transform.position = _teleport._partical_point[_teleport.get_pointnumber(_teleport._get_game_location)].transform.position;
        _audioSource.PlayOneShot(_winsfx, 0.3f);
        _partical.Play();
        await Task.Delay(_wintime * 1000);
        _partical.Stop();
    }
    public bool check_coins()
    {
        return _current_coins > 0;
    }
}

