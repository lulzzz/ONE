using ONE.Models.Domain;
using System.Collections.Generic;

namespace ONE.DataAccess.Repositories
{
    public interface IActiveEventFlowExecutionTrackingRepository
    {
        void AddActiveEventFlowExecutionTracking(ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo);
        void UpdateActiveEventFlowExecutionTracking(ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo);
        List<ActiveEventFlowExecutionTrackingInfo> GetActiveEventFlowExecutionTracking();
        ActiveEventFlowExecutionTrackingInfo GetActiveEventFlowExecutionTracking(ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo);
        void DeleteActiveEventFlowExecutionTracking(ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo);

    }
}
