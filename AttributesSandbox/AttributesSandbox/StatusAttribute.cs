using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AttributesSandbox
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple = true)]
    class StatusAttribute:Attribute
    {
        public enum Status
        {
            Done,
            Check,
            Build,
            Committed,
            Fixed,
            Bug
        }

        public Status _status { get; set; }

        public StatusAttribute(Status status)
        {
            _status = status;
        }

        public override string ToString()
        {
            return Convert.ToString(_status);
        }
    }
}
