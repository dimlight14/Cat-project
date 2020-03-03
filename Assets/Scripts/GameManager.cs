using System.Collections;
using System.Collections.Generic;
using CatSimulator.States;
using UnityEngine;

namespace CatSimulator
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private StateSettings happyStateSettings = null;
        [SerializeField] private StateSettings angryStateSettings = null;
        [SerializeField] private StateSettings goodStateSettings = null;
        [SerializeField] private Animator catAnimator = null;
        [SerializeField] private ParticleSystem heartParticles = null;
        [SerializeField] private ParticleSystem skullParticles = null;
        public ParticleSystem HeartParticles { get => heartParticles; }
        public ParticleSystem SkullParticles { get => skullParticles; }

        private CatState currentState;
        private Dictionary<CatMood, CatState> availibleStates = new Dictionary<CatMood, CatState>();


        public void Start() {
            availibleStates.Add(CatMood.Happy, new HappyState(this, happyStateSettings, catAnimator));
            availibleStates.Add(CatMood.Angry, new AngryState(this, angryStateSettings, catAnimator));
            availibleStates.Add(CatMood.Good, new GoodState(this, catAnimator, goodStateSettings));
            TransitionToState(CatMood.Good);
        }

        public void PetCat() {
            currentState.GetPet();
        }
        public void KickCat() {
            currentState.GetKicked();
        }
        public void FeedCat() {
            currentState.FeedAction();
        }
        public void PlayWithCat() {
            currentState.GetPlayedWith();
        }

        public void TransitionToState(CatMood mood) {
            currentState = availibleStates[mood];
            currentState.StartState();
        }
    }
}
