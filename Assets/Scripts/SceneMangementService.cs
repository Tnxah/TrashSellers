using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMangementService : MonoBehaviour
{
    public static string gameScene = "SampleScene";

    public static void LoadGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }
}
