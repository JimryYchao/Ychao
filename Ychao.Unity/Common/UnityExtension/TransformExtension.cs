using System.Runtime.CompilerServices;
using UnityEngine;

namespace Ychao.Unity
{
    public static class TransformExtension
    {

        #region Set Transform

        public static void SetTransform(this Component go, Transform trans)
        {
            go.transform.position = trans.position;
            go.transform.rotation = trans.rotation;
            go.transform.localScale = trans.localScale;
        }
        public static void SetTransform(this GameObject go, Transform trans)
        {
            go.transform.position = trans.position;
            go.transform.rotation = trans.rotation;
            go.transform.localScale = trans.localScale;
        }

        #endregion


        #region Set Parent
        // co -> trans
        public static void SetParent(this Component go, Transform parent, bool worldPositionStays = true)
        {
            go.transform.SetParent(parent, worldPositionStays);
        }
        // go -> trans
        public static void SetParent(this GameObject go, Transform parent, bool worldPositionStays = true)
        {
            go.transform.SetParent(parent, worldPositionStays);
        }
        // co -> co
        public static void SetParent(this Component go, Component parent, bool worldPositionStays = true)
        {
            SetParent(go, parent.transform, worldPositionStays);
        }
        // go -> co
        public static void SetParent(this GameObject go, Component parent, bool worldPositionStays = true)
        {
            SetParent(go, parent.transform, worldPositionStays);
        }
        // co -> go
        public static void SetParent(this Component go, GameObject parent, bool worldPositionStays = true)
        {
            SetParent(go, parent.transform, worldPositionStays);
        }
        // go -> go
        public static void SetParent(this GameObject go, GameObject parent, bool worldPositionStays = true)
        {
            SetParent(go, parent.transform, worldPositionStays);
        }

        #endregion


        #region Set Position
        public static void SetPosition(this GameObject go, Vector3 vector, bool isLocal = false)
        {
            if (isLocal)
                go.transform.localPosition = vector;
            else
                go.transform.position = vector;
        }
        public static void SetPosition(this GameObject go, float x, float y, float z, bool isLocal = false)
        {
            var v3 = new Vector3(x, y, z);
            go.SetPosition(v3, isLocal);

        }
        public static void SetPosition(this GameObject go, float x, float y, bool isLocal = false)
        {
            go.SetPosition(x, y, isLocal ? go.transform.localPosition.z : go.transform.position.z, isLocal);
        }
        public static void SetPositionX(this GameObject go, float x, bool isLocal = false)
        {
            go.SetPosition(
                x,
                isLocal ? go.transform.localPosition.y : go.transform.position.y,
                isLocal ? go.transform.localPosition.z : go.transform.position.z,
                isLocal);
        }
        public static void SetPositionY(this GameObject go, float y, bool isLocal = false)
        {
            go.SetPosition(
                isLocal ? go.transform.localPosition.x : go.transform.position.x,
                y,
                isLocal ? go.transform.localPosition.z : go.transform.position.z,
                isLocal);
        }
        public static void SetPositionZ(this GameObject go, float z, bool isLocal = false)
        {
            go.SetPosition(
                isLocal ? go.transform.localPosition.x : go.transform.position.x,
                isLocal ? go.transform.localPosition.y : go.transform.position.y,
                z,
                isLocal);
        }

        public static void SetPosition(this Component go, Vector3 vector, bool isLocal = false)
        {
            if (isLocal)
                go.transform.localPosition = vector;
            else
                go.transform.position = vector;
        }
        public static void SetPosition(this Component go, float x, float y, float z, bool isLocal = false)
        {
            var v3 = new Vector3(x, y, z);
            go.SetPosition(v3, isLocal);

        }
        public static void SetPosition(this Component go, float x, float y, bool isLocal = false)
        {
            go.SetPosition(x, y, isLocal ? go.transform.localPosition.z : go.transform.position.z, isLocal);
        }
        public static void SetPositionX(this Component go, float x, bool isLocal = false)
        {
            go.SetPosition(
                x,
                isLocal ? go.transform.localPosition.y : go.transform.position.y,
                isLocal ? go.transform.localPosition.z : go.transform.position.z,
                isLocal);
        }
        public static void SetPositionY(this Component go, float y, bool isLocal = false)
        {
            go.SetPosition(
                isLocal ? go.transform.localPosition.x : go.transform.position.x,
                y,
                isLocal ? go.transform.localPosition.z : go.transform.position.z,
                isLocal);
        }
        public static void SetPositionZ(this Component go, float z, bool isLocal = false)
        {
            go.SetPosition(
                isLocal ? go.transform.localPosition.x : go.transform.position.x,
                isLocal ? go.transform.localPosition.y : go.transform.position.y,
                z,
                isLocal);
        }

        #endregion


        #region Set Rotation
        public static void SetRotation(this GameObject go, Quaternion quaternion, bool isLocal = false)
        {
            if (isLocal)
                go.transform.localRotation = quaternion;
            else
                go.transform.rotation = quaternion;
        }
        public static void SetRotation(this GameObject go, Vector3 ruler, bool isLocal = false)
        {
            if (isLocal)
                go.transform.localEulerAngles = ruler;
            else
                go.transform.eulerAngles = ruler;
        }

        public static void SetRotation(this Component go, Quaternion quaternion, bool isLocal = false)
        {
            go.gameObject.SetRotation(quaternion, isLocal);
        }
        public static void SetRotation(this Component go, Vector3 ruler, bool isLocal = false)
        {
            go.gameObject.SetRotation(ruler, isLocal);
        }

        #endregion


        #region Set Local Scale
        public static void SetLocalScale(this GameObject go, Vector3 scale)
        {
            go.transform.localScale = scale;
        }

        public static void SetLocalScale(this Component go, Vector3 scale)
        {
            go.transform.localScale = scale;
        }

        #endregion
    }
}
