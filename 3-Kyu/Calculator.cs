//Create a simple calculator that given a string of operators (), +, -, *, / and numbers separated by spaces returns the value of that expression

//Example:

//Calculator().evaluate("2 / 2 + 3 * 4 - 6") # => 7
//Remember about the order of operations! Multiplications and divisions have a higher priority and should be performed left-to-right. Additions and subtractions have a lower priority and should also be performed left-to-right.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Evaluator
{
    public double Evaluate(string expression)
    {
        expression = Regex.Replace(expression, @"\s+", "");
        DataTable Evaluate = new DataTable();
        DataColumn Operation = new DataColumn();
        Operation.ColumnName = "Operation";
        Operation.Expression = expression;
        Operation.DataType = typeof(double);
        Evaluate.Columns.Add(Operation);
        DataRow row = Evaluate.NewRow();
        Evaluate.Rows.Add(row);
        double num = (double)(Evaluate.Rows[0]["Operation"]);
        return Math.Truncate(1000000 * num) / 1000000;
    }
}