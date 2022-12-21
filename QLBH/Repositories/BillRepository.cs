using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBH.Models;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLBH.Repositories
{
    public class BillRepository: RepositoryBase, IBillRepository
    {

        public double getRevOfDay()
        {
            double rev = 0;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();

            using (var connection = GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT SUM(PRICE_BILL) AS REV FROM dbo.BILL GROUP BY DATE_BILL HAVING YEAR(DATE_BILL) = '"+year+"' AND MONTH(DATE_BILL) = '"+month+"' AND DAY(DATE_BILL) = '"+day+"'";
                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader();
                if (SqlReader.HasRows)
                {
                    while (SqlReader.Read())
                    {
                        rev = Convert.ToDouble(SqlReader["REV"]);
                    }

                }
                else
                {
                    rev = 0;

                }
            }

            return rev;
        }

        public double getNumOfOrders()
        {
            double num = 0;
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();

            using (var connection = GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT COUNT(ID_BILL) AS NUM FROM dbo.BILL GROUP BY DATE_BILL HAVING YEAR(DATE_BILL) = '" + year + "' AND MONTH(DATE_BILL) = '" + month + "' AND DAY(DATE_BILL) = '" + day + "'";
                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader();
                if (SqlReader.HasRows)
                {
                    while (SqlReader.Read())
                    {
                        num = Convert.ToDouble(SqlReader["NUM"]);
                    }

                }
                else
                {
                    num = 0;

                }
            }

            return num;
        }

        public double[] getDataOfYesterday()
        {
            double[] data = new double[24];
            DateTime t = DateTime.Today.AddDays(-1);
            int year = t.Year;
            int month = t.Month;
            int day = t.Day;
            
            

            using (var connection = GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT  DATEPART(HOUR, [TIME]) AS T, SUM(PRICE_BILL) AS P FROM dbo.BILL WHERE YEAR(DATE_BILL) = '"+year+"' AND MONTH(DATE_BILL) = '"+month+ "' AND DAY(DATE_BILL) = '"+day+"' GROUP BY DATEPART(HOUR, [TIME])";
                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader();
                if (SqlReader.HasRows)
                {
                    while (SqlReader.Read())
                    {
                        data[Convert.ToInt32(SqlReader["T"])] = Convert.ToDouble(SqlReader["P"]);

                    }

                }

            }

            return data;
        }

        public double[] getDataOfThisMonth()
        {
            double[] data = new double[31];
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            

            using (var connection = GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT DAY(DATE_BILL) AS D, SUM(PRICE_BILL) AS P FROM dbo.BILL GROUP BY DATE_BILL HAVING YEAR(DATE_BILL) = '" + year + "' AND MONTH(DATE_BILL) = '" + month + "'";
                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader();
                if (SqlReader.HasRows)
                {
                    while (SqlReader.Read())
                    {
                        data[Convert.ToInt32(SqlReader["D"])-1] = Convert.ToDouble(SqlReader["P"]);

                    }

                }
                
            }

            return data;
        }

        public double[] getDataOfLastMonth()
        {
            double[] data = new double[31];
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            if(month == 1)
            {
                month = 12;
                year--;
            }
            else
            {
                month--;
            }

            //MessageBox.Show(month.ToString());
            

            using (var connection = GetConnection())
            using (SqlDataAdapter adapter = new SqlDataAdapter())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT DAY(DATE_BILL) AS D, SUM(PRICE_BILL) AS P FROM dbo.BILL GROUP BY DATE_BILL HAVING YEAR(DATE_BILL) = '" + year + "' AND MONTH(DATE_BILL) = '" + month + "'";
                adapter.SelectCommand = command;
                using var SqlReader = command.ExecuteReader();
                if (SqlReader.HasRows)
                {
                    while (SqlReader.Read())
                    {
                        data[Convert.ToInt32(SqlReader["D"]) - 1] = Convert.ToDouble(SqlReader["P"]);

                    }

                }

            }

            return data;
        }
    }
}
