using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    
    [SerializeField]
    private string guiName;

    [SerializeField] 
    private string levelName;

    [SerializeField] private GameObject playerAndCameraPrefab;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
            DontDestroyOnLoad(this.gameObject);
        }
        
        else Destroy(this.gameObject);
    }


    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Initialization")
            StartGameFromInitialization();
        else
            StartGameFromLevel();
    }

    private void StartGameFromLevel()
    {
        SceneManager.LoadScene(guiName, LoadSceneMode.Additive);
        
        Vector3 playerStartPosition = GameObject.Find("PlayerStart").transform.position;

        Instantiate(playerAndCameraPrefab, playerStartPosition, Quaternion.identity);
    }



    public void StartGameFromInitializationDebug()
        {
            SceneManager.LoadScene(guiName);

            SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Additive).completed += operation =>
            {
                Scene levelScene = default;

                for (int i = 0; i < SceneManager.sceneCount; i++)
                {
                    if (SceneManager.GetSceneAt(i).name == levelName)
                    {
                        levelScene = SceneManager.GetSceneAt(i);
                        break;
                    }
                }

                if (levelScene != default) SceneManager.SetActiveScene(levelScene);

                Vector3 playerStartPosition = GameObject.Find("PlayerStart").transform.position;

                Instantiate(playerAndCameraPrefab, playerStartPosition, Quaternion.identity);
            };
        }

    private void StartGameFromInitialization()
    {
        SceneManager.LoadScene("Splash");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    }

    

