Imports System.Data.SqlClient

Public Class Accounts

    Function connect()

        ' Connect To SQL Server DataBase
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Da As SqlDataAdapter
        Dim Dt As New DataTable
        Da = New SqlDataAdapter("select * From Financial.Data_Accounts", con)
        Da.Fill(Dt)
        DGV.DataSource = Dt
    End Function

    Private Sub Accounts_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DGV.Refresh()
        Button2.Enabled = False
        connect()
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs)
        Me.DGV.Refresh()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        makhzon()

    End Sub

    Function MyID()
        Dim con As New SqlConnection("Server=.\SQLEXPRESS; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim ac As New SqlCommand ' to show accounts table
        'ac = New SqlCommand("Select AccountID_PK From Financial.Data_Accounts where AccountNumber = 11040001", con)
        'ac.Connection.Open()
        'Dim r As SqlDataReader = ac.ExecuteReader()
        'r.Read()
        'Label2.Text = r("AccountID_PK")
        'r.Close()
        'ac.Connection.Close()

        'con.Open()
        Dim cmd As SqlCommand
        cmd = New SqlCommand("Update Inventory.RefInventoryDepartments Set InventoryAccountID_FK = 2, RevnueAccountID_FK = 0, RevnueRefundAccountID_FK = 0", con)
        'cmd.Parameters.Add("@makhzon", SqlDbType.Int).Value = Label2.Text.ToString()
        'cmd.Parameters.Add("@Revnue", SqlDbType.Int).Value = TextBox1.Text
        'cmd.Parameters.Add("@RevnueRefund", SqlDbType.Int).Value = TextBox1.Text
        'con.Close()
    End Function

    Function makhzon()
        Dim con11 As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        con11.Open()
        Dim cmd11 As New SqlCommand("UPDATE Inventory.RefInventoryDepartments SET InventoryAccountID_FK = @11, RevnueAccountID_FK = 2, RevnueRefundAccountID_FK = 2", con11)
        cmd11.Parameters.Add("@11", SqlDbType.Int).Value = Label2.Text
        con11.Close()
        MessageBox.Show("Data Updated")
    End Function

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Panel1.Enabled = False
            CheckBox2.Checked = True
            CheckBox3.Checked = True
            CheckBox4.Checked = True
            CheckBox5.Checked = True
            CheckBox6.Checked = True
            CheckBox7.Checked = True
            CheckBox8.Checked = True
            CheckBox9.Checked = True
            CheckBox10.Checked = True
            Button2.Enabled = True
            Button3.Enabled = False
        ElseIf CheckBox1.Checked = False Then
            Panel1.Enabled = True
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox4.Checked = False
            CheckBox5.Checked = False
            CheckBox6.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox10.Checked = False
            Button2.Enabled = False
            Button3.Enabled = True
        End If
    End Sub


    ' دوال الخزينة
    Function PaymentAccount()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox2.Text)
        con.Open()
        Dim reader = cmd.ExecuteReader()
        If (reader.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim Accname = CheckBox2.Text
            Dim Accnum = 11010001
            Dim sqlcmdName As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (1,'" & Accnum & "','" & Accname & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdName.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل الخزينة وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل الخزينة وإضافة جميع الخيارات")
            End If
            DGV.Refresh()
        End If  ' الخزينة الرئيسية
    End Function ' الخزينة الرئيسية
    Function MoneyHead()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox3.Text)
        con.Open()
        Dim reader3 = cmd.ExecuteReader()
        If (reader3.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim Accname3 = CheckBox3.Text
            Dim Accnum3 = 31010001
            Dim sqlcmdName3 As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (11,'" & Accnum3 & "','" & Accname3 & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdName3.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل الخزينة وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل الخزينة وإضافة جميع الخيارات")
            End If
            DGV.Refresh()
        End If  ' رأس المال
    End Function ' رأس المال
    Function Inventory()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox4.Text)
        con.Open()
        Dim reader4 = cmd.ExecuteReader()
        If (reader4.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim Accname4 = CheckBox4.Text
            Dim Accnum4 = 11040001
            Dim sqlcmdName4 As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (4,'" & Accnum4 & "','" & Accname4 & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdName4.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل الخزينة وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل الخزينة وإضافة جميع الخيارات")
            End If
            DGV.Refresh()
        End If  ' المخزون
    End Function ' المخزون
    Function JareChareck1()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox8.Text)
        con.Open()
        Dim reader8 = cmd.ExecuteReader()
        If (reader8.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim Accname8 = CheckBox8.Text
            Dim Accnum8 = 31020001
            Dim sqlcmdName8 As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (20,'" & Accnum8 & "','" & Accname8 & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdName8.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل الخزينة وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل الخزينة وإضافة جميع الخيارات")
            End If
            DGV.Refresh()
        End If  ' جاري الشريك 1
    End Function ' جاري الشريك1
    Function RevenueAccount()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox5.Text)
        con.Open()
        Dim reader5 = cmd.ExecuteReader()
        If (reader5.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim Accname5 = CheckBox5.Text
            Dim Accnum5 = 41010001
            Dim sqlcmdName5 As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (12,'" & Accnum5 & "','" & Accname5 & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdName5.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل الخزينة وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل الخزينة وإضافة جميع الخيارات")
            End If
            DGV.Refresh()
        End If  ' إيرادات النشاط
    End Function ' إيرادات النشاط
    Function RevenueRefund()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox10.Text)
        con.Open()
        Dim reader10 = cmd.ExecuteReader()
        If (reader10.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim Accname10 = CheckBox10.Text
            Dim Accnum10 = 41010001
            Dim sqlcmdName10 As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (18,'" & Accnum10 & "','" & Accname10 & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdName10.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل الخزينة وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل الخزينة وإضافة جميع الخيارات")
            End If
            DGV.Refresh()
        End If  ' مردودات المبيعات
    End Function ' مردودات المبيعات
    Function sold()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox6.Text)
        con.Open()
        Dim reader6 = cmd.ExecuteReader()
        If (reader6.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim Accname6 = CheckBox6.Text
            Dim Accnum6 = 41010002
            Dim sqlcmdName6 As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (18,'" & Accnum6 & "','" & Accname6 & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdName6.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل الخزينة وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل الخزينة وإضافة جميع الخيارات")
            End If
            DGV.Refresh()
        End If  ' التخفيض المسموح به
    End Function ' التخفيض المسموح به
    Function QTYitemssales()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox9.Text)
        con.Open()
        Dim reader9 = cmd.ExecuteReader()
        If (reader9.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim Accname9 = CheckBox9.Text
            Dim Accnum9 = 42010001
            Dim sqlcmdName9 As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (13,'" & Accnum9 & "','" & Accname9 & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdName9.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل الخزينة وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل الخزينة وإضافة جميع الخيارات")
            End If
            DGV.Refresh()
        End If  ' تكلفة الأصناف المباعة
    End Function ' تكلفة الأصناف المباعة
    Function Account3ajezFaed()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox7.Text)
        con.Open()
        Dim reader7 = cmd.ExecuteReader()
        If (reader7.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim Accname7 = CheckBox7.Text
            Dim Accnum7 = 51040001
            Dim sqlcmdName7 As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (19,'" & Accnum7 & "','" & Accname7 & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdName7.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل الخزينة وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل الخزينة وإضافة جميع الخيارات")
            End If
            DGV.Refresh()
        End If  ' تكلفة الأصناف المباعة
    End Function ' حساب العجز والفائض بالخزينة
    ' إنتهاء دوال الخزينة

    ' دوال طرق الدفع
    Function CreditCard()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox15.Text)
        con.Open()
        Dim readerCC = cmd.ExecuteReader()
        If (readerCC.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim AccnameCC = CheckBox15.Text
            Dim AccnumCC = 11020001
            Dim sqlcmdNameCC As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (18,'" & AccnumCC & "','" & AccnameCC & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdNameCC.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل طرق الدفع وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل طرق الدفع وإضافة جميع أو بعض الخيارات")
            End If
        End If
        DGV.Refresh()
    End Function ' البطاقة المصرفية

    Function Bankcheck()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox14.Text)
        con.Open()
        Dim readerBC = cmd.ExecuteReader()
        If (readerBC.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim AccnameBC = CheckBox14.Text
            Dim AccnumBC = 11020002
            Dim sqlcmdNameBC As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (18,'" & AccnumBC & "','" & AccnameBC & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdNameBC.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل طرق الدفع وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل طرق الدفع وإضافة جميع أو بعض الخيارات")
            End If
        End If
        DGV.Refresh()
    End Function ' الصك المصرفي

    Function Sadad()
        Dim con As New SqlConnection("Server=.\SQLEXPRESS; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox13.Text)
        con.Open()
        Dim readerSS = cmd.ExecuteReader()
        If (readerSS.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim AccnameSS = CheckBox13.Text
            Dim AccnumSS = 11020003
            Dim sqlcmdNameSS As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (18,'" & AccnumSS & "','" & AccnameSS & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdNameSS.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل طرق الدفع وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل طرق الدفع وإضافة جميع أو بعض الخيارات")
            End If
        End If
        DGV.Refresh()
    End Function ' سداد

    Function Tadawual()
        Dim con As New SqlConnection("Server=; Database=InfinityRetailDB; Integrated Security=true; MultipleActiveResultSets=True;")
        Dim Mangnem = "مسؤول نظام"
        Dim cmd = New SqlCommand("Select * From Financial.Data_Accounts WHERE AccountName = @Accname", con)
        cmd.Parameters.AddWithValue("@Accname", CheckBox12.Text)
        con.Open()
        Dim readerTadawul = cmd.ExecuteReader()
        If (readerTadawul.HasRows) Then
            MessageBox.Show("هذا الحساب موجود مسبقاً")
            DGV.Refresh()
        Else
            Dim AccnameTadawul = CheckBox12.Text
            Dim AccnumTadawul = 11020004
            Dim sqlcmdNameTadawul As New SqlCommand("INSERT INTO Financial.Data_Accounts (AccountSubGroupID_FK, AccountNumber, AccountName, AccountDescription, AccountTotalDebit, AccountTotalCredit, IsReadOnlyAccount, IsActiveAccount, CreatedByUserID, CreatedByUserName, CreatedDate) values (18,'" & AccnumTadawul & "','" & AccnameTadawul & "','" & Nothing & "',0.000,0.000,0,1,2,'" & Mangnem & "','" & Today & "')", con)
            If sqlcmdNameTadawul.ExecuteNonQuery() = 1 Then
                MessageBox.Show("لقد تم تفعيل طرق الدفع وإضافة جميع الخيارات")
            Else
                MessageBox.Show("لم يتم تفعيل طرق الدفع وإضافة جميع أو بعض الخيارات")
            End If
        End If
        DGV.Refresh()
    End Function ' تداول
    ' انتهاء دوال طرق الدفع

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        PaymentAccount()
        Inventory()
        MoneyHead()
        JareChareck1()
        RevenueAccount()
        RevenueRefund()
        sold()
        QTYitemssales()
        Account3ajezFaed()
        DGV.DataBindings.Clear()
        connect()
        DGV.Refresh()
        Dim cmd = New SqlCommand("UPDATE Inventory.RefInventoryDepartments SET InventoryAccountID_FK = @khazena, RevnueAccountID_FK = @Revnue, RevnueRefundAccountID_FK = @RevnueRefund", connect)
        cmd.Parameters.Add("@khazena", SqlDbType.NVarChar).Value = MyID.ToString()
        'cmd.Parameters.Add("@Revnue", SqlDbType.NVarChar).Value = WsName.Text
        'cmd.Parameters.Add("@RevnueRefund", SqlDbType.NVarChar).Value = baddress.Text
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        If CheckBox2.Checked Then ' الخزينة الرئيسية
            PaymentAccount()
        End If
        If CheckBox3.Checked Then ' رأس المال
            MoneyHead()
        End If
        If CheckBox4.Checked Then ' المخزون
            Inventory()
        End If
        If CheckBox5.Checked Then ' إيرادات النشاط
            RevenueAccount()
        End If
        If CheckBox6.Checked Then ' التخفيض المسموح به
            sold()
        End If
        If CheckBox7.Checked Then ' حساب العجز والفائض بالخزينة
            Account3ajezFaed()
        End If
        If CheckBox8.Checked Then '  جاري الشريك
            JareChareck1()
        End If
        If CheckBox9.Checked Then ' تكلفة الأصناف المباعة
            QTYitemssales()
        End If
        If CheckBox10.Checked Then ' مردودات المبيعات
            RevenueRefund()
        End If
        DGV.DataBindings.Clear()
        connect()
        DGV.Refresh()
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked = True Then
            Panel2.Enabled = False
            CheckBox15.Checked = True
            CheckBox14.Checked = True
            CheckBox13.Checked = True
            CheckBox12.Checked = True
            Button5.Enabled = True
            Button4.Enabled = False
        ElseIf CheckBox11.Checked = False Then
            Panel2.Enabled = True
            CheckBox15.Checked = False
            CheckBox14.Checked = False
            CheckBox13.Checked = False
            CheckBox12.Checked = False
            Button5.Enabled = False
            Button4.Enabled = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        CreditCard()
        Bankcheck()
        Sadad()
        Tadawual()
        DGV.DataBindings.Clear()
        connect()
        DGV.Refresh()



    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If CheckBox15.Checked Then ' البطاقة المصرفية
            CreditCard()
        End If
        If CheckBox14.Checked Then ' الصك المصرفي
            Bankcheck()
        End If
        If CheckBox13.Checked Then ' سداد
            Sadad()
        End If
        If CheckBox12.Checked Then ' تداول
            Tadawual()
        End If
        DGV.DataBindings.Clear()
        connect()
        DGV.Refresh()
    End Sub

    Private Sub DGV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV.CellContentClick
        DGV.DataBindings.Clear()
        ' connect()
        DGV.Refresh()
    End Sub
End Class