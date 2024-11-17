using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoTransition : MonoBehaviour
{
    private UnityEngine.Video.VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();

        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene("Main Menu");
    }
}
