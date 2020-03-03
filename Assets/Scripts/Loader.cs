using UnityEngine;
using UnityEngine.SceneManagement;

namespace CatSimulator
{
    public class Loader : MonoBehaviour
    {
        public void StartGame() {
            SceneManager.LoadScene(1);
        }
    }
}
