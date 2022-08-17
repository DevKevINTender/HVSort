using System;
using System.Collections.Generic;
using Components;
using UnityEngine;

namespace Controlers
{
    public class AudioCnt : MonoBehaviour
    {
        public List<AudioElement> audioList = new List<AudioElement>();
        public AudioCom audioElementPb;

        public void CreateNewAudioElement(int id)
        {
            AudioCom newAudioCom = Instantiate(audioElementPb);
            newAudioCom.InitComponent(audioList[id].audio);
            
        }
    }
    
    [Serializable]
    public struct AudioElement
    {
        public AudioClip audio;
        public bool audioStatus;
    }
}