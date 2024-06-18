using UnityEngine;

public class MusicTrigger : MonoBehaviour
{
    [SerializeField] private RandomMusicPlayer musicPlayer;
    [SerializeField] private FlickeringLight flickeringLight;
    [SerializeField] private RandomAudio randomAudio;
    [SerializeField] private LampController lampController;
    [SerializeField] private SwitchMusic switchMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            musicPlayer.TriggerMusicChange();
            flickeringLight.ChangeColor();
            randomAudio.PlayRandomClip();
            lampController.ActivateRandomLamps();
            switchMusic.SwitchSound();
        }
    }
}
