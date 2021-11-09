using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InitGame : MonoBehaviour
{
  

    public float naveSpeed;
    public int score = 0;


    // Start is called before the first frame update
    void Start()
    {
     naveSpeed = 7f;
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
    }

    public void Morir()
    {
        if (score > GameManager.highscore)
        {
            GameManager.highscore = score;
            
        }

        SceneManager.LoadScene(3);

    }
}
