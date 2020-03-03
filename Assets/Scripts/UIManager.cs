using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CatSimulator
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image kickButtonImage, petButtonImage, playButtonImage, feedButtonImage;
        [Space(10)]
        [SerializeField] private Text actionDescription;
        [SerializeField] private Text moodDescrition;
        [SerializeField] private Material grayscaleMaterial;

        private void Start() {
            EventBus.Subscribe<MoodChangedEvent>(OnMoodChanged);
            EventBus.Subscribe<ActionStartedEvent>(OnActionStarted);
            EventBus.Subscribe<ActionEndedEvent>(OnActionEnded);
        }

        private void OnMoodChanged(MoodChangedEvent customeEvent) {
            switch (customeEvent.NewMood) {
                case CatMood.Angry:
                    moodDescrition.text = "Angry";
                    break;
                case CatMood.Good:
                    moodDescrition.text = "Good";
                    break;
                case CatMood.Happy:
                    moodDescrition.text = "Happy";
                    break;
            }
        }
        private void OnActionEnded(ActionEndedEvent customeEvent) {
            kickButtonImage.material = null;
            playButtonImage.material = null;
            petButtonImage.material = null;
            feedButtonImage.material = null;
        }
        private void OnActionStarted(ActionStartedEvent customeEvent) {
            kickButtonImage.material = grayscaleMaterial;
            playButtonImage.material = grayscaleMaterial;
            petButtonImage.material = grayscaleMaterial;
            feedButtonImage.material = grayscaleMaterial;
            actionDescription.text = customeEvent.ActionDescription;
        }
    }
}
