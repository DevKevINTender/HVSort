using UnityEngine;

namespace ScriptableObjects.ProgressSO.ScriptsSO
{
    [CreateAssetMenu(fileName = "ProgressSO", menuName = "SrcObj/ new ProgressSO", order = 0)]
    public class ProgressScrObj : ScriptableObject
    {
        public int id;
        public int reward;
        public int needLevel;
        public bool isCompleted;
        public bool isGetReward;

    }
}