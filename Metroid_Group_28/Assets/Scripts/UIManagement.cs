using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/// Isaac Soto
/// 10/24/2023
/// [ ALL UI MANAGEMENT of LIVES and Text]


public class UIManagement : MonoBehaviour
{
   public PlayerController PlayerController;

    public TMP_Text livesText;
    // Update is called once per frame

    void Update()
    {
         //Sets the text string as "Lives: " (A String) Plus Total Score

         //livesText.text = "Lives: " + PlayerController.lives.Tostring();
    }
}
