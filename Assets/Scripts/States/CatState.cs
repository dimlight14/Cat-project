using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CatSimulator.States
{
    public abstract class CatState
    {
        protected GameManager gameManager;
        protected Animator catAnimator;
        protected StateSettings settings;
        protected CatMood associatedMood;
        protected bool performingAction;
        protected IEnumerator coroutineSignature;

        protected CatState(GameManager gameManager, Animator catAnimator, StateSettings settings) {
            this.gameManager = gameManager;
            this.settings = settings;
            this.catAnimator = catAnimator;
            associatedMood = settings.AssociatedMood;
        }

        public virtual void StartState() {
            EventBus.FireEvent<MoodChangedEvent>(new MoodChangedEvent() { NewMood = associatedMood });
            performingAction = false;
        }

        protected void EndAction(bool transitionToIdle, CatMood moodToChangeInto) {
            if (transitionToIdle) catAnimator.SetTrigger(AnimationTrigger.GoToIdle);
            if (moodToChangeInto != CatMood.None) gameManager.TransitionToState(moodToChangeInto);
            EventBus.FireEvent<ActionEndedEvent>(new ActionEndedEvent());
        }
        protected IEnumerator PerformAction(float time, CatMood moodToChangeInto, bool transitionToIdle = true) {
            performingAction = true;
            yield return new WaitForSeconds(time);
            EndAction(transitionToIdle, moodToChangeInto);
            performingAction = false;
        }

        #region  Actions
        public virtual void FeedAction() {
            if (performingAction) return;

            catAnimator.SetTrigger(AnimationTrigger.FeedAction);
            EventBus.FireEvent<ActionStartedEvent>(new ActionStartedEvent() { ActionDescription = settings.FeedAction.Description });
            gameManager.StartCoroutine(coroutineSignature = PerformAction(
                settings.FeedAction.AnimationLength,
                settings.FeedAction.MoodToChangeInto,
                true
            ));
        }
        public virtual void GetPet() {
            if (performingAction) return;

            catAnimator.SetTrigger(AnimationTrigger.PetAction);
            EventBus.FireEvent<ActionStartedEvent>(new ActionStartedEvent() { ActionDescription = settings.PetAction.Description });
            gameManager.StartCoroutine(coroutineSignature = PerformAction(
                settings.PetAction.AnimationLength,
                settings.PetAction.MoodToChangeInto,
                true
            ));
        }
        public virtual void GetPlayedWith() {
            if (performingAction) return;

            catAnimator.SetTrigger(AnimationTrigger.PlayAction);
            EventBus.FireEvent<ActionStartedEvent>(new ActionStartedEvent() { ActionDescription = settings.PlayAction.Description });
            gameManager.StartCoroutine(coroutineSignature = PerformAction(
                settings.PlayAction.AnimationLength,
                settings.PlayAction.MoodToChangeInto,
                true
            ));
        }
        public virtual void GetKicked() {
            if (performingAction) return;

            catAnimator.SetTrigger(AnimationTrigger.KickAction);
            EventBus.FireEvent<ActionStartedEvent>(new ActionStartedEvent() { ActionDescription = settings.KickAction.Description });
            gameManager.StartCoroutine(coroutineSignature = PerformAction(
                settings.KickAction.AnimationLength,
                settings.KickAction.MoodToChangeInto,
                true
            ));
        }
        #endregion
    }
}
