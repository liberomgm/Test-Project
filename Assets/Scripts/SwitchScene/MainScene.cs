using UnityEngine;
using UnityEngine.SceneManagement;

namespace SwitchScene
{
    public class MainScene : MonoBehaviour
    {
        [SerializeField]
        private void OnClickLoadScene()
        {
            SceneManager.LoadScene(1);
        }
    }
}
