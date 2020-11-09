using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [SerializeField] private string sceneName;
    private void OnCollisionEnter(Collision other)
    {
        foreach (var contactPoint in other.contacts)
        {
            if (contactPoint.otherCollider.CompareTag("Player"))
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
        }
    }
}