using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public GameController controller;
    public GameObject titleAudio;
    public GameObject bgfxAudio;
    public GameObject discoveryAudio;

    private AudioSource title;
    private AudioSource bgfx;
    private AudioSource discovery;

    public float fadeOutSpeed;

    private void Awake()
    {
        controller = GetComponent<GameController>();

        title = titleAudio.GetComponent<AudioSource>();
        bgfx = bgfxAudio.GetComponent<AudioSource>();
        discovery = discoveryAudio.GetComponent<AudioSource>();
    }

    public void PlaySFX(string soundToPlay) // Plays a sound effect. The sound effect is determined by the string passed as an argument.
    {
        Debug.Log("SFXController/PlaySFX was called with argument " + soundToPlay);

        if (soundToPlay == "title")
        {
            Debug.Log("SFXController/PlaySFX: Playing AudioSource title.");
            title.Play();
        }
        else if (soundToPlay == "bgfx")
        {
            Debug.Log("SFXController/PlaySFX: Playing AudioSource bgfx.");
            bgfx.Play();
        }
        else if (soundToPlay == "discovery")
        {
            Debug.Log("SFXController/PlaySFX: Playing AudioSource discovery.");
            discovery.Play();
        }
        else
        {
            Debug.Log("SFXController/PlaySFX: No sound played because soundToPlay argument not recognized.");
        }
    }

    public void StopSFX(string soundToStop) // Stops a sound effect. The sound effect is determined by the string passed as an argument.
    {
        Debug.Log("SFXController/StopSFX was called with argument " + soundToStop);

        if (soundToStop == "title")
        {
            Debug.Log("SFXController/PlaySFX: Stopping AudioSource title.");
            title.Stop();
        }
        else if (soundToStop == "bgfx")
        {
            Debug.Log("SFXController/PlaySFX: Stopping AudioSource bgfx.");
            bgfx.Stop();
        }
        else if (soundToStop == "discovery")
        {
            Debug.Log("SFXController/PlaySFX: Stopping AudioSource discovery.");
            discovery.Stop();
        }
        else
        {
            Debug.Log("SFXController/PlaySFX: No sound stopped because soundToStop argument not recognized.");
        }
    }

    public IEnumerator FadeOutSFX(string soundToFadeOut) // Fades out a sound effect. The sound effect is determined by the string passed as an argument.
    {
        Debug.Log("SFXController/StopSFX was called with argument " + soundToFadeOut);

        if (soundToFadeOut == "title")
        {
            Debug.Log("SFXController/PlaySFX: Stopping AudioSource title.");

            float startVolume = title.volume;

            while (title.volume > 0)
            {
                title.volume -= startVolume * Time.deltaTime / fadeOutSpeed;

                yield return null;
            }

            title.Stop();
            title.volume = startVolume;
        }
        else if (soundToFadeOut == "bgfx")
        {
            Debug.Log("SFXController/PlaySFX: Stopping AudioSource bgfx.");

            float startVolume = bgfx.volume;

            while (bgfx.volume > 0)
            {
                bgfx.volume -= startVolume * Time.deltaTime * fadeOutSpeed;

                yield return null;
            }

            bgfx.Stop();
            bgfx.volume = startVolume;
        }
        else
        {
            Debug.Log("SFXController/PlaySFX: No sound faded out because soundToFadeOut argument not recognized.");
        }
    }

    public IEnumerator StartingFade() // SLEUTH: Called to transition the background audio from the title screen to gameplay.
    {
        float titleStartVolume = title.volume;

        while (title.volume > 0)
        {
            title.volume -= titleStartVolume * Time.deltaTime * fadeOutSpeed;

            yield return null;
        }

        title.Stop();
        title.volume = titleStartVolume;
        PlaySFX("bgfx");
    }

    public IEnumerator EndingFade() // SLEUTH: Called to transition the background audio from gameplay to the title screen.
    {
        float bgfxStartVolume = bgfx.volume;

        while (bgfx.volume > 0)
        {
            bgfx.volume -= bgfxStartVolume * Time.deltaTime * fadeOutSpeed;

            yield return null;
        }

        bgfx.Stop();
        bgfx.volume = bgfxStartVolume;
        PlaySFX("title");
    }
}