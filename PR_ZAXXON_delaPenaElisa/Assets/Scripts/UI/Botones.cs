using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{

    [SerializeField] Text punt;
    [SerializeField] Text puntfin;
    [SerializeField] Text muertos;
    [SerializeField] Text global;
    // Start is called before the first frame update
    void Start()
    {
     
        

    }

// Update is called once per frame
void Update()
    {
        
        if (punt != null)
        {
            punt.text = "Gemas: " + GameManager.punt;
        }

        if (puntfin != null)
        {
            puntfin.text = "Récord: " + GameManager.highscore + " puntos";
        }
        if (global != null)
        {
            global.text = "Global: " + GameManager.globalPoints + " puntos";
        }


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
