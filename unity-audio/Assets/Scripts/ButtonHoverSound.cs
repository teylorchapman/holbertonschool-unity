using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public AudioClip hoverSoundClip;
    public AudioClip clickSoundClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("MenuSFX").GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverSoundClip);
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        audioSource.PlayOneShot(clickSoundClip);
    }
}