using UnityEngine;

namespace Ychao.Unity
{
    public interface IMonoSingleComponent<T> where T : MonoBase
    {
        private static T m_singleComponent;

        


        //public static T AddSingleComponent(Transform bindsObj) { })

    }
}
