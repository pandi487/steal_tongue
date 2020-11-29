using UnityEngine.UI;
using UnityEngine;

namespace Steal_Tongue.Adapter
{
    public class UIAdapter : MonoBehaviour
    {
        public Text m_MoneyText = null;


        private void Start()
        {
            Debug.Assert(m_MoneyText != null);

        }
    }
}