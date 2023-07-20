using UnityEngine;
using UnityEngine.SceneManagement;

namespace Clock.UI
{
    public class OpenSceneButton : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        public virtual void OnClick()
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}