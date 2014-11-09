
using UnityEngine;

public class CameraController : MonoBehaviour
{
    #region Consts
    private const float SMOOTH_TIME = 0.3f;
    #endregion

    #region Public Properties
    public bool LockX;
    public bool LockY;
    public bool LockZ;
    public bool useSmoothing;
    public Transform target;
    public Vector2 position = Vector2.zero;
    #endregion

    #region Private Properties
    private Transform thisTransform;
    private Vector3 moveDirection;
    #endregion

    private void Awake()
    {
        thisTransform = transform;

        moveDirection = new Vector3(0.5f, 0.5f, 0.5f);
    }

    // ReSharper disable UnusedMember.Local
    private void LateUpdate()
    // ReSharper restore UnusedMember.Local
    {
        var newPos = Vector3.zero;

        if (useSmoothing)
        {
			if(target == null) 
				return;

            newPos.x = Mathf.SmoothDamp(thisTransform.position.x, target.position.x, ref moveDirection.x, SMOOTH_TIME);
            newPos.y = Mathf.SmoothDamp(thisTransform.position.y, target.position.y, ref moveDirection.y, SMOOTH_TIME);
            newPos.z = Mathf.SmoothDamp(thisTransform.position.z, target.position.z, ref moveDirection.z, SMOOTH_TIME);
        }
        else
        {
            newPos.x = target.position.x + position.x;
            newPos.y = target.position.y + position.y;
            newPos.z = target.position.z;
        }

        #region Locks
        if (LockX)
        {
            newPos.x = thisTransform.position.x;
        }

        if (LockY)
        {
            newPos.y = thisTransform.position.y;
        }

        if (LockZ)
        {
            newPos.z = thisTransform.position.z;
        }
        #endregion

        transform.position = Vector3.Slerp(transform.position,newPos, Time.time);
    }
}