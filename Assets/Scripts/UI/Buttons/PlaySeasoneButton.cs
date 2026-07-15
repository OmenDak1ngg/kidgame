using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaySeasoneButton : UIButton
{
    [SerializeField] private string _sceneName;

    protected override void OnClick()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
