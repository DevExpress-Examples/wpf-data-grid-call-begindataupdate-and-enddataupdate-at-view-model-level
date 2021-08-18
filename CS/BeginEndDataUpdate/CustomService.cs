using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeginEndDataUpdate {
    
    public interface ICustomService {
        void BeginUpdate();
        void EndUpdate();
    }

    class CustomService : ServiceBase, ICustomService {
        GridControl ActuaGridControl { get { return  AssociatedObject as GridControl; } }

        protected override void OnAttached() {
            if(ActuaGridControl == null)
                throw new InvalidOperationException("This service can be attached only to the GridControl.");
            base.OnAttached();
        }

        public void BeginUpdate() {
            ActuaGridControl.BeginDataUpdate();
        }

        public void EndUpdate() {
             ActuaGridControl.EndDataUpdate();
        }
    }
}
