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
        private IShowTextUI _showTextUI;

        private AudioPickup _audioPickup;
        private AudioHook _audioHook;

        private HookPickUpItem _hookPickUpItem;
        private Transform _targetObjectItem;
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
                _moveHook.IsMovingHorizontally = true;
                _moveHook.IsMovingUpAfterAttach = false;
            }

        }
        protected void Awake()
        {
            _hookAnimation = GetComponentInChildren<IHookAnimation>();
            _hookObject = GetComponent<IHookObject>();
            _audioGuidingLoop = GetComponent<IAudioGuidingLoop>();
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
            Debug.Log("_moveHook.IsMovingHorizontally: " + _moveHook.IsMovingHorizontally);

        }

        protected void OnChangeAudioGuidingLoop()
        {

            if (_moveHook.IsCompleteMove)
            {
                _audioGuidingLoop.StopAudio();
                hasPlayedAudioGuidingLoop = false;
            }
            if (!_moveHook.IsDestroyItem)
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
           
            if (_moveHook.IsDestroyItem)
            {
                if (!hasPlayedAudioHookPickup)
                {
                    _audioPickup.Play();
                    hasPlayedAudioHookPickup = true;
                }
                if (!_audioPickup.GetComponent<AudioSource>().isPlaying)
                {
                    _moveHook.IsDestroyItem = false;
                }
            }
            if (!_moveHook.IsDestroyItem)
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


            if (!_moveHook.IsCompleteMove)
            {
                _audioHook.Stop();
                hasPlayedAudioHook = false;
                _hookAnimation.EnableAnimation();
                _hookAnimation.SetAnimation(StateHook.Waiting, false);
            }

            if (_moveHook.IsCompleteMove)
            {
                //_audioGuidingLoop.StopAudio();
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
                if (_moveHook.IsMovingHorizontally)
                {
                    _moveHook.OnMoveHorizontalMiddle(_targetObjectItem.position, _hookAnimation);
                }
                else if (!_moveHook.IsAnimating)
                {
                    _moveHook.OnAttachObjectToHook(_targetObjectItem,_hookAnimation);
                }
            }

            if (_moveHook.IsMovingUpAfterAttach)
            {
                _moveHook.OnMoveUp(_targetObjectItem, _hookAnimation);

            }
           
        }

    }
}