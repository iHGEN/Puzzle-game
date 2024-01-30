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
    [SerializeField] private TextMeshProUGUI errorText;
    [SerializeField] private TextMeshProUGUI lightGameText;
    [SerializeField] private GameObject errorCanvas;
    [SerializeField] private GameObject startButton;

    private int alertNumber = 0;
    private int levelIndex = 1;
    private int[] sequenceCheck;
    private bool[] isChosen;
    private int currentIndex = 0;

    void Start()
    {
        isChosen = new bool[buttons.Length];
        SetButtonInteractable(false);
    }

    public void GetStart()
    {
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
        sequenceCheck = new int[maxSequenceLength];
        List<int> usedIndices = new List<int>();

        for (int i = 0; i < maxSequenceLength; i++)
        {
            int randomIndex;
            do
            {
                randomIndex = Random.Range(0, buttons.Length);
            } while (usedIndices.Contains(randomIndex));
            usedIndices.Add(randomIndex);
            sequenceCheck[i] = buttons[randomIndex].GetInstanceID();
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

    public void CheckFinal(GameObject selectedObject)
    {
        if (sequenceCheck[currentIndex] != selectedObject.GetInstanceID() || currentIndex >= sequenceCheck.Length)
        {
            ResetLevel();
            lightGameText.text = string.Empty;
            alertNumber = 1;
            AlertMessage("Wrong Answer. Do you want to try again?");
            return;
        }

        currentIndex++;

        if (currentIndex == sequenceCheck.Length)
        {
            lightGameText.text = string.Empty;
            ResetLevel();
            alertNumber = 2;
            _coins.add_coins(2);
            AlertMessage("Congratulations! You win.\nDo you want to go to the next level?");
        }
    }
}
