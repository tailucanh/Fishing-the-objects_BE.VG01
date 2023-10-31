using Assets.Scripts.Entities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ItemTextUI : MonoBehaviour
    {
        protected static ItemTextUI instance;
        public static ItemTextUI Instance => instance;

        [SerializeField] protected TextMeshProUGUI textItem;
        [SerializeField] protected Image bgBlur;
        private IShowTextUI showTextUI;
        private string _itemName;
        private AudioClip _audioClip;
        private AudioSource _audioItem;
        private bool hasPlayedAudio = false;

        private void Awake()
        {
            if (ItemTextUI.instance != null) return;
            ItemTextUI.instance = this;
            showTextUI = FindObjectOfType<HookMovement>();
        }
        private void Start()
        {
            _audioItem = GetComponent<AudioSource>();
        }
        private void Update()
        {
         
            if (showTextUI.IsShowUI() && !string.IsNullOrEmpty(_itemName))
            {
                textItem.gameObject.SetActive(true);
                bgBlur.gameObject.SetActive(true);
                textItem.text = _itemName;
                if(_audioClip != null&& !hasPlayedAudio)
                {
                    _audioItem.PlayOneShot(_audioClip);
                    hasPlayedAudio = true;
                }
                
            }
            else
            {
                textItem.gameObject.SetActive(false);
                bgBlur.gameObject.SetActive(false);
                textItem.text = "";
                hasPlayedAudio = false;
            }
        }

        public void OnShowItem(string text, AudioClip audio)
        {
            _itemName = text;
            _audioClip = audio;
          
        }

    }
}