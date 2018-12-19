using System;
using System.Collections.Generic;
using System.Text;

namespace HLS.Models
{
    public interface IDBPackable
    {
        void Serialize();
        void Deserialize();
        string ID { get; set; }
    }
}
