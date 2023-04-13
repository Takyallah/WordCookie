using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    public List<GameObject> Words;
    public List<string> possibleWords; // List of possible words to be guessed
    public List<string> completedWords; // List of completed words
    public List<Button> letterButtons; // List of letter buttons
    public Button submitButton; // Button for submitting the input
    public string successMessage = "Success!"; // Success message to be displayed in the log
    public string alreadyUsedMessage = "Already used!"; // Already used message to be displayed in the log
    public string wrongSpellingMessage = "Wrong spelling!"; // Wrong spelling message to be displayed in the log

    public string currentInput = ""; // Current input string

    // Start is called before the first frame update
    void Start()
    {
        possibleWords.Add("ICE");
        possibleWords.Add("LIE");
        possibleWords.Add("LIP");
        possibleWords.Add("PEN");
        possibleWords.Add("PIE");
        possibleWords.Add("PIN");

        possibleWords.Add("CLIP");
        possibleWords.Add("EPIC");
        possibleWords.Add("LINE");
        possibleWords.Add("NICE");
        possibleWords.Add("PILE");
        possibleWords.Add("PINE");

        possibleWords.Add("CLINE");

        possibleWords.Add("PENCIL");

        submitButton.onClick.AddListener(OnSubmitButtonClick);

        foreach (Button letterButton in letterButtons)
        {
            letterButton.onClick.AddListener(() => OnLetterButtonClick(letterButton));
        }
        foreach (GameObject word in Words)
        {
            word.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Method called when submit button is clicked
    void OnSubmitButtonClick()
    {
        // Check if the current input matches any of the possible words
        if (possibleWords.Contains(currentInput))
        {
            // Check if the word has already been completed
            if (!completedWords.Contains(currentInput))
            {
                // Log success and move the word to the completed list
                Debug.Log(successMessage);
                completedWords.Add(currentInput);
                possibleWords.Remove(currentInput);
                foreach (GameObject word in Words)
                {
                    if(word.name == currentInput) word.SetActive(true);
                }
            }
            else
            {
                // Log already used message
                Debug.Log(alreadyUsedMessage);
            }
        }
        else
        {
            // Log wrong spelling message
            Debug.Log(wrongSpellingMessage);
        }

        // Reset the current input after submitting
        currentInput = "";
    }

    // Method called when a letter button is clicked
    void OnLetterButtonClick(Button letterButton)
    {
        // Check if the current input length is less than the size of the longest word
        if (currentInput.Length < GetMaxWordLength())
        {
            // Append the clicked letter to the current input
            currentInput += letterButton.GetComponentInChildren<Text>().text;

            Debug.Log(currentInput);
        }
        else 
        {
            OnSubmitButtonClick();
        }
    }

    // Get the maximum word length from the list of possible words
    int GetMaxWordLength()
    {
        int maxWordLength = 0;
        foreach (string word in possibleWords)
        {
            if (word.Length > maxWordLength)
            {
                maxWordLength = word.Length;
            }
        }
        return maxWordLength;
    }
}