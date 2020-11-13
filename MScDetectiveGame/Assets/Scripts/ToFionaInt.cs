using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFionaInt : MonoBehaviour
{
    public void ButtonMoveScene(string ToFionaInterview)
    {
        SceneManager.LoadScene(ToFionaInterview);
    }
}
