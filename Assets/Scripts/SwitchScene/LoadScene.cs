using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace SwitchScene
{
    public class LoadScene : MonoBehaviour
    {
        [SerializeField]
        private int sceneID;

        [SerializeField]
        private Slider loadSlider;

        private void Start()
        {
            StartCoroutine(LoadNextScene());
        }

        [SerializeField]
        private IEnumerator LoadNextScene()
        {
            AsyncOperation oper = SceneManager.LoadSceneAsync(sceneID);
            while (!oper.isDone)
            {
                float progress = oper.progress / 0.9f;
                loadSlider.value = progress;
                yield return null;
            }
        }
    }
}