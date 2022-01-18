Imports DevExpress.Mvvm
Imports System.ComponentModel

Namespace BeginEndDataUpdate

    Public Class DataItem
        Inherits BindableBase

        Public Property Name As String
            Get
                Return GetValue(Of String)(NameOf(DataItem.Name))
            End Get

            Set(ByVal value As String)
                SetValue(value)
            End Set
        End Property

        Public Property Value As Integer
            Get
                Return GetValue(Of Integer)(NameOf(DataItem.Value))
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
