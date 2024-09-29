using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float loadSceneDelay = 1f;
    int indexScrene;
    public void LoadMainMenu() {
        SceneManager.LoadScene("Main Menu");
    }
    public void LoadGame() {
        SceneManager.LoadScene("Fly Over");
    }
    public void LoadGameOver() {
        StartCoroutine(WaitAndLoad("EndMenu", loadSceneDelay));
    }
    IEnumerator WaitAndLoad(string sceneName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
    public void LoadMenuLV()
    {
        SceneManager.LoadScene(15);
    }
    public void LoadLevel_1()
    {
        SceneManager.LoadScene(3);
    }
    public void LoadLevel_2()
    {
        SceneManager.LoadScene(5);
    }
    public void LoadLevel_3()
    {
        SceneManager.LoadScene(7);
    }
    public void LoadLevel_4()
    {
        SceneManager.LoadScene(9);
    }
    public void LoadLevel_5()
    {
        SceneManager.LoadScene(11);
    }
    public void LoadLevel_6()
    {
        SceneManager.LoadScene(13);
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene(1);
    }
    
    public void QuitGame() {
        Debug.Log("Quitting Game....");
        Application.Quit();
    }
}
