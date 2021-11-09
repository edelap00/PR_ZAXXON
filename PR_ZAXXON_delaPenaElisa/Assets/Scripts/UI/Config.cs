using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Config : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = GameManager.volume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarVolumen()
    {
        GameManager.volume = volumeSlider.value;
    }
}
