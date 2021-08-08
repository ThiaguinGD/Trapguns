using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField] private float timeout;

    private void Start()
    {
        Destroy(gameObject, timeout);
    }
}