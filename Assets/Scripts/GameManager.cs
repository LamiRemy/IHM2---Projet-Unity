using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Page 27 du TP Unity Advanced

    Problèmes :
        _Animations FadeIn & FadeOut ne fonctionnent pas
        _Regarder pour le menu comment vérifier qu'une scène ne se charge qu'une fois 
        (la scène se charge à chaque image/seconde ce qui est emmerdant)

*/

public class GameManager : Singleton<GameManager> {

    public GameObject[] SystemPrefabs;
    private List<GameObject> _instanciedSystemPrefabs;

    private string _currentLevelName = string.Empty;
    List<AsyncOperation> _loadOperations;


    public void Start()
    {
        _instanciedSystemPrefabs = new List<GameObject>();
        InstantiateSystemPrefabs();

        _loadOperations = new List<AsyncOperation>();
        //LoadLevel("Level1");

    }


    public void InstantiateSystemPrefabs()
    {
        GameObject prefabInstance;
        for (int i = 0; i < SystemPrefabs.Length; ++i)
        {
            prefabInstance = Instantiate(SystemPrefabs[i]);
            _instanciedSystemPrefabs.Add(prefabInstance);
        }
    }


    protected override void OnDestroy()
    {
        for (int i = 0; i < _instanciedSystemPrefabs.Count; ++i) // Détruit les GameObjets de la liste
            Destroy(_instanciedSystemPrefabs[i]);

        _instanciedSystemPrefabs.Clear();

        base.OnDestroy(); // Appelle la méthode parente pour détruire le singleton
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

        DontDestroyOnLoad(gameObject); // Empéche la destruction du GameManage

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
