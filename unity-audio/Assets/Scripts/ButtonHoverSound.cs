using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverSound : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip hoverSoundClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GameObject.Find("MenuSFX").GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        audioSource.PlayOneShot(hoverSoundClip);
    }
}