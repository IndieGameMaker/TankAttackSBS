using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "AudioData", menuName = "Scriptable Objects/AudioData")]
public class AudioData : ScriptableObject
{
    [Header("Audio Mixer")]
    public AudioMixer audioMixer;

    [Header("Audio Clips")] 
    public AudioClip fireSfx;
    public AudioClip engineSfx;
    public AudioClip battleBgm;

    [Header("Audio Mixer Groups")] 
    public string fireSfxMG = "Master/SFX/Fire";
    public string engineSfxMG = "Master/SFX/Engine";
    public string battleBgmMG = "Master/BGM";
}
