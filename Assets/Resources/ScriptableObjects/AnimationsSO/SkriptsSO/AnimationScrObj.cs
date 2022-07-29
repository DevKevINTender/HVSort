using UnityEngine;

namespace ScriptableObjects.AnimationsSO.SkriptsSO
{
    [CreateAssetMenu(fileName = "AnimationSO", menuName = "SrcObj/ new AnimationSO", order = 0)]
    public class AnimationScrObj : ScriptableObject
    {
        public int id;
        public Animation AnimationItem;
    }
}