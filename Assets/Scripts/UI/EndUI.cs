using GameProgress;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI Result;
    // Start is called before the first frame update
    void Start()
    {
        Result.text = $"���L�F {GameProgressHandler.CurrentPhase} �i�a�_";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BackToStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
}
