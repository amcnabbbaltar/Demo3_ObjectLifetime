using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class ChangingScene : MonoBehaviour
{
    public GameObject objectToKeep;
    public int sceneIndex = 0;
    public string sceneName = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DontDestroyOnLoad(objectToKeep);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            //SceneManager.LoadScene(sceneName);
            SceneManager.LoadScene(sceneIndex);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
        
        }
    }
}
