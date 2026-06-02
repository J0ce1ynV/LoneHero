using UnityEngine;
using UnityEngine.Events;

public enum TypeTag
{
    Player,
    Trap,
    Checkpoint,
    Finish, 
    Trigger
}

public class EventTrigger : MonoBehaviour
{
    public TypeTag targetTag;
    public UnityEvent<GameObject> onTrigger;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Collider jalan");
        if(col.tag == targetTag.ToString())
        {
            Debug.Log(col.gameObject.name + "collide with" + gameObject.name);
            onTrigger.Invoke(col.gameObject);
        }
    }
}
