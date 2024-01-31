using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    public Text pointt;
    public static bool over;

    public void Start()
    {
        gameObject.SetActive(false);
        over = false;
    }
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        over = true;
        pointt.text = score.ToString() + " POINTS";
        
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void MenueButton()
    {
        SceneManager.LoadScene(0);
    }



}
