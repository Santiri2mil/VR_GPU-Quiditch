//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;


//public class SceneController : MonoBehaviour
//{
//    // M�todo para cargar una escena por su nombre
//    public void LoadScene(string sceneName)
//    {
//        // Verifica que la escena solicitada est� en la build
//        if (Application.CanStreamedLevelBeLoaded(sceneName))
//        {
//            SceneManager.LoadScene(sceneName);
            
//        }
//        else
//        {
//            Debug.LogError("La escena " + sceneName + " no est� disponible en la build.");
//        }
//    }

//    // M�todo para cargar una escena por su �ndice
//    public void LoadSceneByIndex(int sceneIndex)
//    {
//        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
//        {
//            SceneManager.LoadScene(sceneIndex);
//        }
//        else
//        {
//            Debug.LogError("El �ndice de escena " + sceneIndex + " est� fuera de los l�mites.");
//        }
//    }

//    // M�todo para recargar la escena actual
//    public void ReloadCurrentScene()
//    {
//        Scene currentScene = SceneManager.GetActiveScene();
//        SceneManager.LoadScene(currentScene.name);
//    }

//    // M�todo para cargar la siguiente escena seg�n el orden de la build
//    public void LoadNextScene()
//    {
//        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
//        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
//        SceneManager.LoadScene(nextSceneIndex);
//    }

//    // M�todo para salir del juego (funciona solo en compilaci�n)
//    public void QuitGame()
//    {
//        Debug.Log("Saliendo del juego...");
//        Application.Quit();
//    }
//}
