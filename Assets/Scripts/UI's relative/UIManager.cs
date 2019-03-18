using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] MainMenu _mainMenu;
    [SerializeField] string _defaultScene;

    public void Start()
    {
        _mainMenu.FadeIn();
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameManager.Instance.LoadLevel(_defaultScene);
            _mainMenu.FadeOut();
        }
    }


}
