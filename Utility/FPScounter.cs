using UnityEngine;
using UnityEngine.UI;

// UI tool for counting FPS at runtime. Will not be included in final project files.
 
public class FPScounter : MonoBehaviour
{
    public Text _fpsText;
    [SerializeField] private float _hudRefreshRate = 1f;
 
    private float _timer;
 
    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            _fpsText.text = "FPS: " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }
}
