using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter()
    {
        LevelLoad();
    }
    public void LevelLoad()
    {
        SceneManager.LoadScene(2);
        SceneManager.UnloadSceneAsync(1);
    }
}
