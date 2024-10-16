<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/397640639/22.2.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1022778)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

# WPF Data Grid - Call the BeginDataUpdate and EndDataUpdate Methods at the View Model Level

This example demostrates how to call the [BeginDataUpdate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.BeginDataUpdate) and [EndDataUpdate](https://docs.devexpress.com/WPF/DevExpress.Xpf.Grid.DataControlBase.EndDataUpdate) methods in an MVVM application. These methods allow you to accumulate changes and update data within the GridControl in one action. 

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

## Files to Review

- [CustomService.cs](./CS/BeginEndDataUpdate/CustomService.cs) (VB: [CustomService.vb](./VB/BeginEndDataUpdate/CustomService.vb))
- [ViewModel.cs](./CS/BeginEndDataUpdate/ViewModel.cs) (VB: [ViewModel.vb](./VB/BeginEndDataUpdate/ViewModel.vb))
- [MainWindow.xaml](./CS/BeginEndDataUpdate/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/BeginEndDataUpdate/MainWindow.xaml))

## Documentation

- [Lock Updates](https://docs.devexpress.com/WPF/115836/controls-and-libraries/data-grid/performance-improvement/frequent-data-updates#lock-updates)
- [How to Create a Custom Service](https://docs.devexpress.com/WPF/16920/mvvm-framework/services/how-to-create-a-custom-service)
- [Services in View Models](https://docs.devexpress.com/WPF/17414/mvvm-framework/services)

## More Examples

- [WPF Data Grid - Process Data Updates](https://github.com/DevExpress-Examples/How-to-effectively-process-data-updates-in-WPF-GridControl)
- [Data Grid for WPF - Update Data in a Separate Thread](https://github.com/DevExpress-Examples/wpf-data-grid-update-data-in-a-separate-thread)
- [Data Grid for WPF - Refresh the Data Grid on a Timer](https://github.com/DevExpress-Examples/wpf-data-grid-refresh-on-timer)
- [WPF MVVM Framework - Create a Custom Service](https://github.com/DevExpress-Examples/wpf-mvvm-framework-create-a-custom-service)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-call-begindataupdate-and-enddataupdate-at-view-model-level&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=wpf-data-grid-call-begindataupdate-and-enddataupdate-at-view-model-level&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
