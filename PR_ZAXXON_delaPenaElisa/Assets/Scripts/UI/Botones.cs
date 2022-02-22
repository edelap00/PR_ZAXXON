using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{

    [SerializeField] Text gem;
    [SerializeField] Text puntfin;
    [SerializeField] Text muertos;
    [SerializeField] Text punt;
    // Start is called before the first frame update
    void Start()
    {
     
        

    }

// Update is called once per frame
void Update()
    {
        
        if (gem != null)
        {
            gem.text = "Gemas: " + GameManager.punt;
        }

        if (puntfin != null)
        {
            puntfin.text = "Tu récord de hoy ha sido: " + GameManager.highscore + " puntos ";
        }
        if (punt != null)
        {
            punt.text = " " + GameManager.globalPoints+ " ";
        }

        if (muertos != null)
        {
            muertos.text = "Muertos: " + GameManager.muertos;
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
