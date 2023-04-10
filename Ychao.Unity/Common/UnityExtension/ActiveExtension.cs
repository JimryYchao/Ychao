using UnityEngine;

namespace Ychao.Unity
{
    public static class ActiveExtension
    {
        public static void SetActiveSelf(this GameObject go, bool active)
        {
            go.SetActive(active);
        }

        public static void SetActiveSelf(this Component go, bool active)
        {
            go.gameObject.SetActiveSelf(active);
        }

        public static bool ActiveInverse(this GameObject go)
        {
            go.SetActive(!go.activeSelf);
            return go.activeSelf;
        }

        public static bool ActiveInverse(this Component go)
        {
            return go.gameObject.ActiveInverse();
        }
    }
}
