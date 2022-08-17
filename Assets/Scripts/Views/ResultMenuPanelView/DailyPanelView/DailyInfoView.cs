using System.Collections.Generic;
using Animation_DOTween.DailyPanel;
using Controlers;
using ControlersData;
using ScriptableObjects.DailySo.ScriptsSO;
using UnityEngine;
using UnityEngine.UI;

namespace Views.Result.DailyPanelView
{
    public class DailyInfoView : MonoBehaviour
    {
        [SerializeField] private List<Image> dailyStatusIamge = new List<Image>();
        public void Start()
        {
            DailyCnt.CompleteDailyEvent += UpdateView;
        }

        public void OnDestroy()
        {
            DailyCnt.CompleteDailyEvent -= UpdateView;
        }

        public void InitView()
        {
            UpdateView();
        }
        public void UpdateView()
        {
            List<DailyScrObj> list = DailyCnt.GetCurrentDailyList();
            for (int i = 0; i < dailyStatusIamge.Count; i++)
            {
                if (list[i].isCompleted)
                {
                    AudioCnt audioCnt = FindObjectOfType<AudioCnt>();
                    audioCnt.CreateNewAudioElement(11);
                    if (list[i].isGetReward)
                    {
                        dailyStatusIamge[i].color = Color.grey;
                        dailyStatusIamge[i].GetComponent<DailyInfoItemAnim>().StopAnim();
                    }
                    else
                    {
                        dailyStatusIamge[i].GetComponent<DailyInfoItemAnim>().PulseAndJump();
                        
                        dailyStatusIamge[i].color = Color.green;
                    }
                }
                else
                {
                    dailyStatusIamge[i].color = Color.white;
                }
            }
        }
        
    }
}