Imports Blackbaud.AppFx.Server
Imports Blackbaud.AppFx.UIModeling

Public NotInheritable Class CheckBoxFilterHelper

    Private _model As RootUIModel
    Private _checkBoxFilterMode As ValueListField
    Private _checkBoxItems As CollectionField


    ''' <summary>
    ''' Attaches a hierarchy filter to the specified field on the form model.
    ''' </summary>
    Public Shared Sub MapField(ByVal model As RootUIModel, ByVal checkBoxFilterMode As ValueListField, ByVal checkBoxItems As CollectionField)
        Dim checkBoxFilterHelper As New CheckBoxFilterHelper(model, checkBoxFilterMode, checkBoxItems)
        checkBoxFilterHelper.Initialize()
    End Sub

    Private Sub New(ByVal model As RootUIModel, ByVal checkBoxFilterMode As ValueListField, ByVal checkBoxItems As CollectionField)
        _model = model
        _checkBoxFilterMode = checkBoxFilterMode
        _checkBoxItems = checkBoxItems
    End Sub

    Private Sub Initialize()
        Dim action As New ShowCustomFormUIAction With {
            .Name = "CHECKBOXFILTER" + Guid.NewGuid().ToString.Replace("-", "_"),
            .ImageKey = "catalog:Blackbaud.AppFx.Platform.Catalog,Blackbaud.AppFx.Platform.Catalog.hierarchy_2tier.png",
            .ModelAssemblyName = "Blackbaud.AppFx.MultiSelectDemo.UIModel.dll",
            .ModelClassName = "Blackbaud.AppFx.MultiSelectDemo.UIModel.CheckBoxFilterUIModel"
        }
        _checkBoxFilterMode.LinkedActions.Add(action)
        _model.Actions.Add(action)
        AddHandler action.InvokeAction, AddressOf ActionInvoked
        AddHandler action.CustomFormConfirmed, AddressOf CustomFormConfirmed

    End Sub

    Private Sub LoadData(ByVal model As CheckBoxFilterUIModel)
        Using conn As SqlClient.SqlConnection = _model.GetRequestContext.OpenAppDBConnection()
            Using cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand("exec dbo.USP_REVENUE_TRANSACTIONTYPECODE_GETLIST;", conn)
                Using reader As SqlClient.SqlDataReader = cmd.ExecuteReader
                    Dim selectedItems As New HashSet(Of Integer)

                    For Each item As Core.UIModel In _checkBoxItems.ValueItems
                        Dim id As Integer
                        If Integer.TryParse(item.Fields("ID").ValueObject, id) Then
                            If Not selectedItems.Contains(id) Then
                                selectedItems.Add(id)
                            End If
                        End If
                    Next

                    While reader.Read()
                        Dim row As New CheckBoxFilterOPTIONLISTUIModel
                        row.ID.Value = reader.GetInt32(0)
                        row.NAME.Value = reader.GetString(1)
                        row.CHECKED.Value = selectedItems.Contains(reader.GetInt32(0))
                        model.OPTIONLIST.Value.Add(row)
                    End While
                    model.OPTIONLIST.AllowAdd = False
                    model.OPTIONLIST.AllowColumnMove = False
                    model.OPTIONLIST.AllowDelete = False
                    model.OPTIONLIST.AllowDragDrop = False
                End Using ' reader
            End Using
        End Using
    End Sub

    Private Sub ActionInvoked(ByVal sender As Object, ByVal e As UIModeling.Core.ShowCustomFormEventArgs)
        Dim model = DirectCast(e.Model, CheckBoxFilterUIModel)
        model.FORMHEADER.Value = _checkBoxFilterMode.Caption
        LoadData(model)
    End Sub

    Private Sub CustomFormConfirmed(ByVal sender As Object, ByVal e As UIModeling.Core.CustomFormConfirmedEventArgs)
        ' Translate out the results of the hierarchy form
        Dim model = DirectCast(e.Model, CheckBoxFilterUIModel)

        _checkBoxFilterMode.ValueObject = 1 ' Selected types
        _checkBoxItems.ValueItems.Clear()

        ' Add new selected items
        For Each row In model.OPTIONLIST.Value
            If row.CHECKED.Value Then
                With DirectCast(_checkBoxItems.ValueItems.AddNew(), Core.UIModel)
                    .Fields("ID").ValueObject = row.ID.Value
                End With
            End If
        Next
    End Sub
End Class
