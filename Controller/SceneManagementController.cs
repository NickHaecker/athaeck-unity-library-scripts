using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManagerController
{
    public static void LoadSceneSync(string name, bool additiv)
    {
        SceneManager.LoadScene(name, GetSceneMode(additiv));
    }
    public static AsyncOperation LoadAceneAsync(string name, bool additiv)
    {
        return SceneManager.LoadSceneAsync(name, GetSceneMode(additiv));
    }
    public static AsyncOperation UnloadSceneAsync(string name)
    {
        return SceneManager.UnloadSceneAsync(name);
    }

    private static LoadSceneMode GetSceneMode(bool additiv)
    {
        return additiv ? LoadSceneMode.Additive : LoadSceneMode.Single;
    }

}