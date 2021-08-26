<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/397640639/20.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1022778)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# How to Call the BeginDataUpdate and EndDataUpdate Methods at the View Model Level
This example demostrates how to call the [BeginDataUpdate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.BeginDataUpdate) and [EndDataUpdate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.EndDataUpdate) methods in a MVVM application. These methods allow you to accumulate changes and update data within the GridControl in one action. 

Follow these steps to use the methods in your application:

1\. Create a custom service that allows you to call the GridControl methods. 

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

2\. Add the service to your View and assosiate this service with the GridControl. 
```xaml
<dxg:GridControl>
    <mvvm:Interaction.Behaviors>
        <local:CustomService />
    </mvvm:Interaction.Behaviors>
</dxg:GridControl>
...
```

3\. Access to the service at the View Model level. If you inherit your View Model class from ViewModelBase, you can access to the service as follows:

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

If you use Generated View Models or Custom View Models, refer to the following topics: 
- [Services in Generated View Models](https://docs.devexpress.com/WPF/17447/mvvm-framework/services/services-in-generated-view-models)
- [Services in Custom View Models](https://docs.devexpress.com/WPF/17450/mvvm-framework/services/services-in-custom-viewmodels)

## See Also 
- [Lock GridControl Updates](https://docs.devexpress.com/WPF/115836/controls-and-libraries/data-grid/performance-improvement/frequent-data-updates#lock-gridcontrol-updates)
- [How to Create a Custom Service](https://docs.devexpress.com/WPF/16920/mvvm-framework/services/how-to-create-a-custom-service)
- [Services in View Models](https://docs.devexpress.com/WPF/17414/mvvm-framework/services).
