using UnityEngine;

namespace Ychao.Unity
{
    public interface IMonoBinds
    {
        GameObject BindsGameObject { get; }
        public Transform Parent { get; set; }
        int UID { get; }
        bool activeSelf { get; set; }
        bool activeSelfInHierarchy { get; }
        bool Enable { get; set; }
    }
}
