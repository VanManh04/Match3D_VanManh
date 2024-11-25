using UnityEngine;

[SerializeField]
public class Object_Parent : MonoBehaviour
{
    [SerializeField] protected string id_Object;
    [SerializeField] protected string name_Object;
    [SerializeField] protected bool unlock;

    [ContextMenu("Generate Object Id")]
    public void GenerateId() => id_Object = System.Guid.NewGuid().ToString();

    public virtual string Get_ID() {  return id_Object; }
}