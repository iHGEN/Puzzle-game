using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class color_mix : MonoBehaviour
{
    [SerializeField] GameObject[] _button;
    [SerializeField] Image[] _image;
    [SerializeField] TextMeshProUGUI _error_text;
    [SerializeField] GameObject _Canvas_Error;
    [SerializeField] TextMeshProUGUI _sub_text;
    [SerializeField] GameObject _start_button;
    float[] _color_rgb;
    int _random;
    int _button_id;
    int _alpha = 60;
    int _level = 1;
    void Start()
    {
        _color_rgb = new float[3];
    }

    public void change_color()
    {
        _start_button.SetActive(false);
        _sub_text.text = $"Level {_level}";
        _level++;
        _random = Random.Range(0, _button.Length);
        for (int color = 0; color < _color_rgb.Length; color++)
        {
            _color_rgb[color] = Random.Range(0, 255f) / 255f;
        }
        for (int i = 0; i < _button.Length; i++)
        {
            if(i == _random)
            {
                _button_id = _button[i].GetInstanceID();
            }
            _image[i].color = new Color(_color_rgb[0], _color_rgb[1], _color_rgb[2], i == _random ? _alpha / 255f : 255f / 255f);
        }
    }
    void _error_handel(string text)
    {
        _error_text.text = text;
        _Canvas_Error.SetActive(true);
    }
    public void _Error_result(bool isyes)
    {
        _alpha = 60;
        _level = 1;
        if (isyes)
        {
            change_color();
            _Canvas_Error.SetActive(false);
            return;
        }
        _sub_text.text = "Color Mix Game puzzle";
        _Canvas_Error.SetActive(false);
        _start_button.SetActive(true);
    }
    public void check_result(GameObject _object)
    {
        if (_button_id != _object.GetInstanceID())
        {
            _error_handel("Wrong Answer Do you Want to try again ?");
            return;
        }
        _alpha += 10;
        change_color();
    }
}
