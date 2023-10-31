using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    [CreateAssetMenu(fileName = "New item", menuName = "Items/Create new item")]
    public class Item : ScriptableObject
    {
        public int id;
        public string itemName;
        public Sprite icon;
        public AudioClip audio;
        public Transform transformItem;
    }
}