using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestCustomerservice
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private string _Connstr =
            "Server=tcp:fridai.database.windows.net,1433;Initial Catalog=TestDB;Persist Security Info=False;User ID={fridai};Password={Skole123};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        private static List<Customer> cList = new List<Customer>()
        {
            new Customer(1, "asd", "asd", 123),
            new Customer(2, "ass", "aaa", 1999)
        };

        private List<Customer> Plist = new List<Customer>();


        public IList<Customer> GetCustomers()
        {
            return cList;
        }

        public string GetCustomer(int id)
        {

            // if (cList.Find(x => x.GetiD == id) != null)
            // {
            //Customer s = cList.Find(x => x.GetiD == id);
            //     return s.GetFirstName;
            // }
            // else
            // {
            //     return "not found";
            // }
            var customer = new Customer();

            using (SqlConnection connection = new SqlConnection(_Connstr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM Person WHERE ID = {id}");

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int custordinalID = reader.GetOrdinal("ID");
                    int custName = reader.GetOrdinal("Name");
                    int custLName = reader.GetOrdinal("LastName");
                    int CustYear = reader.GetOrdinal("Year");
                    while (reader.Read())
                    {
                        
                        customer.GetiD = reader.GetInt32(custordinalID);
                        customer.GetFirstName = reader.GetString(custLName);
                        customer.GetLastName = reader.GetString(custLName);
                        customer.GetYear = reader.GetInt32(CustYear);
                    }
                   
                    
                }
                connection.Close();
            }

            return customer.FullInfo;

        }

        public string DeleteCustomer(int id)
        {
            if (cList.Find(x => x.GetiD == id) != null)
            {
                Customer s = cList.Find(x => x.GetiD == id);
                cList.Remove(s);
                return $"{s.GetFirstName} er fjernet";
            }
            else
            {
                return "Kunne ikke finde bruger";
            }

        }

        public string UpdateCustomer(Customer editC, int id)
        {
            if (cList.Find(x => x.GetiD == id) != null)
            {
                Customer foundC = cList.Find(x => x.GetiD == id);
                cList.Remove(foundC);
                cList.Add(editC);
                return $"{foundC.GetFirstName} er opdateret";
            }
            else
            {
                return "kunne ikke finde bruger";
            }
           
        }

        public string InsertCustomer(Customer insertC, int id)
        {
            cList.Add(new Customer(id,insertC.GetFirstName, insertC.GetLastName, insertC.GetYear));
            return $"tilføjet bruger med id {id}";
        }


        public string GetData()
        { return "Hej my name is rest"; }


        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}
    }
}
