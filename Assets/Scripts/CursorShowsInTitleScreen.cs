using UnityEngine;

public class CursorShowsInTitleScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
