using System;
using Coffee.UIEffects;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Helpers
{
    public class TransitionController : MonoBehaviour
    {
        public static TransitionController instance;

        [SerializeField] 
        private GameObject transitionImage;

        [SerializeField] 
        private float animationSpeed = 1f;

        private UIDissolve _dissolveEffect;

        private void Awake()
        {
            _dissolveEffect = transitionImage.GetComponent<UIDissolve>();
            EnsureObjectDoesntGetDestroyed();

            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            Transition(1, () => transitionImage.SetActive(false));
        }

        private void OnDestroy()
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        private void EnsureObjectDoesntGetDestroyed()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                return;
            }

            Destroy(gameObject);
        }


        public void Transition(int endpoint, [CanBeNull] Action callback=null)
        {
            transitionImage.SetActive(true);

            DOTween.To(() => _dissolveEffect.effectFactor,
                    x => _dissolveEffect.effectFactor = x, endpoint,
                    animationSpeed)
                .SetEase(Ease.InSine)
                .OnComplete(() => callback?.Invoke());
        }

    }
}