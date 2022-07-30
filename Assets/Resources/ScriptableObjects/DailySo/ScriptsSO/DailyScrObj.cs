using UnityEngine;

namespace ScriptableObjects.DailySo.ScriptsSO
{
    [CreateAssetMenu(fileName = "DailySO", menuName = "SrcObj/ new DailySO", order = 0)]
    public class DailyScrObj : ScriptableObject
    {
        public int id;
        public int reward;
        public int completedPoints;
        public int currentPoints;
        public bool isCompleted;
        public bool isGetReward;
        public string task;

    }
}