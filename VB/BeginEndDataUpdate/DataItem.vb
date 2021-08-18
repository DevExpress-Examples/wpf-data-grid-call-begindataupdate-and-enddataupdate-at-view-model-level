Imports DevExpress.Mvvm
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace BeginEndDataUpdate
	Public Class DataItem
		Inherits BindableBase

		Public Property Name() As String
			Get
				Return GetValue(Of String)(NameOf(Name))
			End Get
			Set(ByVal value As String)
				SetValue(value)
			End Set
		End Property

		Public Property Value() As Integer
			Get
				Return GetValue(Of Integer)(NameOf(Value))
			End Get
			Set(ByVal value As Integer)
				SetValue(value)
			End Set
		End Property

		Public Overrides Function ToString() As String
			Return Name
		End Function
	End Class
End Namespace
