using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreMan : MonoBehaviour
{
    public Text pointt;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover.over)
        {
            gameObject.SetActive(false);
        }
        else
        {
            pointt.text = "Score: " + carmoving.point.ToString();
        }
    }
}
