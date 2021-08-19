# How to Call the BeginDataUpdate and EndDataUpdate Methods at the View Model Level
This example demostrates how to call the [BeginDataUpdate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.BeginDataUpdate) and [EndDataUpdate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.EndDataUpdate) methods. These methods allow you to lock the [GridControl](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.GridControl). You can accumulate changes and update data in one action. 

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
Add the service to your View Model and use the service's methods in a command that updates GridControl data. 

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

Use the custom behavior to assosiate the GridConrol with your View Model. 
```xaml
<dxg:GridControl>
    <mvvm:Interaction.Behaviors>
        <local:CustomService />
    </mvvm:Interaction.Behaviors>
</dxg:GridControl>
...
```

Refer to the following topic for more information: [Frequent Data Updates](https://docs.devexpress.com/WPF/115836/controls-and-libraries/data-grid/performance-improvement/frequent-data-updates#lock-gridcontrol-updates). 
