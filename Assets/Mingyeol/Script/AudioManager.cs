using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] swing1;

    [SerializeField] private AudioSource source;

    public static AudioManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void SetSounds(int sourceIndex)
    {
        source.clip = swing1[sourceIndex];

        source.Play();
    }

}
