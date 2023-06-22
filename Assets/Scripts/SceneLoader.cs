using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SceneLoader>(); // Eewww
            }
            return _instance;
        }
    }
    private static SceneLoader _instance;
   
    [SerializeField] ProgressBar _progressBar;
    [SerializeField] GameObject _loadingView;
   
    void Awake(){
        if(SceneLoader.Instance != null && SceneLoader.Instance != this){
            Destroy(this);
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(int sceneID){
        StartCoroutine(LoadSceneAsync(sceneID));
    }

    private IEnumerator LoadSceneAsync(int sceneID){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        _loadingView.SetActive(true);
        
        while(!operation.isDone){
            _progressBar.Progress = operation.progress / 0.9f;
            yield return null;
        }

        _loadingView.SetActive(false);
    }
}
