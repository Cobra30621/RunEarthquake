using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame ()
    {

        SceneManager.LoadScene("Game");

    }
    public void ExplanGame()
    {
        
        SceneManager.LoadScene("���仡��");
    }
    public void ExitGame()
    {

        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
