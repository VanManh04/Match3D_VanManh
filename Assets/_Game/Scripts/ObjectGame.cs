using UnityEngine;

public enum Type
{
    Fool,
    Sword,
    Gun,
    houseProps
}

public class ObjectGame : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [Space(20)]

    [SerializeField] private Type type;
    private int id_Object;
    [SerializeField] private string name_Object;
    [SerializeField] private bool lockObject;

    #region GET - SET
    public int id
    {
        get { return id_Object; }
        set { id_Object = value; }
    }

    public bool isLock
    {
        get { return lockObject; }
        set { lockObject = value; }
    }
    #endregion

    private void OnValidate()
    {
        rb = GetComponent<Rigidbody>();
        name_Object = gameObject.name;
    }

    private void OnMouseDown()
    {
        //print(gameObject.name + " Down");
        rb.isKinematic = true;
        rb.useGravity = false;
    }

    private void OnMouseDrag()
    {
        //print(gameObject.name + " Drang");

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 worldPos = hit.point;
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(worldPos.x, 5, worldPos.z), speedMove * Time.deltaTime);
            rb.MovePosition(new Vector3(worldPos.x, 5, worldPos.z));
        }
    }

    private void OnMouseUp()
    {
        //print(gameObject.name + " Up");
        rb.useGravity = true;
        rb.isKinematic = false;
    }

    public void SetVelocity(Vector3 _Velocity) => rb.velocity = _Velocity;

    public void OutTable()
    {
        rb.isKinematic = false;
        rb.velocity = Vector3.forward * 8;
    }

    public void InTable()
    {
        rb.isKinematic = true;
        rb.velocity = Vector3.zero;
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
