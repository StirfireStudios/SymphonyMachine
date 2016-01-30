using UnityEngine;
using Jam.Actions;

namespace Jam.Symbols
{
    /// Test helper
    public class HistoryLayoutTests : MonoBehaviour
    {
        public bool done = false;

        public int state = 0;

        public void Update()
        {
            if (!done)
            {
                state = 0;
                done = true;
            }
            if (state == 0)
            {
                int count = 0;
                foreach (var target in Scene.FindComponents<SelectSymbol>())
                {
                    target.action.execute = true;
                    count += 1;
                    if (count > 10)
                    {
                        break;
                    }
                }
                state = 1;
            }
            else if (state == 1)
            {
                Scene.FindComponent<RunSymbols>().action.execute = true;
                state = 2;
            }
        }
    }
}
