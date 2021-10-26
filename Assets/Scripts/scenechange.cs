using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechange : MonoBehaviour
{
    [SerializeField] private string secondScene;

    public void Scene2()
    {
        SceneManager.LoadScene(secondScene);
    }

}

