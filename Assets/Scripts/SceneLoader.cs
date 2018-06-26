using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{


    public static SceneLoader _instance;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != null)
        {
            Destroy(this.gameObject);
        }

    }

    public static SceneLoader GetInstance()
    {
        return _instance;
    }

    private void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    void Start()
    {

#if !UNITY_EDITOR
        SceneManager.LoadScene(1,LoadSceneMode.Additive);
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
#endif
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(Reload());
        }
    }

    public void ReloadScene()
    {
        StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        if (_BackToTitle == true)
        {
            _FirstRun = false;
        }

        SceneManager.UnloadSceneAsync(2);
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
        yield return new WaitForEndOfFrame();

        if (_Retry == true)
        {
            _ShowMenu = false;
            MenuChecker._instance.MenuCheck();
            SceneSelecter._instance.PlayLastScene();
            _Retry = false;
            yield break;
        }
        else if (_Retry == false)
        {
            _ShowMenu = true;
            MenuChecker._instance.MenuCheck();
        }
        yield break;

    }


}
