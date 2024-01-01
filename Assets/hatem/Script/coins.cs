using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class coins : MonoBehaviour
{
    // Start is called before the first frame update
    public int _coins;
    public int _current_coins;
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
    public void add_coins(int number)
    {
        _current_coins += number;
        _coins = _current_coins > _coins ? _current_coins : _coins;
        _coins_text.text = $"Coins : {_current_coins} / {_coins}";
    }
    public bool check_coins()
    {
        return _current_coins > 0;
    }
}

