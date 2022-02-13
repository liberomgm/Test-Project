using UnityEngine;

namespace MainMenu
{
    public class ExitWindowGame : MonoBehaviour
    {
        [SerializeField]
        private void ExitGame()
        {
            Debug.Log("Close game");
            Application.Quit();
        }
    }
}
