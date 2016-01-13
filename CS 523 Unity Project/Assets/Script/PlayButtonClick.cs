using UnityEngine;
using UnityEngine.UI;

public class PlayButtonClick : MonoBehaviour {

    public static bool play = false;
    public Text ButtonText;

    public void PlayButtonCLickEvent()
    {
        play = !play;
        ButtonText.text = !PlayButtonClick.play ? "Play" : "Pause";
        Debug.Log("Button clicked " + play);
        Ball_One_ControllerScript.gameEnd = false;
    }

    public void RestartButtonCLickEvent()
    {
        Application.LoadLevel(0);
    }
}