using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
public class ChangeSceneOnTimer : MonoBehaviour
{
    [SerializeField] bool isChangingScene = false;
    [SerializeField] PlayableDirector timeline;
    [SerializeField] int sceneNumber;

    void Start()
    {
        Time.timeScale = 1f;
    }
    public void OnClick(){
        if (isChangingScene) return;
        StartCoroutine(StartSceneChange());
    }

    IEnumerator StartSceneChange()
    {
        timeline.Play();
        isChangingScene = true;
        yield return new WaitForSeconds((float)timeline.duration);
        isChangingScene = false;
        SceneManager.LoadScene(sceneNumber);
    }
}
