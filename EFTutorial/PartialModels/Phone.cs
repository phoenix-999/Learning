using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace EFTutorial
{
    public partial class Phone
    {
        public override string ToString()
        {
            StringBuilder phoneStr = new StringBuilder();
            phoneStr.Append(string.Format("Model = {0}; ", this.Model));
            phoneStr.Append(string.Format("ModelDetail = {0}; ", this.ModelDetail));
            phoneStr.Append(string.Format("Price = {0}; ", this.Price));

            return phoneStr.ToString();
        }

        public override bool Equals(object obj)
        {
            Phone phone = obj as Phone;
            if (phone == null) return false;

            return phone.GetAllFieldsInString() == this.GetAllFieldsInString();
        }

        public override int GetHashCode()
        {
            return this.GetAllFieldsInString().GetHashCode();
        }

        public virtual string GetAllFieldsInString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Type type = this.GetType();
            IEnumerable<PropertyInfo> fieldInfo = type.GetProperties();
            foreach (var info in fieldInfo)
            {
                if (info.CanRead == false) continue;

                stringBuilder.Append(info.Name);
                stringBuilder.Append("=>");
                stringBuilder.Append(info.GetValue(this));
                stringBuilder.Append("|");
            }

            return stringBuilder.ToString();
        }
    }
}
