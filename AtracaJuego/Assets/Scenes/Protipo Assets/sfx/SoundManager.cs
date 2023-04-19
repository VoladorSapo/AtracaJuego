using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager InstanceSound;
    private bool isFading=false;
    public AudioSource _music, _sfx, _hits, _doors, _dialog, _move;
    private bool hasDialogTutorial=false;
    private Scene _scene;

    //SoundManager.InstanceSound.PlaySound...(SoundGallery.InstanceClip.audioClips[i])
    void Awake(){
    
        if(InstanceSound==null){
            InstanceSound=this;
            //DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
        _music.loop=true;
        CheckScene();
    }

    private IEnumerator PlayTitle(){
        PlayMusic(0.25f,SoundGallery.InstanceClip.musicClips[9]);
        yield return new WaitForSeconds(SoundGallery.InstanceClip.musicClips[9].length);
        _music.clip=SoundGallery.InstanceClip.musicClips[10];
        _music.Play();
    }
    void CheckScene(){
        hasDialogTutorial=false;
        SetVolume(0.4f,SoundManager.InstanceSound._music);
        _scene = SceneManager.GetActiveScene();
        Debug.LogWarning(_scene.name);
        switch(_scene.name){
            case "Inicio":
                //PlayMusic(0.25f,SoundGallery.InstanceClip.musicClips[9]);
                StartCoroutine(PlayTitle());
                break;
            case "Escena1":
                hasDialogTutorial=true;
                PlayMusic(0.25f,SoundGallery.InstanceClip.musicClips[8]);
                break;
            case "Escena2.0(BañoChicos)":
                hasDialogTutorial=true;
                PlayMusic(0.25f,SoundGallery.InstanceClip.musicClips[8]);
                break;
            case "Escena2.1(Baños+Pasillo))":
                PlayMusic(0.25f,SoundGallery.InstanceClip.musicClips[2]);
                break;
            case "Escena2.2":
                PlayMusic(0.25f,SoundGallery.InstanceClip.musicClips[4]);
                break;
            case "Escena3.0":
                PlayMusic(0.25f,SoundGallery.InstanceClip.musicClips[5]);
                break;
            case "Escena3.1":
                PlayMusic(0.25f,SoundGallery.InstanceClip.musicClips[4]);
                break;
            case "Escena1.2":
                PlayMusic(0.25f,SoundGallery.InstanceClip.musicClips[4]);
                break;
            case "Escena2(Gym)":
                PlayMusic(0.25f,SoundGallery.InstanceClip.musicClips[6]);
                break;
            case "Escena2(FinalBossFight)":
                PlayMusic(0.25f,SoundGallery.InstanceClip.musicClips[7]);
                break;
                

        }
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
        a.pitch=1;
        if(a==_dialog){
            float randomPitch = Random.Range(-0.05f, 0.05f);
            a.pitch = Mathf.Clamp(a.pitch + randomPitch, 0.1f, 3.0f);
        }
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
        if(hasDialogTutorial){
        StartCoroutine(FadeOutMusic(fadeOutDuration,a,fadeInSpeed));
        }
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
        
        _scene = SceneManager.GetActiveScene();
        switch(_scene.name){
            
            case "Escena1": 
                            _music.clip=SoundGallery.InstanceClip.musicClips[4];
                            _music.Play(); break;
            case "Escena2.0(BañoChicos)":
                            _music.clip=SoundGallery.InstanceClip.musicClips[2];
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
