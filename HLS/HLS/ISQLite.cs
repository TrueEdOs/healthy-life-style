﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HLS
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
