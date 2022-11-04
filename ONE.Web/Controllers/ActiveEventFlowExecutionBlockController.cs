using Microsoft.AspNetCore.Mvc;
using ONE.DataAccess.Repositories;
using ONE.Models.Domain;

namespace ONE.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActiveEventFlowExecutionBlockController : Controller
    {
        private IActiveEventFlowExecutionTrackingRepository _activeEventFlowExecutionTrackingRepository = null;
        public ActiveEventFlowExecutionBlockController(IActiveEventFlowExecutionTrackingRepository eventFlowActivationBlockTrackRepository)
        {
            _activeEventFlowExecutionTrackingRepository = eventFlowActivationBlockTrackRepository;
        }

        //[HttpGet]
        [HttpPost("/api/ActiveEventFlowExecution/UpdateActiveEventFlowExecutionBlockState")]
        public string UpdateActiveEventFlowExecutionBlockState(ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrackingInfo)
        {


            ActiveEventFlowExecutionTrackingInfo activeEventFlowExecutionTrack = _activeEventFlowExecutionTrackingRepository.GetActiveEventFlowExecutionTracking(activeEventFlowExecutionTrackingInfo);

            _activeEventFlowExecutionTrackingRepository.UpdateActiveEventFlowExecutionTracking(activeEventFlowExecutionTrackingInfo);

            return "Ok";
        }
    }
}
