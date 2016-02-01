using UnityEngine;

namespace Jam.Actions
{
    /// Callback type
    public delegate void TaskComplete(ITask task);

    /// Dispatch task execution interface
    public interface ITask
    {
        void Execute(TaskComplete callback);
    }
}
