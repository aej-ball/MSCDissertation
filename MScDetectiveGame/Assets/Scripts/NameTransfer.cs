using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Reference for this code: Vegas, Jimmy (23 April 2019) How to Display Text From An Input Field Using C# Unity Tutorial. Aavailable at: https://www.youtube.com/watch?v=2liZtyMhIQQ. Accessed July 2020.


public class NameTransfer : MonoBehaviour
{
    public string theName;
    public GameObject inputField;
    public GameObject textDisplay;

    public GameObject ToDCIButton;

    private void Start()
    {
        ToDCIButton.SetActive(false);
    }

    public void StoreName()
    {
        theName = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Welcome, DI " + theName + ", to Chedglow. DCI Jane Barton is just in a meeting, she will be here any moment to show you around. Ah! here she comes now.";
        ToDCIButton.SetActive(true);
    }

  

}
