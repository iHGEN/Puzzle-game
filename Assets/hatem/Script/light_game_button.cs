using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class light_game_button : MonoBehaviour
{
    [SerializeField] GameObject[] _button;
    [SerializeField] Image[] _image;
    [SerializeField] TextMeshProUGUI _error_text;
    [SerializeField] TextMeshProUGUI _light_game_text;
    [SerializeField] GameObject _Error_canvas;
    int _Alert_number = 0;
    int level_index = 1;
    Dictionary<int, int> seq_check = new();
    bool[] _is_choose;
    int index = 0;
    
    void Start()
    {
        _is_choose = new bool[_button.Length];
        start_level(level_index);
    }
    void disable_light(Image image)
    {
        image.color = Color.white;
    }
    void reset_level()
    {
        for(int i = 0; i < _is_choose.Length;i++)
        {
            _image[i].color = Color.white;
            _is_choose[i] = false;
        }
    }
    void button_interactable(bool is_enabled)
    {
        for (int i = 0; i < _is_choose.Length; i++)
        {
            _button[i].GetComponent<Button>().interactable = is_enabled;
        }
    }
    public async void start_level(int num)
    {
        int random = 0;
        seq_check.Clear();
        button_interactable(false);
        _light_game_text.text = $"Current Level {num}";
        for(int i = 0; i < 4 + num; i++)
        {
            start:
            random = Random.Range(0, _button.Length);
            if(_is_choose[random]) { goto start; }
            seq_check.Add(i, _button[random].GetInstanceID());
            _image[random].color = Color.red;
            await Task.Delay(1000);
            disable_light(_image[random]);
        }
        button_interactable(true);
    }
    public void _Alert_mes(string text)
    {
        _error_text.text = text;
        _Error_canvas.SetActive(true);
    }
    public void Alert_button(bool isyes)
    {
        index = 0;
        switch (_Alert_number)
        {
            case 1:
                if(isyes)
                {
                    start_level(level_index);
                    _Error_canvas.SetActive(false);
                    return;
                }
                _Error_canvas.SetActive(false);
                break;
            case 2:
                if(isyes)
                {
                    level_index++;
                    start_level(level_index);
                    _Error_canvas.SetActive(false);
                    return;
                }
                level_index = 1;
                start_level(level_index);
                _Error_canvas.SetActive(false);
                break;
        }
    }
    public void check_final(GameObject _object)
    {
        if (seq_check[index] != _object.GetInstanceID() || index > seq_check.Count)
        {
            reset_level();
            _light_game_text.text = string.Empty;
           _Alert_number = 1;
            _Alert_mes("Wrong Answer Do you want to try agian ?");
            return;
        }
        index++;
        if (index == seq_check.Count)
        {
            _light_game_text.text = string.Empty;
             reset_level();
            _Alert_number = 2;
            _Alert_mes("Congratulations You Win \r\ndo you want to go to the next level");
            return;
        }
    }
}
