using UnityEngine;

public class transform : MonoBehaviour
{
    [SerializeField]private float moveSpeed;
    [SerializeField] private float rotationSpeed; 
    [SerializeField]private Transform[] wayPoints;
    bool isTurn;
    private int index;
    private void Start()
    {
        index = 0;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[index].position,moveSpeed*Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoints[index].position) <= 0.01f)
        {
            index++;
            isTurn = true;
            if(index>wayPoints.Length-1)
            {
                index = 0;
            }
        }
            
        if (isTurn)
        {
            TurnRotation();
        }
    }
    private void TurnRotation()
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, wayPoints[index].rotation,rotationSpeed*Time.deltaTime);
    }
}
