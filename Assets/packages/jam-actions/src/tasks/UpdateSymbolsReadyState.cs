using UnityEngine;
using Jam.Symbols;

namespace Jam.Actions
{
    public class UpdateSymbolsReadyState : ITask
    {
        public bool ready;

        public ParticleSystem emitter;

        public UpdateSymbolsReadyState(bool ready, PlayerSymbolState player)
        {
            this.ready = ready;
            this.emitter = player.symbolConfig.readyNotice;
        }

        public void Execute(TaskComplete callback)
        {
            if (emitter != null)
            {
                emitter.enableEmission = ready;
            }

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
