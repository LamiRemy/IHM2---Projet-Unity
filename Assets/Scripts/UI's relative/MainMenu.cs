using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animation _mainMenuAnimator;
    [SerializeField] AnimationClip _fadeOutAnimationClip;
    [SerializeField] AnimationClip _fadeInAnimationClip;


    public void FadeIn() // Joue l'annimation de démarrage du menu principal
    {
        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = _fadeInAnimationClip;
        _mainMenuAnimator.Play();
    }


    public void FadeOut() // Idem pour l'annimation de sortie
    {
        _mainMenuAnimator.Stop();
        _mainMenuAnimator.clip = _fadeOutAnimationClip;
        _mainMenuAnimator.Play();
    }


    private void OnFadeInComplete()
    {
        Debug.Log("FadeIn complete !");
    }


    private void OnFadeOutComplete()
    {
        Debug.Log("FadeOut complete !");
    }

}
