Imports System.Data.SqlClient
Imports System.Net.NetworkInformation
Imports System.Data.Sql
Public Class LoginForm

    ' LoginForm Call Numbers() Funiction When Startup
    Public Sub login_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        numbers()
        DGV.Hide()
    End Sub


    ' ============================= Password Was Starting Here ===================================
    ' Random Numbers Funiction n1 = Label 1....etc
    Function numbers()
        Dim n1 As New Integer
        Randomize()
        n1 = Int((6 * Rnd()) + 1)
        Label1.Text = n1

        Dim n2 As New Integer
        Randomize()
        n2 = Int((6 * Rnd()) + 1)
        Label2.Text = n2

        Dim n3 As New Integer
        Randomize()
        n3 = Int((6 * Rnd()) + 1)
        Label3.Text = n3

        Dim n4 As New Integer
        Randomize()
        n4 = Int((6 * Rnd()) + 1)
        Label4.Text = n4

        Dim n5 As New Integer
        Randomize()
        n5 = Int((6 * Rnd()) + 1)
        Label5.Text = n5

        Dim n6 As New Integer
        Randomize()
        n6 = Int((6 * Rnd()) + 1)
        Label6.Text = n6

        Dim n7 As New Integer
        Randomize()
        n7 = Int((6 * Rnd()) + 1)
        Label7.Text = n7

        Dim n8 As New Integer
        Randomize()
        n8 = Int((6 * Rnd()) + 1)
        Label8.Text = n8

        Dim n9 As New Integer
        Randomize()
        n9 = Int((6 * Rnd()) + 1)
        Label9.Text = n9

        Dim n10 As New Integer
        Randomize()
        n10 = Int((6 * Rnd()) + 1)
        Label10.Text = n10

        Dim n11 As New Integer
        Randomize()
        n11 = Int((6 * Rnd()) + 1)
        Label11.Text = n11

        Dim n12 As New Integer
        Randomize()
        n12 = Int((6 * Rnd()) + 1)
        Label12.Text = n12
    End Function

    ' Login Button Checking Password if Password True Will Enable Other Application Items
    Public Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim n1 As New Integer
        Dim n2 As New Integer
        Dim n3 As New Integer
        Dim sum As New Integer
        n1 = (CDbl(Label2.Text) + CDbl(Label3.Text)).ToString
        n2 = (CDbl(Label5.Text) + CDbl(Label8.Text))
        n3 = CDbl(Label10.Text).ToString * 3
        sum = n1 & +n2 & +n3
        If TextBox1.Text = sum Then
            Me.Panel1.Enabled = True
            Me.Panel2.Hide()
            Me.DGV.Show()
        Else
            MessageBox.Show("Not True")
        End If
    End Sub
    ' ============================= Password Was Finishing Here ===================================

    ' connect funiction to calling SQL Server
    Function connect()

        ' Connect To SQL Server DataBase
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        'Dim DA As New SqlCommand
        'DA.Parameters.Add(System.Windows.Forms.SystemInformation.ComputerName + "@server", SqlDbType.NVarChar).Value = infinityType.Text
        Dim Da As SqlDataAdapter
        Dim Dt As New DataTable
        Da = New SqlDataAdapter("select WsPhysicalAddress,WsName,BranchName,BranchAddressLine1 from SysConfig.Config_Workstations, MyCompany.Config_Branchs", con)
        Da.Fill(Dt)
        DGV.DataSource = Dt
    End Function

    ' call connect Funiction in Form
    Private Sub Application_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim DA As New SqlCommand
        Dim PCname = System.Windows.Forms.SystemInformation.ComputerName
        connect()
    End Sub

    ' DataGridView Refresh code
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs)
        Me.DGV.Refresh()
    End Sub

    ' Update Button for Update Values
    Private Sub updatebtn_Click(sender As System.Object, e As System.EventArgs) Handles updatebtn.Click
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim DA As New SqlCommand ' Device Activation MAC and POS Type
        Dim CI As New SqlCommand ' Company Information Name & Location
        DA = New SqlCommand("UPDATE SysConfig.Config_Workstations SET WsPhysicalAddress = @macaddress, WsName = @WsName WHERE (WsName = @WsName)", con)
        CI = New SqlCommand("UPDATE MyCompany.Config_Branchs SET BranchName = @bname, BranchAddressLine1 = @location", con)

        DA.Parameters.Add("@macaddress", SqlDbType.NVarChar).Value = text_mac.Text
        DA.Parameters.Add("@WsName", SqlDbType.NVarChar).Value = WsName.Text
        CI.Parameters.Add("@location", SqlDbType.NVarChar).Value = baddress.Text
        CI.Parameters.Add("@bname", SqlDbType.NVarChar).Value = bname.Text
        con.Open()

        If CI.ExecuteNonQuery() And DA.ExecuteNonQuery() = 1 Then
            MessageBox.Show("Data Updated")
        Else
            MessageBox.Show("Data Not Updated")
        End If

        DGV.DataBindings.Clear()
        connect()

    End Sub
    ' function to get Ethernet MAC Address
    Function getMacAddress()
        Dim networkcard() As System.Net.NetworkInformation.NetworkInterface = _
        System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
        Dim netCard As String = networkcard(0).GetPhysicalAddress.ToString

        Dim X As String
        X = netCard.Substring(0, 2)
        For i As Integer = 2 To netCard.Length - 1 Step 2
            X = X & ":" & netCard.Substring(i, 2)
        Next
        Label5.Text = X
    End Function

    ' Show MAC Address in TextBox when Click Get Mac Button
    Private Sub macbtn_Click(sender As System.Object, e As System.EventArgs) Handles macbtn.Click
        getMacAddress()
        text_mac.Text = Label5.Text
    End Sub


    ' show Accounts Form When Label Is clicked on
    Private Sub Label18_Click(sender As System.Object, e As System.EventArgs) Handles Label18.Click
        Accounts.Show()
    End Sub
End Class
