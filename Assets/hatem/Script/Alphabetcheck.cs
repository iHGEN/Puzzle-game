using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class Alphabetcheck : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Light _light;
    [SerializeField] XRSocketInteractor _Socket;
    [SerializeField] string[] _answer;
    [SerializeField] string[] _question;
    [SerializeField] GameObject[] _letter;
    [SerializeField] GameObject _spawon_point;
    [SerializeField] TextMeshProUGUI _question_text;
    [SerializeField] TextMeshProUGUI _answer_text;
    string _final_answer;
    string _right_answer;
    bool _is_final_answer_complete;
    GameObject _prefab;
    bool[] _is_spawon;
    int _random_number = 0;
    int _question_answer_number;
    void Start()
    {
        _question_answer_number = Random.Range(0, _question.Length);
        _answer_text.text = string.Empty;
        generate_question(_question[_question_answer_number]);
        _right_answer = _answer[_question_answer_number].ToUpper();
        generate_answer(_answer[_question_answer_number]);
    }
   public  void rest(bool is_full_reset)
    {
        _final_answer = string.Empty;
        for (int i = 0; i < _is_spawon.Length;i++)
        {
            _is_spawon[i] = false;
        }
        if (is_full_reset)
        {
            _is_final_answer_complete = false;
            for (int i = 0; i < _letter.Length; i++)
            {
                Destroy(_letter[i]);
            }
            _answer_text.text = string.Empty;
            generate_answer(_answer[_question_answer_number]);
        }
        Resources.UnloadUnusedAssets();
    }
    void generate_question(string question)
    {
        _question_text.text = question;
    }
    void generate_answer(string answer)
    {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        _letter = new GameObject[answer.Length * 2];
        _is_spawon = new bool[answer.Length * 2];
        char[] letter = answer.ToUpper().ToCharArray();
        char[] charalphabet = alphabet.ToCharArray();
        _is_final_answer_complete = true;
        for (int i = 0; i < letter.Length; i++)
        {
            if (i == _question_answer_number)
            {
                for (int x = letter.Length; x < letter.Length * 2; x++)
                {
                    _random_number = Random.Range(0, charalphabet.Length);
                    _prefab = Resources.Load<GameObject>($"BuildingRoomPrefabPacks/AlphabetAndNumbers/{charalphabet[_random_number]}");
                    _letter[x] = Instantiate(_prefab, new Vector3(_spawon_point.transform.position.x / _spawon_point.transform.position.x * x * 2.5f, _spawon_point.transform.position.y, _spawon_point.transform.position.z), Quaternion.identity);
                    _is_spawon[x] = true;
                }
            }
        start:
            _random_number = Random.Range(0, answer.Length);
            if (_is_spawon[_random_number]) { goto start; }
            _prefab = Resources.Load<GameObject>($"BuildingRoomPrefabPacks/AlphabetAndNumbers/{letter[_random_number]}");
            _letter[i] = Instantiate(_prefab, new Vector3(_spawon_point.transform.position.x / _spawon_point.transform.position.x * i * 2.5f, _spawon_point.transform.position.y, _spawon_point.transform.position.z), Quaternion.identity);
            _is_spawon[_random_number] = true;
        }
        rest(false);
    }
    void check_answer(bool is_right)
    {
        _light.color = is_right ? Color.green : Color.red;
    }
    public void change_the_question()
    {
        _question_answer_number = Random.Range(0, _question.Length);
        rest(true);
        _answer_text.text = string.Empty;
        generate_question(_question[_question_answer_number]);
        _right_answer = _answer[_question_answer_number].ToUpper();
    }
    // Update is called once per frame
    void Update()
    {
        if(_Socket.hasSelection)
        {
            IXRSelectInteractable _object = _Socket.GetOldestInteractableSelected();
            _final_answer += _object.transform.gameObject.name.Replace("(Clone)",string.Empty);
            _answer_text.text += _object.transform.gameObject.name.Replace("(Clone)", string.Empty);
            Destroy(_object.transform.gameObject);
        }
        if(_final_answer !=null && _is_final_answer_complete && _final_answer.Length == _right_answer.Length)
        {
            _is_final_answer_complete = false;
            check_answer(_final_answer == _right_answer);
        }
    }
}
