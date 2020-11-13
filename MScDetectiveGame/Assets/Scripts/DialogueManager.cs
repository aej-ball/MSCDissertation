using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Reference for this code: Alex (2 Nov 2019) Speech Bubble and Dialogue System Unity Tutorial Parts 1, 2 & 3. Available at: https://www.youtube.com/watch?v=p_d2ugJ3FRg. Accessed June 2020.

public class DialogueManager : MonoBehaviour
{

    [SerializeField] private float typingSpeed = 0.0f;

    [SerializeField] private bool Bubble1SpeakingFirst;

    [Header("Dialogue TMP text")]
    [SerializeField] private TextMeshProUGUI speechBubble1Text;
    [SerializeField] private TextMeshProUGUI speechBubble2Text;

    [Header("Cotinue Buttons")]
    [SerializeField] private GameObject speechBubble1ContinueButton;
    [SerializeField] private GameObject speechBubble2ContinueButton;

    [Header("Dialogue Sentences")]
    [TextArea]
    [SerializeField] private string[] speechBubble1Sentences;
    [TextArea]
    [SerializeField] private string[] speechBubble2Sentences;

    private bool dialogueStarted;

   

    private int speechBubble1Index;
    private int speechBubble2Index;

    public GameObject ToOffice;

    private void Start()
    {
        ToOffice.SetActive(false);
        startDialogue();
    }

    public void startDialogue()
    {
        if (Bubble1SpeakingFirst)
        {
            StartCoroutine(TypeSpeechBubble1Dialogue());
        }
        else
        {
            StartCoroutine(TypeSpeechBubble2Dialogue());
        }

    }

    private IEnumerator TypeSpeechBubble1Dialogue()
    {
        foreach (char letter in speechBubble1Sentences[speechBubble1Index].ToCharArray())
        {
            speechBubble1Text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        speechBubble1ContinueButton.SetActive(true);
        
    }

    private IEnumerator TypeSpeechBubble2Dialogue()
    {
        foreach (char letter in speechBubble2Sentences[speechBubble2Index].ToCharArray())
        {
            speechBubble2Text.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        speechBubble2ContinueButton.SetActive(true);

    }

    public void ContinueSpeechBuuble1Dialogue()
    {
        speechBubble2ContinueButton.SetActive(false);
        speechBubble2Text.text = string.Empty;
        speechBubble1Text.text = string.Empty;

        if (speechBubble1Index >= speechBubble1Sentences.Length - 1)
        {
            speechBubble2Text.text = string.Empty;
            ToOffice.SetActive(true);
        }
        else
        {
            if (speechBubble1Index < speechBubble1Sentences.Length - 1)
            {
                if (dialogueStarted)
                    speechBubble1Index++;
                else
                    dialogueStarted = true;

                speechBubble1Text.text = string.Empty;
                StartCoroutine(TypeSpeechBubble1Dialogue());
            }
        }
    }

    public void ContinueSpeechBubble2Dialogue()
    {
        speechBubble1ContinueButton.SetActive(false);
        speechBubble1Text.text = string.Empty;
        speechBubble2Text.text = string.Empty;

        if (speechBubble2Index >= speechBubble2Sentences.Length -1)
        {
            speechBubble1Text.text = string.Empty;
            ToOffice.SetActive(true);
        }
        else
        {
            if (speechBubble2Index < speechBubble2Sentences.Length - 1)
            {
                if (dialogueStarted)
                    speechBubble2Index++;
                else
                    dialogueStarted = true;

                speechBubble2Text.text = string.Empty;
                StartCoroutine(TypeSpeechBubble2Dialogue());
            }
        }

        
    }

}
