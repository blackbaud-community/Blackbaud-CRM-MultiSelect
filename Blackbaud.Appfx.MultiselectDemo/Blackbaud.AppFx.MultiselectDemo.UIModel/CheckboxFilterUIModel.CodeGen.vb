Option Strict On
Option Explicit On
Option Infer On

'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by BBUIModelLibrary
'     Version:  1.0.0.0
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
''' <summary>
''' Represents the UI model for the 'CheckBox Filter' data form
''' </summary>
Partial Public Class [CheckBoxFilterUIModel]
    Inherits Global.Blackbaud.AppFx.UIModeling.Core.CustomUIModel

#Region "Extensibility methods"

    Partial Private Sub OnCreated()
    End Sub

#End Region

    Private WithEvents _optionlist As Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of CheckBoxFilterOPTIONLISTUIModel)
    Private WithEvents _selectall As Global.Blackbaud.AppFx.UIModeling.Core.GenericUIAction
    Private WithEvents _unselectall As Global.Blackbaud.AppFx.UIModeling.Core.GenericUIAction

    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")>
    Public Sub New()
        MyBase.New()

        _optionlist = New Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of CheckBoxFilterOPTIONLISTUIModel)
        _selectall = New Global.Blackbaud.AppFx.UIModeling.Core.GenericUIAction
        _unselectall = New Global.Blackbaud.AppFx.UIModeling.Core.GenericUIAction

        MyBase.UserInterfaceUrl = "browser/htmlforms/multiselectdemo/CheckBoxFilter.html"

        '
        '_optionlist
        '
        _optionlist.Name = "OPTIONLIST"
        Me.Fields.Add(_optionlist)
        '
        '_selectall
        '
        _selectall.Name = "SELECTALL"
        _selectall.Caption = "Select all"
        Me.Actions.Add(_selectall)
        '
        '_unselectall
        '
        _unselectall.Name = "UNSELECTALL"
        _unselectall.Caption = "Unselect all"
        Me.Actions.Add(_unselectall)

        OnCreated()

    End Sub

    ''' <summary>
    ''' Options
    ''' </summary>
    <System.ComponentModel.Description("Options")>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")>
    Public ReadOnly Property [OPTIONLIST]() As Global.Blackbaud.AppFx.UIModeling.Core.CollectionField(Of CheckBoxFilterOPTIONLISTUIModel)
        Get
            Return _optionlist
        End Get
    End Property

    ''' <summary>
    ''' Select all
    ''' </summary>
    <System.ComponentModel.Description("Select all")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
    Public ReadOnly Property [SELECTALL]() As Global.Blackbaud.AppFx.UIModeling.Core.GenericUIAction
        Get
            Return _selectall
        End Get
    End Property
    
    ''' <summary>
    ''' Unselect all
    ''' </summary>
    <System.ComponentModel.Description("Unselect all")> _
    <System.CodeDom.Compiler.GeneratedCodeAttribute("BBUIModelLibrary", "1.0.0.0")> _
    Public ReadOnly Property [UNSELECTALL]() As Global.Blackbaud.AppFx.UIModeling.Core.GenericUIAction
        Get
            Return _unselectall
        End Get
    End Property
    
End Class
