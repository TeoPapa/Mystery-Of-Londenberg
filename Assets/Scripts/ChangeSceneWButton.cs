using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/* Changes the scene upon clicking on a button */
public class ChangeSceneWButton : MonoBehaviour
{
    public string SceneName; //The name of the scene that will be loaded

    /* Set players position to the start and the StoryIndex to 0 and load the SceneName */
    public void StartGameButton()
    {
        Variables.PlayerSetPosition.x = -246.4f;
        Variables.PlayerSetPosition.y = -57.62f;

        Variables.StoryIndex = 0;

        if (SceneName == "MainMenu")
            Destroy(FindObjectOfType<AudioSource>());
        SceneManager.LoadScene(SceneName);
    }
}
