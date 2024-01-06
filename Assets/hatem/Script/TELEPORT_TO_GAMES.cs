using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TELEPORT_TO_GAMES : MonoBehaviour
{
    [SerializeField] GameObject[] _Games_point;
    [SerializeField] GameObject[] _Games_section;
    [SerializeField] GameObject _player;
    [SerializeField] float _distance;
    public bool _is_player_teleport;
    
    void check_area()
    {
        for(int i = 0; i < _Games_point.Length;i++)
        {
            if(Vector3.Distance(_player.transform.position,_Games_section[i].transform.position) < _distance)
            {
                _is_player_teleport = true;
                _player.transform.position = new Vector3(_Games_point[i].transform.position.x, _Games_point[i].transform.position.y + 0.5f, _Games_point[i].transform.position.z);
            }
        }
    }
    public void go_to_first_area()
    {
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
