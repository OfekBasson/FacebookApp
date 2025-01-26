namespace AppLogic.HelperClasses
{
    public class LogicLayerResult
    {
        public ResultStatus m_Status { get; }
        public object m_ResultData { get; }
        public LogicLayerResult(ResultStatus i_ResultStatus, object i_ResultData)
        {
            m_Status = i_ResultStatus;
            m_ResultData = i_ResultData;
        }
        public enum ResultStatus
        {
            Success, Failure
        }
    }
}
