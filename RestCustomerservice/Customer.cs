using System.Web.UI.WebControls;

namespace RestCustomerservice
{
    public class Customer
    {
        private int _ID;
        private string _FirstName;
        private string _LastName;
        private int _Year;

        public Customer(int id, string fname, string lname, int year)
        {
            _ID = id;
            _FirstName = fname;
            _LastName = lname;
            _Year = year;
        }

        public Customer()
        {
            
        }

        public int GetiD { get => _ID; set => _ID = value; }

        public string GetFirstName { get => _FirstName; set => _FirstName = value; }

        public string GetLastName { get => _LastName; set => _LastName = value; }

        public int GetYear { get => _Year; set => _Year = value; }

        public string FullInfo
        {
            get => $"{_FirstName} {_LastName} ({_Year})";
        }


    }
}