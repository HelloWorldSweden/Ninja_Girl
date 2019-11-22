using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //public float loadNextLevelAfter;
    // Use this for initialization
    public float loadNextLevelAfter;
    void Start()
    {

        if (loadNextLevelAfter <= 0)
        {
            Debug.Log("You have to go to the next level.");
        }
        else
        {
            Invoke("loadNextLevel", loadNextLevelAfter);
            //Execute first argument(which is a method) after the second argument.
            //Second parameter is time.
        }

    }

    public void loadLevel(string name)
    {
        Debug.Log("We want to go the this level " + name);
        Application.LoadLevel(name);
    }

    public void loadNextLevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void QuitRequest()
    {
        Debug.Log("I Want to Quit");
        Application.Quit();
    }
}
