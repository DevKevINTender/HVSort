using UnityEngine;

namespace ScriptableObjects.BackGroundSO.SkriptsSO
{
    [CreateAssetMenu(fileName = "BackGroundSO", menuName = "SrcObj/ new BackGroundSO", order = 0)]
    public class BackGroundScrObj : ScriptableObject
    {
        public int id;
        public Sprite backGroundSession;
        public Sprite backGroundUI;
    }
}