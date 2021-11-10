using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InitGame : MonoBehaviour
{
   public int punt = 0;

    public float naveSpeed;
    


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
        if (punt > GameManager.highscore)
        {
            GameManager.highscore = punt;
            
        }

        SceneManager.LoadScene(3);

    }
}
