using System.Collections;
using System.Collections.Generic;
using ScriptableObjects.DailySo.ScriptsSO;
using UnityEngine;
using UnityEngine.UI;

public class DailyItemView : MonoBehaviour
{
   public Text taskText;
   public Text rewardText;

   private DailyScrObj dailyScrObj;
   public void InitView(DailyScrObj dailyScrObj)
   {
      this.dailyScrObj = dailyScrObj;
      taskText.text = dailyScrObj.task;
      rewardText.text = dailyScrObj.reward + "";
   }
}
