using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePage : MonoBehaviour
{
    [SerializeField] private string _secondScene;
    [SerializeField] private string _thirdScene;
    [SerializeField] private string _fourthScene;
    [SerializeField] private string _fifthScene;
    [SerializeField] private string _sixthScene;
    [SerializeField] private string _seventhScene;
    [SerializeField] private string _gameScene;

    public void Gotopage2()
    {
        SceneManager.LoadScene(_secondScene);
        // GameObject.FindGameObjectWithTag("music").GetComponent<DontDestroyMusicBg>().PlayMusic();
    }

    public void Gotopage3()
    {
        SceneManager.LoadScene(_thirdScene);
    }

    public void Gotopage4()
    {
        SceneManager.LoadScene(_fourthScene);
    }

    public void Gotopage5()
    {
        SceneManager.LoadScene(_fifthScene);
    }

    public void Gotopage6()
    {
        SceneManager.LoadScene(_sixthScene);
    }

    public void GotopageHowtoplay()
    {
        SceneManager.LoadScene(_seventhScene);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(_gameScene);
    }
}

