using System.Collections;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    //[SerializeField] private ItemType type;
    //public ItemType Type => type;

    [SerializeField] private int id;

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 2;

    private void OnValidate()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// kiem tra xem item co gan diem target hay khong
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public bool IsArrive(Vector3 target)
    {
        return Vector3.Distance(rb.position, target) < 0.1f;
    }

    public bool IsArrive(Vector3 target,float _distance)=> Vector3.Distance(rb.position, target) < _distance;

    /// <summary>
    /// di chuyen den vi tri target
    /// </summary>
    /// <param name="targetPoint"></param>
    public void OnMove(Vector3 targetPoint) => rb.position = Vector3.MoveTowards(rb.position, targetPoint, Time.deltaTime * speed);

    /// <summary>
    /// di chuyen den vi tri target
    /// </summary>
    /// <param name="targetPoint"></param>
    /// <param name="targetRot"></param>
    /// <param name="time"></param>
    public void OnMove(Vector3 targetPoint, Quaternion targetRot, float time) => StartCoroutine(IEOnMove(targetPoint, targetRot, time));

    private IEnumerator IEOnMove(Vector3 _scale, Quaternion targetRot, float time)
    {
        float timeCount = 0;
        Vector3 startPoint = rb.position;
        Quaternion startRot = rb.rotation;

        while (timeCount < time)
        {
            //loop theo thoi gian
            timeCount += Time.deltaTime;
            rb.position = Vector3.Lerp(startPoint, _scale, timeCount / time);
            rb.rotation = Quaternion.Lerp(startRot, targetRot, timeCount / time);
            yield return null;
        }
    }

    public void OnSelect()
    {
        //bat dau select
        StartCoroutine(IEScaleItem(Vector3.one * 1.2f, .5f));
        rb.useGravity = false;
    }

    public void OnDrop()
    {
        rb.useGravity = true;
    }

    public void ResetLocaScale()=> StartCoroutine(IEScaleItem(Vector3.one, .5f));

    private IEnumerator IEScaleItem(Vector3 _scale,float time)
    {
        float timeCount = 0;
        Vector3 startPoint = transform.localScale;

        while (timeCount < time)
        {
            //loop theo thoi gian
            timeCount += Time.deltaTime;
            transform.localScale = Vector3.Lerp(startPoint, _scale, timeCount / time);
            yield return null;
        }
    }

    public void Force(Vector3 force)
    {
        //add them 1 luc cho item
        OnDrop();
        rb.velocity = Vector3.zero;
        rb.AddForce(force);
    }

    internal void SetKinematic(bool v) => rb.isKinematic = v;

    internal void Collect()
    {
        //TODO: fix late
        gameObject.SetActive(false);
    }

    public int id_Object
    {
        get { return id; }
        set { id = value; }
    }
}
