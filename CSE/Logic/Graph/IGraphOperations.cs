﻿using System;
using System.Collections.Generic;

namespace Logic.Graph
{
    public interface IGraphOperations
    {
        List<Dictionary<DateTime, decimal>> GetList();
        Dictionary<DateTime, decimal> GetListDays(string item, int storeName);
        Dictionary<DateTime, decimal> GetListMonths(Dictionary<DateTime, decimal> list);
        Dictionary<DateTime, decimal> GetListYears(Dictionary<DateTime, decimal> listForDays);
        void SetItem(string item);
        void SetStoreName(int storeName);
    }
}