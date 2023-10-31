using Assets.Scripts.ScenceController;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ItemsManager : MonoBehaviour
    {
        private static ItemsManager instance;
        public static ItemsManager Instance { get => instance; }
        public List<Item> listItems = new List<Item>();
        private SceneController _sceneController;


        protected void Awake()
        {
            if (instance != null) Debug.LogError("Only one InventoryManager object exists");
            instance = this;
        }
        private void Start()
        {
            _sceneController = FindObjectOfType<SceneController>();
        }


        private void Update()
        {
            if (ListSize() == 4)
            {
                ChangeGameState(GameState.End);
            }
        }


        public void ChangeGameState(GameState newState)
        {
            if (_sceneController != null)
            {
                _sceneController.ChangeState(newState);
            }
        }

        public virtual int ListSize()
        {
            return listItems.Count;
        }
        public virtual void AddItem(Item item)
        {
            listItems.Add(item);
        }


        public virtual void RemoveItem(Item item)
        {
            listItems.Remove(item);
        }


    }
}