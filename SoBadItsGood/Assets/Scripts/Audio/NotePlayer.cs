using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class NotePlayer : MonoBehaviour {
    private AudioSource _src;

    private void Awake() {
        _src = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Converts a note and octave to a pitch value for the Unity audio system.
    /// </summary>
    /// <param name="note">The note to play</param>
    /// <param name="octave">The octave to raise it (base is middle c)</param>
    private static int NoteToPitch(Note note, int octave) {
        int octaveSemitones = octave * 12;

        // Formula for raising middle c by any amount of semitones: scale^semitones where scale is the 12th root of 2
        float pitch = Mathf.Pow(1.0594630943592952645618252949463f, octaveSemitones + (int)note);

        return (int)pitch;
    }
    
    public void PlaySound(Note note, int octave, float duration) {
        int pitch = NoteToPitch(note, octave);
        _src.pitch = pitch;
        _src.Play();
    }
}