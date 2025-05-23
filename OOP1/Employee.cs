using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    public class Employee
    {
        #region Nhóm các thuộc tính của Employee
        private int _id;
        private string _id_card;
        private string _name;
        private string _email;    // các biến này là instance variables
        private string _phone;
        #endregion
        #region Nhóm Constructor của Employee
        public Employee(int _id, string _id_card, string _name, string _email, string _phone)  //các biến được khai báo trong này là local
        {
            this._id = _id;             // this. là trỏ đến instance variable còn bên phải trỏ vào local variable
            this._id_card = _id_card;
            this._name = _name;
            this._email = _email;
            this._phone = _phone;
        }

        public Employee()
        {
            _id = 0;
            _id_card = "";
            _name = "";
            _email = "";
            _phone = "";
        }
        #endregion 
        #region Nhóm các properties của Employee
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string IdCard
        {
            get { return _id_card; }
            set { _id_card = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        #endregion
        #region Nhóm các phương thức của Employee
        public void PrintInfor()
        {
            string msg = $"Id: {Id}\t IdCard: {IdCard}\t Name: {Name}\t Email: {Email}\t Phone: {Phone}";
            Console.WriteLine(msg);
        }

        public override string ToString()
        {
            string msg = $"Id: {Id}\t IdCard: {IdCard}\t Name: {Name}\t Email: {Email}\t Phone: {Phone}";
            return msg;
        }
        #endregion
    }
}
