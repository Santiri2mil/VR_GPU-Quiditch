//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;


//public class SceneController : MonoBehaviour
//{
//    // Método para cargar una escena por su nombre
//    public void LoadScene(string sceneName)
//    {
//        // Verifica que la escena solicitada esté en la build
//        if (Application.CanStreamedLevelBeLoaded(sceneName))
//        {
//            SceneManager.LoadScene(sceneName);
            
//        }
//        else
//        {
//            Debug.LogError("La escena " + sceneName + " no está disponible en la build.");
//        }
//    }

//    // Método para cargar una escena por su índice
//    public void LoadSceneByIndex(int sceneIndex)
//    {
//        if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
//        {
//            SceneManager.LoadScene(sceneIndex);
//        }
//        else
//        {
//            Debug.LogError("El índice de escena " + sceneIndex + " está fuera de los límites.");
//        }
//    }

//    // Método para recargar la escena actual
//    public void ReloadCurrentScene()
//    {
//        Scene currentScene = SceneManager.GetActiveScene();
//        SceneManager.LoadScene(currentScene.name);
//    }

//    // Método para cargar la siguiente escena según el orden de la build
//    public void LoadNextScene()
//    {
//        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
//        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
//        SceneManager.LoadScene(nextSceneIndex);
//    }

//    // Método para salir del juego (funciona solo en compilación)
//    public void QuitGame()
//    {
//        Debug.Log("Saliendo del juego...");
//        Application.Quit();
//    }
//}
