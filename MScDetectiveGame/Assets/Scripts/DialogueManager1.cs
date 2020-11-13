using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Reference for this code: (Adapted from) Alex (2 Nov 2019) Speech Bubble and Dialogue System Unity Tutorial Parts 1, 2 & 3. Available at: https://www.youtube.com/watch?v=p_d2ugJ3FRg. Accessed June 2020.

public class DialogueManager1 : MonoBehaviour
{
    [SerializeField] private float typingSpeed = 0.0f;

    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI speechBubbleText;

    [Header("Cotinue Buttons")]
    [SerializeField] private GameObject speechBubbleContinueButton;

    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] speechBubbleSentences;

    private bool dialogueStarted;

    public GameObject OfficeTourCanvas;
    public GameObject DCIJane;
    public GameObject ToNavigationTour;

    private int speechBubbleIndex;

    // Start is called before the first frame update
    private void Start()
    {
        ToNavigationTour.SetActive(false);
        startDialogue();
    }

    public void startDialogue()
    {
        StartCoroutine(TypeSpeechBubbleDialogue());

    }

    private IEnumerator TypeSpeechBubbleDialogue()
    {
        foreach (char letter in speechBubbleSentences[speechBubbleIndex].ToCharArray())
        {
            speechBubbleText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        speechBubbleContinueButton.SetActive(true);

    }

    public void ContinueSpeechBubbleDialogue()
    {
        speechBubbleContinueButton.SetActive(false);
        speechBubbleText.text = string.Empty;

        if (speechBubbleIndex >= speechBubbleSentences.Length - 1)
        {
            speechBubbleText.text = string.Empty;
            OfficeTourCanvas.SetActive(false);
            DCIJane.SetActive(false);
            ToNavigationTour.SetActive(true);
        }
        else
        {
            if (speechBubbleIndex < speechBubbleSentences.Length - 1)
            {
                if (dialogueStarted)
                    speechBubbleIndex++;
                else
                    dialogueStarted = true;

                speechBubbleText.text = string.Empty;
                StartCoroutine(TypeSpeechBubbleDialogue());
            }
        }
    }


}
