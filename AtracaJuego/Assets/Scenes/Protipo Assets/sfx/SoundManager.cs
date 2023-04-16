using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager InstanceSound;
    private bool isFading=false;
    private float fadeDuration=0.4f;
    public float fadeInSpeed = 0.25f;
    [SerializeField] private AudioSource _music, _sfx, _hits, _doors, _dialog;
    

    //SoundManager.InstanceSound.PlaySound...(SoundGallery.InstanceClip.audioClips[i])
    void Awake(){
        if(InstanceSound==null){
            InstanceSound=this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }
    }

    void Start(){
        Scene currentScene = SceneManager.GetActiveScene();
        StartCoroutine(FadeInMusic(currentScene));
    }
    public void PlaySound(AudioClip clip){
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
    }

    public void StartFadeOut()
    {
        if (!isFading)
        {
            isFading = true;
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        float startVolume = _sfx.volume;

        while (_sfx.volume > 0)
        {
            _sfx.volume -= startVolume * Time.deltaTime / fadeDuration;

            yield return null;
        }

        _sfx.Stop();
        _sfx.volume = startVolume;
        isFading = false;
    }

    

    private IEnumerator FadeInMusic(Scene scene)
    {
        float initialVolume = _music.volume;
        _music.volume = 0f;
        switch(scene.name){
            case "Protipo": _music.PlayOneShot(SoundGallery.InstanceClip.audioClips[21]); break;
            default: break;
        }
        
        
        while (_music.volume < initialVolume)
        {
            _music.volume += Time.deltaTime * fadeInSpeed;

            yield return null;
        }
        _music.volume = initialVolume;
    }
}
