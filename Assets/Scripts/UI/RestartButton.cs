using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : UIButton
{
    private string SceneName = "SampleScene";

    protected override void OnClick()
    {
        SceneManager.LoadScene(SceneName);
    }
}
