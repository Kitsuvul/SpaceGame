/*
Notes:

*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class HelperScript : MonoBehaviour
{

    /// <summary>
    /// CalculateRotationHelper is a generic function to calculate the rotation needed for an object to face another object
    /// </summary>
    /// <param name="currentPos">The position of the object you want to rotate</param>
    /// <param name="posToFace">The position of the object you want to face</param>
    /// <returns>A Quaternion containing the angle of rotation</returns>
    public Quaternion CalculateRotationHelper(Vector2 currentPos, Vector2 posToFace)
    {
        Vector2 dir = currentPos - posToFace;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90.0f;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public Quaternion CalculateNegativeRotationHelper(Vector2 currentPos, Vector2 posToFace)
    {
        Vector2 dir = currentPos - posToFace;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90.0f;
        return Quaternion.AngleAxis(angle, -Vector3.forward);
    }

    public float CalculateAngleHelper(Vector2 currentPos, Vector2 posToFace)
    {
        Vector2 dir = currentPos - posToFace;
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90.0f;
        return angle;
    }

    public Vector2 GetVec2FromPositionHelper(Vector3 position)
    {
        return new Vector2(position.x, position.y);
    }

    public Vector2 GetReverseVector2(Vector3 position)
    {
        return new Vector2(-position.x, -position.y);
    }

    //// Serialize
    //public static string Serialize<T>(this T toSerialize)
    //{
    //    XmlSerializer xml = new XmlSerializer(typeof(T));
    //    StringWriter writer = new StringWriter();
    //    xml.Serialize(writer, toSerialize);
    //    return writer.ToString();
    //}
    //// De-serialize

    //public static T Deserialize<T>(this string toDeserialize)
    //{
    //    XmlSerializer xml = new XmlSerializer(typeof(T));
    //    StringReader reader = new StringReader(toDeserialize);
    //    return (T)xml.Deserialize(reader);
    //}
}
