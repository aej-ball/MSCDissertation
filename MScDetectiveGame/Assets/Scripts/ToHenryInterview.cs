using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToHenryInterview : MonoBehaviour
{
    public void ButtonMoveScene(string ToHenryInterview)
    {
        SceneManager.LoadScene(ToHenryInterview);
    }
}
