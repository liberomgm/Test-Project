using UnityEngine;

namespace MainMenu
{
    public class LogForExit : MonoBehaviour
    {
        [SerializeField]
        private void ExitGame()
        {
            Debug.Log("Close game");
            Application.Quit();
        }
    }
}
