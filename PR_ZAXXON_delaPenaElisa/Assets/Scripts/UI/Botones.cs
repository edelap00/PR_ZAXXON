using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Empezar()
    {
        SceneManager.LoadScene(2);
    }

   public void Config()
    {
        SceneManager.LoadScene(1);
    }

   public void Volver()
    {
        SceneManager.LoadScene(0);
    }

    public void Salir()
    {

    }
}
