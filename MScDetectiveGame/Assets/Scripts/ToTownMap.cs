using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Reference adapted from: Dual Core Studio (19 March 2017) Unity: Switching Levels/Scenes. Available at: https://www.youtube.com/watch?v=26d1uZ7yrfY. Accessed July 2020.

public class ToTownMap : MonoBehaviour
{
    public void ButtonMoveScene(string TownMap)
    {
        SceneManager.LoadScene(TownMap);
    }
}
