using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip audioSource;
    [SerializeField] private AudioClip itemPickUp;
    [SerializeField] private AudioClip itemAction;
    [SerializeField] private AudioClip jumpSound;

    [SerializeField] private AudioSource source;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void SetOptions(AudioSource audioSource)
    {
        source.Play();
    }

}
