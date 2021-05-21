using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWButton : MonoBehaviour
{
    public string SceneName;

    public void StartGameButton()
    {
        SceneManager.LoadScene(SceneName);
    }
}
