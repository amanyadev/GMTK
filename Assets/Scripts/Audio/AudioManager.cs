using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The audio manager add new clips here and in AudioClip.cs ho to add mentioned on line 28
/// </summary>
public static class AudioManager
{
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips =
        new Dictionary<AudioClipName, AudioClip> ();

    /// <summary>
    /// Initializes the audio manager
    /// </summary>
    /// <param name="source">audio source</param>
    public static void Initialize (AudioSource source)
    {
        audioSource = source;
        audioClips.Add (AudioClipName.FoodCollected,
            Resources.Load<AudioClip> ("coin"));

        audioClips.Add (AudioClipName.PlayerDeath,
            Resources.Load<AudioClip> ("die"));
        //how to add new files
        //audioClips.Add (AudioClipName.Jump, //add enum here
        //  Resources.Load<AudioClip> ("jumping")); //addclip name here

    }

    /// <summary>
    /// Plays the audio clip with the given name
    /// </summary>
    /// <param name="name">name of the audio clip to play</param>
    public static void Play (AudioClipName name)
    {
        audioSource.PlayOneShot (audioClips[name]);
    }
    public static void StartBGMusic ()
    {
        audioSource.Play ();
    }
}