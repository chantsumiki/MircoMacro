using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public Object _env, _UI, _mainScene, _mainSystem;
    public Object[] _subScene;
    public Object[] _subSystem;


    private string Env, UI, MainScene, MainSystem;


    public static SceneLoader _instance;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            return;
        }
        Destroy(this.gameObject);


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

        Env = _env.name.ToString();
        UI = _UI.name.ToString();
        MainScene = _mainSystem.name.ToString();
        MainSystem = _mainSystem.name.ToString();


#if !UNITY_EDITOR
        SceneManager.LoadScene(UI,LoadSceneMode.Additive);
        SceneManager.LoadScene(MainScene,LoadSceneMode.Additive);
        SceneManager.LoadScene(MainSystem,LoadSceneMode.Additive);
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
        SceneManager.UnloadSceneAsync(MainSystem);
        yield return new WaitForEndOfFrame();
        SceneManager.LoadScene(MainSystem, LoadSceneMode.Additive);
        yield break;

    }


}
