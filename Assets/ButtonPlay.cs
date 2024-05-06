using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    [SerializeField]
    public string sceneName = "SampleScene"; 

    
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}