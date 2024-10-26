using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class ShipPartConnectionPoint : MonoBehaviour
{
    public GameObject glovingZone;
    public float xOffset,yOffset;   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void setGlovingZone(){
        glovingZone.SetActive(true);
    }
}
#if UNITY_EDITOR
[CustomEditor(typeof(ShipPartConnectionPoint))]
    public class ShipPartConnectionPointEditor : Editor
    {
    public override void OnInspectorGUI()
    {
        ShipPartConnectionPoint shipPartConnectionPoint= (ShipPartConnectionPoint) target;
        if(shipPartConnectionPoint.glovingZone!=null)shipPartConnectionPoint.glovingZone.transform.position=shipPartConnectionPoint.transform.position+ new  Vector3(shipPartConnectionPoint.xOffset,shipPartConnectionPoint.yOffset); 
        base.OnInspectorGUI();
    }
}
#endif
