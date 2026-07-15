using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButton : UIButton
{
    [SerializeField] private string _sceneName;

    protected override void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
