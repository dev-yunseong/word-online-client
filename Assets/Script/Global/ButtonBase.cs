using UnityEngine;
using UnityEngine.UI;

public abstract class ButtonBase : MonoBehaviour
{
    private AudioSource audioSource = null;
    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = SceneContext.Instance.gameObject.AddComponent<AudioSource>();
        }
    }

    protected abstract void OnClickButton();

    public void ButtonEvent()
    {
        PlayUISound();
        OnClickButton();
    }

    private void PlayUISound()
    {
        audioSource.clip = SoundAssets.ClickButton;
        audioSource.Play();
    }
}
