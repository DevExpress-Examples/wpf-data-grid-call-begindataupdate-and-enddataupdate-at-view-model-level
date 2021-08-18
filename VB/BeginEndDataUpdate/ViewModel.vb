Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Security.Authentication.ExtendedProtection
Imports System.Text
Imports System.Threading
Imports System.Threading.Tasks
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Native
Imports DevExpress.Xpf.Bars.Native

Namespace BeginEndDataUpdate
	Public Class ViewModel
		Inherits ViewModelBase

		Private ReadOnly random As New Random()

		Public ReadOnly Property Source() As ObservableCollection(Of DataItem)
		Public ReadOnly Property CustomService() As ICustomService
			Get
				Return Me.GetService(Of ICustomService)()
			End Get
		End Property


		Public Sub New()
			Source = New ObservableCollection(Of DataItem)(GetDataItems())
		End Sub
		Private Shared Function GetDataItems() As IEnumerable(Of DataItem)
			Return Enumerable.Range(0, 3000).Select(Function(i) New DataItem() With {
				.Name = "Name" & i.ToString(),
				.Value = i
			})
		End Function

		<Command>
		Public Sub UpdateSource()
			CustomService.BeginUpdate()
			For Each item As DataItem In Source
				item.Value = random.Next(Source.Count)
			Next item
			CustomService.EndUpdate()
		End Sub
	End Class
End Namespace
