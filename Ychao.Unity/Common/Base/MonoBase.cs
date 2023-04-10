using UnityEngine;

namespace Ychao.Unity
{
    public abstract class MonoBase : MonoBehaviour, IMonoBinds
    {
        public GameObject BindsGameObject => gameObject;

        public Transform Parent { get => this.transform.parent; set => this.SetParent(value); }

        public abstract int UID { get; }

        public bool activeSelf { get => BindsGameObject.activeSelf; set => BindsGameObject.SetActive(value); }

        public bool Enable { get => enabled; set => enabled = value; }

        public bool activeSelfInHierarchy => BindsGameObject.activeInHierarchy;
    }
}
