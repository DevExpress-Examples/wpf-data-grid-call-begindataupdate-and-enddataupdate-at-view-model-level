# How to Call the BeginDataUpdate and EndDataUpdate Methods at the View Model Level
This example demostrates how to call the [BeginDataUpdate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.BeginDataUpdate) and [EndDataUpdate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.EndDataUpdate) methods in the MVVM application. These methods allow you to accumulate changes and update data within the GridControl in one action. 

Create a custom service that allows you to call the GridControl methods. 

```cs
...
public interface ICustomService {
    void BeginUpdate();
    void EndUpdate();
}

class CustomService : ServiceBase, ICustomService {
    GridControl ActuaGridControl { get { return  AssociatedObject as GridControl; } }

    //...

    public void BeginUpdate() {
        ActuaGridControl.BeginDataUpdate();
    }

    public void EndUpdate() {
       ActuaGridControl.EndDataUpdate();
    }
}
...
```
If you inherit your View Model class from ViewModelBase, you can access to the service as follows:

```cs
public class ViewModel : ViewModelBase {
    //...
    
    public ICustomService CustomService { get { return this.GetService<ICustomService>(); } }
    
    [Command]
    public void UpdateSource() {
        CustomService.BeginUpdate();
        foreach(DataItem item in Source) {
            item.Value = random.Next(Source.Count);
        }
        CustomService.EndUpdate();
    }
}
```


Add the service to your View and assosiate this service with the GridConrol. 
```xaml
<dxg:GridControl>
    <mvvm:Interaction.Behaviors>
        <local:CustomService />
    </mvvm:Interaction.Behaviors>
</dxg:GridControl>
...
```

Refer to the following topics for more information: 
- [Lock GridControl Updates](https://docs.devexpress.com/WPF/115836/controls-and-libraries/data-grid/performance-improvement/frequent-data-updates#lock-gridcontrol-updates)
- [How to Create a Custom Service](https://docs.devexpress.com/WPF/16920/mvvm-framework/services/how-to-create-a-custom-service)
- [Services in View Models](https://docs.devexpress.com/WPF/17414/mvvm-framework/services).
