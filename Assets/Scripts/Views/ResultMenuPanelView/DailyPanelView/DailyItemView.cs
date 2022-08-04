using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.DailySo.ScriptsSO;
using UnityEngine;
using UnityEngine.UI;

public class DailyItemView : MonoBehaviour
{
   [SerializeField] private Sprite availableDaily;
   [SerializeField] private Sprite completedDaily;
   [SerializeField] private Sprite gettedDaily;

   [SerializeField] private Image currentStatusDaily;
   
   public Text taskText;
   public Text rewardText;
   public Text pointText;
   
   private DailyScrObj dailyScrObj;
   public void InitView(DailyScrObj dailyScrObj)
   {
      this.dailyScrObj = dailyScrObj;
      taskText.text = dailyScrObj.task;
      rewardText.text = dailyScrObj.reward + "";

      if (dailyScrObj.isCompleted)
      {
         currentStatusDaily.sprite = completedDaily;
         pointText.text = "Вып.";
         if (dailyScrObj.isGetReward)
         {
            currentStatusDaily.sprite = gettedDaily;
         }
      }
      else
      {
         pointText.text = dailyScrObj.currentPoints + "/" + dailyScrObj.completedPoints;
         currentStatusDaily.sprite = availableDaily;
      }
   }
}
