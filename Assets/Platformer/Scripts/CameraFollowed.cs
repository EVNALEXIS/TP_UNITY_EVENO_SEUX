using UnityEngine;

public class CameraFollowed : MonoBehaviour
{
    public GameObject player;
    public float offset;
    public Vector3 posOffset;

    private Vector3 velocity;


    void Update()
    {
        transform.position =  Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, offset);
        
    }
}
