using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using TMPro;
using DG.Tweening;
using DG.Tweening.Core.Easing;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    [SerializeField] private TMP_Text myText;

    [SerializeField] private float fadeToValue;
    [SerializeField] private float fadeDurationSeconds;
    [SerializeField] private AnimationCurve easeCurve;

    private Button myButtonComponent;

    [SerializeField] private GameObject arrow;

    public AudioClip clickSound;
    public AudioClip hoveringSound;
    private void Awake()
    {
        myButtonComponent = GetComponent<Button>();
        arrow.SetActive(false);
    }

    void Start()
    {
        /*myText.DOFade(fadeToValue, fadeDurationSeconds).SetEase(easeCurve).OnComplete(() =>
        {
            myButtonComponent.enabled = true;
            isButtonEnabled = myButtonComponent.enabled;
        });*/
    }

    void Update()
    {
        
    }

    

    public void MouseHovering()
    {
        if (myButtonComponent.enabled)
        {
            arrow.SetActive(true);
            if(SoundManager.Instance != null)
            {
                SoundManager.Instance.PlaySpecificClip(hoveringSound);
            }
        }
    }


    public void MouseExited()
    {
        arrow.SetActive(false);
    }

    public void OnMouseClick()
    {
        if(SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySpecificClip(clickSound);
        }
    }

    private void OnDisable()
    {
        arrow.SetActive(false);
    }
}
