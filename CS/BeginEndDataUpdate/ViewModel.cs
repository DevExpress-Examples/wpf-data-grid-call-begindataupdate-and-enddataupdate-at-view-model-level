using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Native;
using DevExpress.Xpf.Bars.Native;

namespace BeginEndDataUpdate {
    public class ViewModel : ViewModelBase {
        readonly Random random = new Random();

        public ObservableCollection<DataItem> Source { get; }
        public ICustomService CustomService { get { return this.GetService<ICustomService>(); } }
       

        public ViewModel() {
            Source = new ObservableCollection<DataItem>(GetDataItems());
        }
        static IEnumerable<DataItem> GetDataItems() {
            return Enumerable.Range(0, 3000).Select(i => new DataItem() { Name = "Name" + i.ToString(), Value = i });
        }

        [Command]
        public void UpdateSource() {
            CustomService.BeginUpdate();
            foreach(DataItem item in Source) {
                item.Value = random.Next(Source.Count);
            }
            CustomService.EndUpdate();
        }
    }
}
