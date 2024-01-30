using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading.Tasks;

public class LightGameButton : MonoBehaviour
{
    [SerializeField] private coins _coins;
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private Image[] images;
    [SerializeField] private TextMeshProUGUI[] textbutton;
    [SerializeField] private TextMeshProUGUI errorText;
    [SerializeField] private TextMeshProUGUI lightGameText;
    [SerializeField] private GameObject errorCanvas;
    [SerializeField] private GameObject startButton;

    private int alertNumber = 0;
    private int levelIndex = 1;
    private bool[] isChosen;
    private int currentIndex = 0;

    private Dictionary<int, int> sequenceCheck = new();

    void Start()
    {
        isChosen = new bool[buttons.Length];
        SetButtonInteractable(false);
    }

    public void GetStart()
    {
        DisableAllLight(images);
        if(sequenceCheck.Count > 0)
        {
            sequenceCheck.Clear();
        }
        if (_coins.check_coins())
        {
            _coins.take_conis(1);
            errorCanvas.SetActive(false);
            SetButtonInteractable(true);
            StartLevel(levelIndex);
            return;
        }
        lightGameText.text = "Light Game puzzle";
        levelIndex = 1;
        startButton.SetActive(true);
        SetButtonInteractable(false);
        AlertMessage("There's not enough coins to play");
    }

    private void DisableLight(Image image)
    {
        image.color = Color.white;
    }
    private void DisableAllLight(Image[] image)
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = Color.white;
            textbutton[i].text = string.Empty;
        }
    }
    private void ResetLevel()
    {
        for (int i = 0; i < isChosen.Length; i++)
        {
            images[i].color = Color.white;
            isChosen[i] = false;
        }
    }

    private void SetButtonInteractable(bool isEnabled)
    {
        foreach (var button in buttons)
        {
            button.GetComponent<Button>().interactable = isEnabled;
        }
    }

    public async void StartLevel(int level)
    {
        SetButtonInteractable(false);
        lightGameText.text = $"Current Level {level}";
        int maxSequenceLength = 4 + level;
        List<int> usedIndices = new List<int>();

        for (int i = 0; i < maxSequenceLength; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, buttons.Length);
            } while (usedIndices.Contains(randomIndex));
            usedIndices.Add(randomIndex);
            sequenceCheck.Add(i, buttons[randomIndex].GetInstanceID());
            images[randomIndex].color = Color.red;
            await Task.Delay(1000);
            DisableLight(images[randomIndex]);
        }
        usedIndices.Clear();
        SetButtonInteractable(true);
    }

    public void AlertMessage(string text)
    {
        errorText.text = text;
        errorCanvas.SetActive(true);
    }

    public void AlertButton(bool isYes)
    {
        currentIndex = 0;
        SetButtonInteractable(false);

        switch (alertNumber)
        {
            case 1:
                if (isYes)
                {
                    GetStart();
                }
                else
                {
                    ResetToInitialStage();
                }
                break;
            case 2:
                if (isYes)
                {
                    levelIndex++;
                    GetStart();
                }
                else
                {
                    ResetToInitialStage();
                }
                break;
        }
        errorCanvas.SetActive(false);
    }

    private void ResetToInitialStage()
    {
        lightGameText.text = "Light Game puzzle";
        startButton.SetActive(true);
        levelIndex = 1;
    }
    void GetRightAnswer()
    {
        for(int i = 0; i < sequenceCheck.Count;i++)
        {
            for (int x = 0; x < buttons.Length; x++)
            {
                if (sequenceCheck[i] == buttons[x].GetInstanceID())
                {
                    images[x].color = Color.green;
                    textbutton[x].text = $"{i + 1}";
                    break;
                }
            }
        }
    }
    public void CheckFinal(GameObject selectedObject)
    {
        if (sequenceCheck[currentIndex] != selectedObject.GetInstanceID() || currentIndex >= sequenceCheck.Count)
        {
            ResetLevel();
            lightGameText.text = string.Empty;
            alertNumber = 1;
            AlertMessage("Wrong Answer. Do you want to try again?");
            GetRightAnswer();
            return;
        }

        currentIndex++;

        if (currentIndex == sequenceCheck.Count)
        {
            lightGameText.text = string.Empty;
            ResetLevel();
            alertNumber = 2;
            _coins.add_coins(2);
            AlertMessage("Congratulations! You win.\nDo you want to go to the next level?");
        }
    }
}
