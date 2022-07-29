using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartTypeCom : MonoBehaviour
{
   [SerializeField] private SpriteRenderer partTypeSprite;
   
   public void InitComponent(Color32 color)
   {
      partTypeSprite.color = color;
   }
}
