using UnityEngine;

namespace OptionMenu
{
    public class WebSiteURLButton : MonoBehaviour
    {
        private const string POLITICS_URL = "https://ru.wikipedia.org/wiki/Игра";
        public void Transition()
        {
            Application.OpenURL(POLITICS_URL);
        }
    }
}