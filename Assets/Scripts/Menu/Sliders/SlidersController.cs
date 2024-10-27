using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlidersController : MonoBehaviour
{
    private Slider mySlider;
    void Start()
    {
        mySlider = GetComponent<Slider>();
        if (gameObject.CompareTag("MUSIC") && SoundManager.Instance != null)
        {
            mySlider.value = SoundManager.Instance.GetMusicVolume();
            mySlider.onValueChanged.AddListener(delegate { UpdateMusicVolume(); });
        }
        if (gameObject.CompareTag("EFFECTS") && SoundManager.Instance != null)
        {
            mySlider.value = SoundManager.Instance.GetEffectsVolume();
            mySlider.onValueChanged.AddListener(delegate { UpdateEffectsVolume(); });
        }
    }

    private void UpdateMusicVolume()
    {
        if(SoundManager.Instance != null)
        {
            SoundManager.Instance.SetMusicVolume(mySlider.value);

        }
        else
        {
            Debug.Log("[MISSING] -> SOUND MANAGER");
        }
    }

    private void UpdateEffectsVolume()
    {
        if(SoundManager.Instance != null)
        {
            SoundManager.Instance.SetEffectsVolume(mySlider.value);
        }
        else
        {
            Debug.Log("[MISSING] -> SOUND MANAGER");
        }
    }

    
}
