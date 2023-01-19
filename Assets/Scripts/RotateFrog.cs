using UnityEngine;

public class RotateFrog : MonoBehaviour
{
    public float turnSpeed = 0.01f;
    public float targetChangeProbability = 0.5f;
    
    private Vector3 _targetPosition;
    
    private void Start()
    {
        RandomizeTargetPosition();
    }

    private void Update()
    {
        if (Random.value < targetChangeProbability) RandomizeTargetPosition();

        var direction = (_targetPosition - transform.position).normalized;
        var rotationGoal = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationGoal, turnSpeed);
    }

    private void RandomizeTargetPosition()
    {
        _targetPosition = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
    }
}
