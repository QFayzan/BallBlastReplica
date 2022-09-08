using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeManager : MonoBehaviour
{
    bool IsGameStarted = true;   //As required by task 1
    public TextMeshProUGUI elapsedUI;
    public TextMeshProUGUI Countdown;
    public TextMeshProUGUI Paused;
    public static float Counter = 60.0f;          //counts time remaining
    public float elapsed;                //counts time pased since scene started
    // Start is called before the first frame update
    void Start()
    {
        Counter = 60.0f;
        Paused.text = "Press F to Restart Early" ;  
    }

    // Update is called once per frame
    void Update()
    {
        //Stops the Game when IsGameStarted is false and also displays that in UI
        if (IsGameStarted == false)
        {
            Time.timeScale = 0;
           // Paused.text = "IsGameStarted is " + IsGameStarted.ToString();
        }
        //Shows time since game started
        elapsed = Time.realtimeSinceStartup;
        elapsedUI.text = "Time Since Start " + elapsed.ToString();
    
        if (Input.GetKeyDown(KeyCode.F))
        {
            IsGameStarted = true;
            Time.timeScale = 1;
            SceneManager.LoadScene("Main 1");
        }
    }
    private void LateUpdate()
    {  
        // Basic logic of timer using late update for accuracy

        if (Counter > 0)
        {
            Counter = Counter - Time.deltaTime;
        }
        if (Counter <= 0)
        {
            IsGameStarted = false;
            SceneManager.LoadScene("Game Over Screen");
            
        }

        //displays countdown since start
        Countdown.text = "Timer Remaining " + Counter.ToString();
    }
}