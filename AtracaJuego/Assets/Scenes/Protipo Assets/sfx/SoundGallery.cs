using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundGallery : MonoBehaviour
{
    public static SoundGallery InstanceClip;
    public AudioClip[] audioClips;
    void Awake(){
        if(InstanceClip==null){
            InstanceClip=this;
            DontDestroyOnLoad(gameObject);
        }else{
            Destroy(gameObject);
        }

    }
}
