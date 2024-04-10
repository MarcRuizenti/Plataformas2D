using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioClip swordAttack;
    public AudioClip tread;
    public AudioClip jump;
    public AudioClip fall;

    public void PlaySwordAttack()
    {
        SoundManager.Instance.EjecutarAudio(swordAttack);
    }

    public void PlayTread()
    {
        SoundManager.Instance.EjecutarAudio(tread);
    }

    public void PlayJump()
    {
        SoundManager.Instance.EjecutarAudio(jump);
    }

    public void PlayFall()
    {
        SoundManager.Instance.EjecutarAudio(fall);
    }
}
