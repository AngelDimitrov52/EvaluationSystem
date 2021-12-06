using System.ComponentModel;

namespace EvaluationSystem.Domain.Enums
{
    public enum AttestationStatus
    {
        Open,
        [Description("In Progress")] InProgress,
        Done
    }
}
