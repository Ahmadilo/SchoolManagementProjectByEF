using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BusinessLogic
{
    public abstract class clsBase<T>
    {
        protected string _ErrorStart = "Proccess Error: ";
        protected int _id = -1;
        protected List<string> _ErrorMessages = new List<string>();
        public int ID { get { return _id; } }
        protected bool IsNew { get; set; }
        public IReadOnlyList<string> ErrorMessages => _ErrorMessages.AsReadOnly();

        public bool Save()
        {
            _ErrorMessages.Clear();
            if (Validate())
            {
                if (IsNew)
                {
                    IsNew = !_Add();
                    return !IsNew;
                }
                else
                {
                    return _Update();
                }
            }

            return false;
        }

        public abstract bool Validate();
        protected abstract bool _Add();
        protected abstract bool _Update();
        protected abstract T GetByID(int id);
        protected abstract bool DeleteByID(int id);
        protected abstract List<T> GetAll();
    }
}
