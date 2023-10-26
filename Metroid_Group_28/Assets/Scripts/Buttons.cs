using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Isaac Soto 
/// 10/25/23
/// [These are the button functions for starting and qutting the game]
/// </summary>

public class Buttons : MonoBehaviour
{
    /// <summary>
    ///  RetryGame is for the death scene to go back to the Menu scene or load scene 0  to play the game agian
    /// </summary>
    public void Retrygame()
    {
        SceneManager.LoadScene(0);
    }
    /// <summary>
    /// Quit Game is the button function to close or Exit the Game application
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit(); 
    }
    /// <summary>
    /// Start Game is for the menu start button function to load the main game scene to play
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


} 
