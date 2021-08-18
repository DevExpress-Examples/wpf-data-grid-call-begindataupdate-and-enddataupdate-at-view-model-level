using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeginEndDataUpdate {
    public class DataItem : BindableBase {
        public string Name {
            get { return GetValue<string>(nameof(Name)); }
            set { SetValue(value); }
        }

        public int Value {
            get { return GetValue<int>(nameof(Value)); }
            set { SetValue(value); }
        }

        public override string ToString() {
            return Name;
        }
   }
}
