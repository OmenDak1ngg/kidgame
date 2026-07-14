
using UnityEngine;
using UnityEngine.SceneManagement;

public class ParametresCloseButton : CloseButton
{
    private string SceneName = "SampleScene";

    protected override void OnClick()
    {
        SceneManager.LoadScene(SceneName);
        base.OnClick();
    }
}
