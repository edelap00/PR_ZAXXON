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

   public void Salir()
    {
        Application.Quit();
    }
    public void CargarEscena (int scene)
    {
        SceneManager.LoadScene(scene);
    }
}
