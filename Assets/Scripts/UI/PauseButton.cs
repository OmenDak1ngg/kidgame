using UnityEngine;

public class PauseButton : UIButton
{
    protected override void OnClick()
    {
        if (PauseManager.IsPaused)
            PauseManager.Resume();
        else
            PauseManager.Pause();
    }
}
