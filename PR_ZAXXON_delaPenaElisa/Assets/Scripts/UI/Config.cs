using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Config : MonoBehaviour
{

    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider volumeSlider2;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = GameManager.volume;
        volumeSlider2.value = GameManager.volume2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarVolumen()
    {
        GameManager.volume = volumeSlider.value;

        //conversión

        float audioBs1 = 20 * Mathf.Log10 (volumeSlider.value);

        audioMixer.SetFloat("voluMus", audioBs1);
    }

    public void CambiarVolumenEf()
    {
        GameManager.volume2 = volumeSlider2.value;

        //conversión

        float audioBs2 = 20 * Mathf.Log10(volumeSlider2.value);

        audioMixer.SetFloat("volumEfect", audioBs2);
    }
}
