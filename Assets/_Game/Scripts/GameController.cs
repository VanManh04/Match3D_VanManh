using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private List<Object_InGame> list = new List<Object_InGame>();

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {

    }

    void Update()
    {
        //GetPosMouse();
        if (list.Count >= 2)
        {
            if (list[0].Get_ID() == list[1].Get_ID())
            {
                Destroy(list[0].gameObject);
                Destroy(list[1].gameObject);
                list.Clear();
            }
            else
            {
                list[1].transform.parent = null;
                list[1].OutVelocity();
                list.Remove(list[1]);
            }
        }
    }

    private static void GetPosMouse()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 worldPos = hit.point;
                //Debug.Log($"Pos in the Gioi: {worldPos}");

                if (hit.collider.CompareTag("Player"))
                {

                }
                //Debug.Log($"Raycast -> tag = {hit.collider.tag}");
            }
        }
    }

    public void AddToList(Object_InGame _gameObject) => list.Add(_gameObject);
    public void RemoveToList(Object_InGame _gameObject) => list.Remove(_gameObject);
}
