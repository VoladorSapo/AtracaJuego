using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager InstanceSound;
    private bool isFading=false;
    public AudioSource _music, _sfx, _hits, _doors, _dialog, _move;


    //SoundManager.InstanceSound.PlaySound...(SoundGallery.InstanceClip.audioClips[i])
    void Awake(){
        if(InstanceSound==null){
            InstanceSound=this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        _music.loop=true;
    }

    void Start(){

    }
    /*public void PlaySound(AudioClip clip){
        _sfx.PlayOneShot(clip);
    }

    public void PlaySoundDoor(AudioClip clip){
        _doors.PlayOneShot(clip);
    }

    public void PlayDialogSound(AudioClip clip){
        _dialog.PlayOneShot(clip);
    }
    public void HitSound(AudioClip clip){
        _hits.PlayOneShot(clip);
    }
    public void StopSound(){
        _sfx.Stop();
    }

    public bool CheckPlaying(){
        if(_sfx.isPlaying){return true;}
        else{return false;}
    }*/

    public void PlaySound(AudioSource a, AudioClip clip){
        a.PlayOneShot(clip);
    }

    public bool CheckPlaying(AudioSource a){
        return a.isPlaying;
    }
    public void StartFadeOut(float fadeOut,AudioSource a)
    {
        if (!isFading)
        {
            isFading = true;
            StartCoroutine(FadeOut(fadeOut,a));
        }
    }

    public void SetVolume(float volume, AudioSource a){
        a.volume=volume;
    }

    public void PlayMusic(float fadeSpeed, AudioClip clip){
        StartCoroutine(FadeInMusic(fadeSpeed,clip));
    }

    public void ChangeMusic(float fadeOutDuration, float fadeInSpeed, AudioClip a){
        StartCoroutine(FadeOutMusic(fadeOutDuration,a,fadeInSpeed));
    }
    private IEnumerator FadeOutMusic(float fadeDuration, AudioClip a, float fadeIn)
    {
        float startVolume = _music.volume;

        while (_music.volume > 0)
        {
            _music.volume -= startVolume * Time.deltaTime / fadeDuration;

            yield return null;
        }

        _music.Stop();
        _music.volume = startVolume;
        StartCoroutine(FadeInMusic(fadeIn,a));
    }


    private IEnumerator FadeOut(float fadeDuration, AudioSource a)
    {
        float startVolume = a.volume;

        while (a.volume > 0)
        {
            a.volume -= startVolume * Time.deltaTime / fadeDuration;

            yield return null;
        }

        a.Stop();
        a.volume = startVolume;
        isFading = false;
    }

    

    private IEnumerator FadeInMusic(float fadeInSpeed, AudioClip clip)
    {
        float initialVolume = _music.volume;
        _music.volume = 0f;
        if(clip==null){
        
        Scene _scene = SceneManager.GetActiveScene();
        switch(_scene.name){
            case "Escena1": 
                            _music.clip=SoundGallery.InstanceClip.audioClips[21];
                            _music.Play(); break;
            default: break;
        }
        }else{
            _music.clip=clip;
            _music.Play();
        }
        
        
        while (_music.volume < initialVolume)
        {
            _music.volume += Time.deltaTime * fadeInSpeed;

            yield return null;
        }
        
        _music.volume = initialVolume;
    }
}
