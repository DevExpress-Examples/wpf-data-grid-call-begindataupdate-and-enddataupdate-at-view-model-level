Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Native

Namespace BeginEndDataUpdate

    Public Class ViewModel
        Inherits ViewModelBase

        Private ReadOnly random As Random = New Random()

        Public ReadOnly Property Source As ObservableCollection(Of DataItem)

        Public ReadOnly Property CustomService As ICustomService
            Get
                Return GetService(Of ICustomService)()
            End Get
        End Property

        Public Sub New()
            Source = New ObservableCollection(Of DataItem)(GetDataItems())
        End Sub

        Private Shared Function GetDataItems() As IEnumerable(Of DataItem)
            Return Enumerable.Range(0, 3000).[Select](Function(i) New DataItem() With {.Name = "Name" & i.ToString(), .Value = i})
        End Function

        <Command>
        Public Sub UpdateSource()
            CustomService.BeginUpdate()
            For Each item As DataItem In Source
                item.Value = random.Next(Source.Count)
            Next

            CustomService.EndUpdate()
        End Sub
    End Class
End Namespace
