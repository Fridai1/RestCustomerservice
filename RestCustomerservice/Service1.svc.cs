using System;
using System.Collections.Generic;
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
        private static List<Customer> cList = new List<Customer>()
        {
            new Customer(1, "asd", "asd", 123),
            new Customer(2, "ass", "aaa", 1999)
        };


        

        public IList<Customer> GetCustomers()
        {
            return cList;
        }

        public string GetCustomer(int id)
        {
           Customer s = cList.Find(x => x.GetiD == id);
           return s.GetFirstName;
        }

        public void DeleteCustomer(int id)
        {
            Customer s = cList.Find(x => x.GetiD == id);
            cList.Remove(s);
        }

        public void UpdateCustomer(Customer editC, int id)
        {
            Customer foundC = cList.Find(x => x.GetiD == id);
            cList.Remove(foundC);
            cList.Add(editC);
        }

        public void InsertCustomer(Customer insertC, int id)
        {
            cList.Add(new Customer(id,insertC.GetFirstName, insertC.GetLastName, insertC.GetYear));
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
