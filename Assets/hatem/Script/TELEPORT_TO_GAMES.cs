using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TELEPORT_TO_GAMES : MonoBehaviour
{
    public GameObject[] _partical_point;
    [SerializeField] GameObject[] _Games_point;
    [SerializeField] GameObject[] _Games_section;
    [SerializeField] AudioClip[] _audioclip;
    [SerializeField] AudioSource _audiosource;
    [SerializeField] GameObject _player;
    [SerializeField] float _distance;
    public bool[] _get_game_location;
    public bool _is_player_teleport;
    private void Start()
    {
        _get_game_location = new bool[_Games_section.Length];
    }

    void check_area()
    {
        for(int i = 0; i < _Games_point.Length;i++)
        {
            if(Vector3.Distance(_player.transform.position,_Games_section[i].transform.position) < _distance)
            {
                _get_game_location[i] = true;
                _audiosource.PlayOneShot(_audioclip[i], 0.7f);
                _is_player_teleport = true;
                _player.transform.position = new Vector3(_Games_point[i].transform.position.x, _Games_point[i].transform.position.y + 0.5f, _Games_point[i].transform.position.z);
            }
        }
    }
    public int get_pointnumber(bool[] _check_locAation)
    {
        int result = 0;
        for(int i = 0; i < _check_locAation.Length;i++)
        {
            if (_check_locAation[i])
            {
                result = i;
                break;
            }
        }
        return result;
    }
    public void go_to_first_area()
    {
        for(int i = 0; i < _Games_section.Length;i++)
        {
            if(_get_game_location[i])
            {
                _get_game_location[i] = false;
            }
        }
        _player.transform.position = transform.position;
        _is_player_teleport = false;
    }
    void Update()
    {
        if(!_is_player_teleport)
        {
            check_area();
        }
    }
}
