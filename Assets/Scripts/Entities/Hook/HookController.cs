using Assets.Scripts.Audios;
using Assets.Scripts.UI;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    [RequireComponent(typeof(HookObject))]
    [RequireComponent(typeof(HookMovement))]
    [RequireComponent(typeof(HookPickUpItem))]
    [RequireComponent(typeof(AudioGuidingLoop))]
    public class HookController : MonoBehaviour, IMoveToItem
    {
        private IHookAnimation _hookAnimation;
        private IHookObject _hookObject;
        private IAudioGuidingLoop _audioGuidingLoop;
        private IMoveHook _moveHook;
        private IDestroyItemByHook _destroyItemByHook;
        private IShowTextUI _showTextUI;

        private AudioPickup _audioPickup;
        private AudioHook _audioHook;

        private HookPickUpItem _hookPickUpItem;
        private Transform _targetObjectItem;


        private bool isMovingHook = false;

        private bool hasPlayedAudioHook = false;
        private bool hasPlayedAudioHookPickup = false;
        private bool hasPlayedAudioGuidingLoop = false;


        public void Init(HookPickUpItem hookPickUpItem)
        {
            _hookPickUpItem = hookPickUpItem;
            _hookPickUpItem.OnChangeTransformItem += MoveHookToItem;
        }
        public void MoveHookToItem(Transform transform)
        {
            if(transform != null)
            {
                _targetObjectItem = transform;
                _moveHook.IsMoving = true;
                isMovingHook = _moveHook.IsMoving;
            }

        }
        protected void Awake()
        {
            _hookAnimation = GetComponentInChildren<IHookAnimation>();
            _hookObject = GetComponent<IHookObject>();
            _audioGuidingLoop = GetComponent<IAudioGuidingLoop>();
            _destroyItemByHook = GetComponent<IDestroyItemByHook>();
            _showTextUI = GetComponent<IShowTextUI>();
            _moveHook = GetComponent<IMoveHook>();
            _audioPickup = GetComponentInChildren<AudioPickup>();
            _audioHook = GetComponentInChildren<AudioHook>();
        }

        protected void Start()
        {
            _hookObject.Hide();
            _audioHook.StopAudio();
        }

        protected void Update()
        { 
            OnMoveHook();
            OnChangeAudioAndAnimatonByHook();
            OnChangeAudioPickUpItem();
            OnChangeAudioGuidingLoop();
            Debug.Log("isMovingHook: " + isMovingHook);
        }

        protected void OnChangeAudioGuidingLoop()
        {

            if (isMovingHook)
            {
                _audioGuidingLoop.StopAudio();
                hasPlayedAudioGuidingLoop = false;
            }
            if (!_destroyItemByHook.IsDestroy)
            {
                if (!hasPlayedAudioGuidingLoop)
                {
                    _audioGuidingLoop.StartAudio();
                    hasPlayedAudioGuidingLoop = true;
                }
            }

        }

        protected void OnChangeAudioPickUpItem()
        {
           
            if (_destroyItemByHook.IsDestroy)
            {
                if (!hasPlayedAudioHookPickup)
                {
                    _audioPickup.Play();
                    isMovingHook = false;
                    hasPlayedAudioHookPickup = true;
                 
                }
                if (!_audioPickup.GetComponent<AudioSource>().isPlaying)
                {
                    _destroyItemByHook.IsDestroy = false;
                    _moveHook.IsMoving = false;
                }
            }
            if (!_destroyItemByHook.IsDestroy)
            {
                hasPlayedAudioHookPickup = false;
            }

        }

        protected void OnChangeAudioAndAnimatonByHook()
        {
            if (_showTextUI.IsShowUI())
            {
                _audioHook.Pasue();
            }
            else
            {
                _audioHook.Resume();
            }


            if (!isMovingHook)
            {
                _audioHook.Stop();
                hasPlayedAudioHook = false;
                _hookAnimation.EnableAnimation();
                _hookAnimation.SetAnimation(StateHook.Waiting, false);
            }

            if (isMovingHook)
            {
                AudioGuiding.Instance.Stop();
                _hookAnimation.DisableAnimation();
                if (!hasPlayedAudioHook)
                {
                    _audioHook.Play();
                    hasPlayedAudioHook = true;
                }
            }

        }

        protected void OnMoveHook()
        {

            if (_targetObjectItem != null)
            {
                _moveHook.OnMoveHook(_targetObjectItem, _hookAnimation);

            }
        }
    }
}