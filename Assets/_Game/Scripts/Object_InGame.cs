using UnityEngine;
public class Object_InGame : Object_Parent
{
    public Transform pos1, pos2;
    public bool Equalpos;
    Rigidbody rb;

    float coundownOut = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        coundownOut -= Time.deltaTime;

        if (coundownOut > 0)
            return;

        Equalpos = transform.parent != null;
        //Debug.Log(transform.parent);
        if (Equalpos)
        {
            rb.velocity = Vector3.zero;
            return;
        }
        if (Vector3.Distance(transform.position, pos1.position) < 1f)
        {
            if (pos1.childCount < 1)
            {
                transform.parent = pos1;
                transform.position = pos1.position;
                Equalpos = true;
                GameController.instance.AddToList(this);
            }
            else
                OutVelocity();
        }
        else if (Vector3.Distance(transform.position, pos2.position) < 1f)
        {
            if (pos2.childCount < 1)
            {
                transform.parent = pos2;
                transform.position = pos2.position;
                Equalpos = true;
                GameController.instance.AddToList(this);
            }
            else
                OutVelocity();
        }
        else
            transform.parent = null;
    }

    private void OnMouseDown()
    {
        print(gameObject.name + " Down");
        rb.isKinematic = true;
        rb.useGravity = false;
        GameController.instance.RemoveToList(this);
    }

    private void OnMouseDrag()
    {
        print(gameObject.name + " Drang");

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
        transform.parent = null;
        print(gameObject.name + " Up");
        rb.useGravity = true;
        rb.isKinematic = false;
        GameController.instance.RemoveToList(this);
    }

    public void OutVelocity()
    {
        coundownOut = 2;
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 10f);
    }

    public override string Get_ID()
    {
        return base.Get_ID();
    }
}