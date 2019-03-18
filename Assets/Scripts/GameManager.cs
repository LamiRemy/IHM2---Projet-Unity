using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private static GameManager instance;

    private string _currentLevelName = string.Empty;
    List<AsyncOperation> _loadOperations;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            Debug.LogError("Yo don't do this bruh");
        }
    }

    public void Start()
    {
        _loadOperations = new List<AsyncOperation>();
        LoadLevel("Level1");

    }

    public void LoadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive);
        ao.completed += OnLoadOperationComplete;

        if (ao == null)
        {
            Debug.Log("[GameManager] Unable to load level " + levelName);
            return;
        }
        _loadOperations.Add(ao);
        _currentLevelName = levelName;

        DontDestroyOnLoad(gameObject);

    }

    public void UnloadLevel(string levelName)
    {
        AsyncOperation ao = SceneManager.UnloadSceneAsync(levelName);
        ao.completed += OnUnloadOperationComplete;

        if (ao == null)
        {
            Debug.Log("[GameManager] Unable to unload level " + levelName);
            return;
        }
        
    }

    private void OnLoadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Load complete !");
        if (_loadOperations.Contains(ao))
            _loadOperations.Remove(ao);
    }

    private void OnUnloadOperationComplete(AsyncOperation ao)
    {
        Debug.Log("Unload complete !");
    }
}
