using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace TestFrameworkGitHub
{
    public static class TableHelper
    {
        public static List<string> TableColumnWithIndexToList(this Table table, int columnIndex)
        {
            if (columnIndex > table.Rows.Select(x => x.Values).Count() || columnIndex < 0)
                throw new IndexOutOfRangeException();

            return table.Rows.Select(x => x.Values.ElementAtOrDefault(columnIndex)).ToList();
        }
    }
}
