Public Class CheckBoxFilterUIModel

    Private Sub _selectall_InvokeAction(ByVal sender As Object, ByVal e As UIModeling.Core.InvokeActionEventArgs) Handles _selectall.InvokeAction
        For Each item In Me.OPTIONLIST.Value
            item.CHECKED.Value = True
        Next
    End Sub

    Private Sub _unselectall_InvokeAction(ByVal sender As Object, ByVal e As UIModeling.Core.InvokeActionEventArgs) Handles _unselectall.InvokeAction
        For Each item In Me.OPTIONLIST.Value
            item.CHECKED.Value = False
        Next
    End Sub

End Class