using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



    public class GameManager : MonoBehaviour
    {
    
        public static GameManager Instance { get; private set; }

        public event System.Action<SceneType> OnSceneChanged;
        public event System.Action<int> OnScoreChanged;

        private void Awake()
        {
            SingletonThisObject();
        }

        private IEnumerator Start()
        {
            yield return SceneManager.LoadSceneAsync("Menu", LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Menu"));

           
        }

        private void SingletonThisObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void SplashScreen(SceneType sceneTypeEnum)
        {
            StartCoroutine(SplashScreenAsync(sceneTypeEnum));
        }

        private IEnumerator SplashScreenAsync(SceneType sceneType)
        {
            yield return SceneManager.LoadSceneAsync(SceneType.SplashScreen.ToString(), LoadSceneMode.Additive);
            OnSceneChanged?.Invoke(SceneType.SplashScreen);

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());

            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SplashScreen"));

            yield return new WaitForSeconds(5f);

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            yield return SceneManager.LoadSceneAsync(sceneType.ToString(), LoadSceneMode.Additive);

            OnSceneChanged.Invoke(sceneType);

            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneType.ToString()));
        }

        public void QuitGame()
        {
            Application.Quit();
        }

      

     
        
    }


