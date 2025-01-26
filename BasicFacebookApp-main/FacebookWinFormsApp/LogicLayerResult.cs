using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicFacebookFeatures
{
    public class LogicLayerResult
    {
        public ResultStatus m_Status { get; }
        public object m_ResultData { get; }
        //TODO: Change the Facede to Non-Transparent
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
