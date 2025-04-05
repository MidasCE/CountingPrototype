using UnityEngine;

public class ProbObject : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            gameObject.tag = "Bad";
        } 
    }
}
