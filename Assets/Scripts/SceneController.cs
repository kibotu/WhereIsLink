using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

    public void LoadScene(string Id)
    {
        Application.LoadLevel(Id);
    }
}
