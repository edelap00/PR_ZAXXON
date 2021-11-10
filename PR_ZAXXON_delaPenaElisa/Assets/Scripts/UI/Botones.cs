using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    InitGame initGame;
    [SerializeField] Text punt;
    [SerializeField] Text puntfin;
    // Start is called before the first frame update
    void Start()
    {
        initGame = GameObject.Find("initGame").GetComponent<InitGame>();
        

    }

// Update is called once per frame
void Update()
    {
        punt.text = "Puntos: " + initGame.punt.ToString();
        punt.text = initGame.punt.ToString();
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
