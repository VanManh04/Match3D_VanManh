using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
[ExecuteInEditMode]
public class OnEnble : MonoBehaviour
{
    public Transform childTransform;
    public Vector3 posChild;
    public float scaleChildF = 1;
    public BoxCollider box;

    public bool name_ = true, scaleChild = true, setPosChild = true, setBoxCenter;

    [Space]
    public bool Destroy_;

    private void OnValidate()
    {
        if (Destroy_)
            DestroyImmediate(GetComponent<OnEnble>());

        transform.GetChild(0).gameObject.SetActive(true);
        if (name_)
            Name();
        if (setPosChild)
            SetPosChild();
        if (setBoxCenter)
            SetBoxCenter();
        if (scaleChild)
            ScaleChild();
    }

    private void ScaleChild()
    {
        if (transform.childCount > 0)
        {
            childTransform = transform.GetChild(0);
            if (childTransform != null)
            {
                childTransform.localScale = Vector3.one * scaleChildF;
                Debug.Log("OK");
            }
        }
        else
        {
            Debug.LogWarning("No child found!");
        }
    }

    private void SetBoxCenter()
    {
        box = GetComponent<BoxCollider>();
        if (transform.childCount > 0)
        {
            childTransform = transform.GetChild(0);
            if (childTransform != null)
            {
                float z = box.center.z + childTransform.position.z;
                box.center = new Vector3(box.center.x, box.center.y, z);
                Debug.Log("OK");
            }
        }
        else
        {
            Debug.LogWarning("No child found!");
        }
    }

    private void SetPosChild()
    {
        if (transform.childCount > 0)
        {
            childTransform = transform.GetChild(0);
            if (childTransform != null)
            {
                childTransform.localPosition = posChild;
                Debug.Log(childTransform.position);
                Debug.Log(posChild);
                Debug.Log("OK");
            }
        }
        else
        {
            Debug.LogWarning("No child found!");
        }
    }

    private void Name()
    {
        if (transform.childCount > 0)
        {
            childTransform = transform.GetChild(0);
            if (childTransform != null)
            {
                transform.name = childTransform.gameObject.name;
                Debug.Log(childTransform.gameObject.name);
            }
        }
        else
        {
            Debug.LogWarning("No child found!");
        }
    }

    private void OnEnable()
    {
        OnValidate();
    }
}
