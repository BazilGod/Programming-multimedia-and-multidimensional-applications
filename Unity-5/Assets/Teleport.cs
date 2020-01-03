using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour
{
    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "portal1")
        {
            gameObject.transform.position = new Vector3(263.87f, 81.62f, 246.49f);
        }
        else if (collision.collider.name == "door")
        {
            StartCoroutine(LoadYourAsyncScene("Scene3"));

        }
        else if(collision.collider.name == "Scene1Door")
        {
            StartCoroutine(LoadYourAsyncScene("Scene1"));
        }
    }
    IEnumerator LoadYourAsyncScene(string sceneName)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName.ToString(), LoadSceneMode.Additive);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        characterController.gameObject.transform.position = new Vector3(67f, 0.64f, -65f);
        SceneManager.MoveGameObjectToScene(characterController.gameObject, SceneManager.GetSceneByName(sceneName.ToString())); 
        SceneManager.UnloadSceneAsync(currentScene);
    }
}
