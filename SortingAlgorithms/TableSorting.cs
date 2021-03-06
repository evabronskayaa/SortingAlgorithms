using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class TableSorting
    {
        public static void Sort(Table table, Table.Column column, ColumnType type, Order order)
        {
            bool asc = order == Order.Ascending;
            int elemIndex = Array.IndexOf(table.Columns, column);
            try
            {
                if (type == ColumnType.Text)
                {
                    table.Rows.HeapSort((e1, e2) => ShellSorter.CompareStrings(e1.Elements[elemIndex], e2.Elements[elemIndex]), asc);
                }
                else if (type == ColumnType.Number)
                {
                    table.Rows.HeapSort(r => Convert.ToDecimal(r.Elements[elemIndex]), asc);
                }
                else
                {
                    table.Rows.HeapSort(r => Convert.ToDateTime(r.Elements[elemIndex]), asc);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"!!!ОШИБКА!!! >>> {ex.Message}");
            }
        }


        public enum ColumnType
        {
            Text,
            DateTime,
            Number
        }
        public enum Order
        {
            Ascending = 1,
            Descending = -1
        }
    }

    public class Table
    {
        public Row[] Rows;
        public Column[] Columns;

        public class Row
        {
            public readonly int ID;
            public string[] Elements;
            public Row(string[] elems)
            {
                Elements = elems;
            }
        }
        public class Column
        {
            public readonly string Name;
            public string[] Elements;
            public Column(string name, int size)
            {
                Name = name;
                Elements = new string[size];
            }
        }

        public string this[int indexRow, int indexCol]
        {
            get => Rows[indexRow].Elements[indexCol];
            set
            {
                Rows[indexRow].Elements[indexCol] = value;
                Columns[indexCol].Elements[indexRow] = value;
            }
        }

        public override string ToString()
        {
            string header = Columns.Select(c => c.Name).Aggregate((c1, c2) => c1 + "    " + c2);

            StringBuilder sb = new StringBuilder(header + "\n");

            foreach (var row in Rows)
            {
                sb.Append(row.Elements.Aggregate((e1, e2) => e1 + "    " + e2) + "\n");
            }

            return sb.ToString();
        }
        
        public Table(string pathToCSV)
        {
            var lines = File.ReadAllLines(pathToCSV);

            Columns = lines[0].Split(';')
                              .Select(s => new Column(s, lines.Length - 1))
                              .ToArray();

            Rows = new Row[lines.Length - 1].Select(r => new Row(new string[Columns.Length]))
                                            .ToArray();

            var elements = lines[1..].Select(s => s.Split(';')).ToArray();

            for (int row = 0; row < Rows.Length; row++)
            {
                for (int col = 0; col < Columns.Length; col++)
                {
                    Rows[row].Elements[col] = elements[row][col];
                    Columns[col].Elements[row] = elements[row][col];
                }
            }    
        }
    }
}
