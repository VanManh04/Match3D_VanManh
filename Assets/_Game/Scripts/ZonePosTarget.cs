using UnityEngine;

public class ZonePosTarget : MonoBehaviour
{
    public ObjectGame gameObjectInTable = null;
    public bool dontDelete;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name + "In");

        if (other.gameObject.tag == "Zone")
            return;

        if (gameObjectInTable == null)
        {
            gameObjectInTable = other.gameObject.GetComponent<ObjectGame>();
            gameObjectInTable.transform.position = transform.position;
            ComparisonTable.instance.AddObjectList(gameObjectInTable);
            //gameObjectInTable.InTable();
        }else
        {
            dontDelete = true;
            other.gameObject.GetComponent<ObjectGame>().OutTable();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.LogWarning(newGameObject.name + "out");
        if (dontDelete)
        {
            dontDelete = false;
            return;
        }
        ComparisonTable.instance.RemoveObjectList(gameObjectInTable);
        gameObjectInTable = null;
    }
}
