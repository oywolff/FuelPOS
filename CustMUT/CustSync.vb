Imports System.Data.SqlClient
Public Class CustSync

    Private Sub LOC_CUSTBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles LOC_CUSTBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.LOC_CUSTBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DataSet1)

    End Sub

    Private Sub CustSync_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.StationStatus' table. You can move, or remove it, as needed.
        Me.StationStatusTableAdapter.Fill(Me.DataSet1.StationStatus)
        'TODO: This line of code loads data into the 'DataSet1.CUST_ID' table. You can move, or remove it, as needed.
        Me.CUST_IDTableAdapter.Fill(Me.DataSet1.CUST_ID)
        'TODO: This line of code loads data into the 'DataSet1.LOC_CUST' table. You can move, or remove it, as needed.
        Me.LOC_CUSTTableAdapter.Fill(Me.DataSet1.LOC_CUST)

    End Sub
    Private Function FDec(f As Decimal)
        Dim t As String
        t = f.ToString("0.00")
        t = t.Replace(",", ".")
        Return t
    End Function

    Private Function FInt(f As Integer)
        Dim t As String
        t = f.ToString("0000")
        t = t.Replace(" ", "0")
        Return t
    End Function

    Private Function DOStegn(s As String)
        s = s.Replace("æ", Chr(145))
        s = s.Replace("ø", Chr(155))
        s = s.Replace("å", Chr(134))
        s = s.Replace("Æ", Chr(146))
        s = s.Replace("Ø", Chr(157))
        'If s.Contains("Ø") Then
        'MessageBox.Show("inneholder Ø:" & s)
        'MessageBox.Show("Byttes ut med:" & Chr(157))
        'End If
        s = s.Replace("Å", Chr(143))
        Return s
    End Function

    Private Function GetCustMutNr(StationNr As [String])
        Dim CustMutNr As [String] = ""
        Dim StationStatusData As DataSet1.StationStatusRow
        StationStatusData = DataSet1.StationStatus.FindByStation_Nr(StationNr)
        CustMutNr = StationStatusData.LastCustMut
        Return CustMutNr
    End Function

    Private Sub SetCustMutNr(StationNr As [String], CustMutNr As [String])
        Dim StationStatusData As DataSet1.StationStatusRow
        StationStatusData = DataSet1.StationStatus.FindByStation_Nr(StationNr)
        StationStatusData.LastCustMut = CustMutNr
        Me.StationStatusTableAdapter.Update(Me.DataSet1.StationStatus)
    End Sub

    Private Sub LagCustMutFil()
        Dim ODBCConnection As New Odbc.OdbcConnection("DSN=FuelPOS")
        Dim reader As Odbc.OdbcDataReader
        Dim cmd As New Odbc.OdbcCommand
        Dim sb As New System.Text.StringBuilder()
        Dim s As [String] = ""
        Dim CNStr As [String] = ""
        Dim Temp As [String] = ""
        Dim CN As Integer
        Dim i As New Integer
        Dim m As New Decimal
        Dim StartUpd As Boolean = False
        Dim StartDel As Boolean = False
        Dim newCUST_IDTable As DataSet1.CUST_IDDataTable
        newCUST_IDTable = CUST_IDTableAdapter.GetDataByCN(CN)

        Dim MutFilePathName As [String] = "C:\FPtemp\"
        Dim MUTnr As New Integer
        MUTnr = CInt(GetCustMutNr("2052"))
        MutFilePathName = MutFilePathName & "CUST_MUT." & Format(MUTnr, "000")
        MessageBox.Show("CustMutNr " & MUTnr.ToString & " path: " & MutFilePathName)

        MUTnr += 1
        SetCustMutNr("2052", MUTnr)

        ' UTF-8 Using sw As StreamWriter = New StreamWriter(MutFilePathName)
        Using sw As New System.IO.StreamWriter(MutFilePathName, False, System.Text.Encoding.Default)
            cmd.CommandText = "SELECT CustNum, SNAM, NAM, ADDR1, ADDR2, ZIP, CITY, VATC, VATN, LTYP, LMLT, CRED, RCRED, ERCRED, MCRED, EMCRED, RBAL, [UPDATE], DEL, RapportNr FROM LOC_CUST"
            cmd.CommandType = CommandType.Text
            cmd.Connection = ODBCConnection

            ODBCConnection.Open()
            reader = cmd.ExecuteReader()

            If reader.HasRows Then
                sw.WriteLine("[START_FILE]")
                Do While reader.Read()

                    If reader.Item("UPDATE") = True Then
                        If Not StartUpd Then
                            sw.WriteLine("[CUSTOMER_UPDATE]")
                            StartUpd = True
                        End If

                        CNStr = reader.Item("CustNum")
                        CN = reader.Item("CustNum")
                        'Console.WriteLine("SNAM" & CNStr & "=" & reader.Item("SNAM"))
                        s = "SNAM" & CNStr & "=" & reader.Item("SNAM")
                        s = DOStegn(s)
                        sw.WriteLine(s)
                        s = "NAM" + CNStr + "=" & reader.Item("NAM")
                        s = DOStegn(s)
                        sw.WriteLine(s)
                        s = "ADDR" + CNStr + ",1=" & reader.Item("ADDR1")
                        s = DOStegn(s)
                        sw.WriteLine(s)
                        s = "ADDR" + CNStr + ",2=" & reader.Item("ADDR2")
                        s = DOStegn(s)
                        sw.WriteLine(s)
                        s = "ZIP" + CNStr + "=" & reader.Item("ZIP")
                        sw.WriteLine(s)
                        s = "CITY" + CNStr + "=" & reader.Item("CITY")
                        s = DOStegn(s)
                        sw.WriteLine(s)
                        s = "VATC" + CNStr + "=" & reader.Item("VATC")
                        sw.WriteLine(s)
                        s = "VATN" + CNStr + "=" & reader.Item("VATN")
                        sw.WriteLine(s)

                        If reader.Item("LTYP") > 0 Then
                            s = "LTYP" + CNStr + "=" & reader.Item("LTYP")
                            sw.WriteLine(s)
                            s = "LMLT" + CNStr + "=" & reader.Item("LMLT")
                            sw.WriteLine(s)
                        End If

                        If reader.Item("CRED") = True Then Temp = "YES" Else Temp = "NO"
                        s = "CRED" & CNStr & "=" & Temp
                        sw.WriteLine(s)

                        If Not IsNumeric(reader.Item("RCRED").ToString) Then
                            MessageBox.Show("Mangler RCRED i kundenr " & CNStr)
                        End If
                        s = "RCRED" & CNStr & "=" & FDec(reader.Item("RCRED"))
                        sw.WriteLine(s)
                        If Not IsNumeric(reader.Item("MCRED").ToString) Then
                            MessageBox.Show("Mangler MCRED i kundenr " & CNStr)
                        End If
                        s = "MCRED" & CNStr & "=" & FDec(reader.Item("MCRED"))

                        sw.WriteLine(s)
                        s = "RBAL" & CNStr & "=" & reader.Item("RBAL")
                        sw.WriteLine(s)

                        Me.CUST_IDTableAdapter.FillByCN(newCUST_IDTable, CN)
                        For i = 0 To newCUST_IDTable.Count() - 1
                            s = "ID" & CNStr & "," & i + 1 & "=" & newCUST_IDTable.Rows(i)("ID")
                            sw.WriteLine(s)
                            'Console.WriteLine(s)
                            s = "INFO" & CNStr & "," & i + 1 & "=" & newCUST_IDTable.Rows(i)("INFO")
                            ' Ikke norske tegn her s = DOStegn(s)
                            sw.WriteLine(s)
                            s = "TRACK" & CNStr & "," & i + 1 & "=" & newCUST_IDTable.Rows(i)("TRACK")
                            sw.WriteLine(s)

                            If Not IsNumeric(newCUST_IDTable.Rows(i)("PIN").ToString) Then
                                MessageBox.Show("Mangler PIN i kundenr " & CNStr)
                            End If


                            s = "PIN" & CNStr & "," & i + 1 & "=" & FInt(newCUST_IDTable.Rows(i)("PIN"))
                            sw.WriteLine(s)
                            'Console.WriteLine(s)
                            s = newCUST_IDTable.Rows(i)("BLCK")
                            If s = True Then Temp = "YES" Else Temp = "NO"
                            s = "BLCK" & CNStr & "," & i + 1 & "=" & Temp
                            sw.WriteLine(s)

                            s = "ACC" & CNStr & "," & i + 1 & "=" & newCUST_IDTable.Rows(i)("ACC")
                            sw.WriteLine(s)

                            s = newCUST_IDTable.Rows(i)("REPL")
                            If s = True Then Temp = "YES" Else Temp = "NO"
                            s = "REPL" & CNStr & "," & i + 1 & "=" & Temp
                            sw.WriteLine(s)

                            s = newCUST_IDTable.Rows(i)("ODO")
                            If s = True Then Temp = "YES" Else Temp = "NO"
                            s = "ODO" & CNStr & "," & i + 1 & "=" & Temp
                            sw.WriteLine(s)

                            s = newCUST_IDTable.Rows(i)("DID")
                            If s = True Then Temp = "YES" Else Temp = "NO"
                            s = "DID" & CNStr & "," & i + 1 & "=" & Temp
                            sw.WriteLine(s)

                            s = newCUST_IDTable.Rows(i)("CARR")
                            If s = True Then Temp = "YES" Else Temp = "NO"
                            s = "CARR" & CNStr & "," & i + 1 & "=" & Temp
                            sw.WriteLine(s)

                            s = "FUELS" & CNStr & "," & i + 1 & "=" & newCUST_IDTable.Rows(i)("FUELS")
                            sw.WriteLine(s)

                            s = newCUST_IDTable.Rows(i)("CW")
                            If s = True Then Temp = "YES" Else Temp = "NO"
                            s = "CW" & CNStr & "," & i + 1 & "=" & Temp
                            sw.WriteLine(s)

                            s = "SHOP" & CNStr & "," & i + 1 & "=" & Format(newCUST_IDTable.Rows(i)("SHOP"), "00")
                            sw.WriteLine(s)
                        Next
                    End If
                Loop

                'Skal noen slettes?
                reader.Close()
                reader = cmd.ExecuteReader()
                Do While reader.Read()
                    If reader.Item("DEL") = True Then
                        Console.WriteLine("DELETE")
                        If StartUpd Then
                            sw.WriteLine("[END_CUSTOMER_UPDATE]")
                            StartUpd = False
                        End If
                        If Not StartDel Then
                            sw.WriteLine("[CUSTOMER_DELETE]")
                            StartDel = True
                        End If

                        CNStr = reader.Item("CustNum")
                        CN = reader.Item("CustNum")
                        s = "SNAM" & CNStr & "=" & reader.Item("SNAM")
                        sw.WriteLine(s)
                        Me.CUST_IDTableAdapter.FillByCN(newCUST_IDTable, CN)
                        For i = 0 To newCUST_IDTable.Count() - 1
                            s = "ID" & CNStr & "," & i + 1 & "=" & newCUST_IDTable.Rows(i)("ID")
                            sw.WriteLine(s)
                        Next
                    End If
                Loop
            Else
                Console.WriteLine("No rows found.")
            End If
            reader.Close()
            ODBCConnection.Close()
            If StartUpd Then
                sw.WriteLine("[END_CUSTOMER_UPDATE]")
                StartUpd = False
            End If
            If StartDel Then
                sw.WriteLine("[END_CUSTOMER_DELETE]")
                StartDel = False
            End If
            sw.Close()
            Console.WriteLine("Hurra!")
        End Using
    End Sub

    Private Sub LagCustMutFilAzure()
        Dim sb As New System.Text.StringBuilder()
        Dim s As [String] = ""
        Dim CNStr As [String] = ""
        Dim Temp As [String] = ""
        Dim CN As Integer
        Dim i As New Integer
        Dim m As New Decimal
        Dim StartUpd As Boolean = False
        Dim StartDel As Boolean = False

        'Azure connection and Command 
        Dim Selectcmd As New SqlCommand
        Dim CUST_IDcmd As New SqlCommand
        Dim AZUREConnection As New SqlConnection("Server=tcp:fuelpos-server.database.windows.net,1433;Database=fuelpos-db;User ID=seiler_6@fuelpos-server;Password=Draugen2011;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
        Dim AZUREConnection2 As New SqlConnection("Server=tcp:fuelpos-server.database.windows.net,1433;Database=fuelpos-db;User ID=seiler_6@fuelpos-server;Password=Draugen2011;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
        Dim LocCustReader As SqlDataReader
        Dim CustIDReader As SqlDataReader

        Selectcmd.CommandType = CommandType.Text
        Selectcmd.Connection = AZUREConnection
        Selectcmd.CommandText = "SELECT * from BRUKERS"

        CUST_IDcmd.CommandType = CommandType.Text
        CUST_IDcmd.Connection = AZUREConnection2
        CUST_IDcmd.CommandText = "SELECT * from CUST_ID where BrukerID=@BrukerID"

        AZUREConnection.Open()
        AZUREConnection2.Open()
        CUST_IDcmd.Parameters.Add(New SqlParameter("BrukerID", SqlDbType.Int))

        Dim MutFilePathName As [String] = "C:\FPtemp\"
        Dim MUTnr As New Integer
        MUTnr = CInt(GetCustMutNr("2052"))
        MutFilePathName = MutFilePathName & "CUST_MUT." & Format(MUTnr, "000")
        '        MessageBox.Show("CustMutNr " & MUTnr.ToString & " path: " & MutFilePathName)
        MUTnr += 1
        SetCustMutNr("2052", MUTnr)
        '
        'Reading from Azure
        '
        'insertcmd.Parameters("Seq").Value = TransReader.Item("Seq").ToString()
        LocCustReader = Selectcmd.ExecuteReader
        ' UTF-8 Using sw As StreamWriter = New StreamWriter(MutFilePathName)
        Using sw As New System.IO.StreamWriter(MutFilePathName, False, System.Text.Encoding.Default)
            sw.WriteLine("[START_FILE]")
            sw.WriteLine("[CUSTOMER_UPDATE]")
            Do While LocCustReader.Read()
                'MessageBox.Show(LocCustReader.Item("Brukernummer") & " : " & LocCustReader.Item("Navn") & " ID=" & LocCustReader.Item("ID"))
                'Write this Customerdata to the file
                CNStr = LocCustReader.Item("Brukernummer")
                CN = LocCustReader.Item("Brukernummer")

                'Tags to MUT-file
                sw.WriteLine("SNAM" & CNStr & "=" & LocCustReader.Item("Navn"))
                sw.WriteLine("NAM" + CNStr + "=" & LocCustReader.Item("Navn"))
                'sw.WriteLine(DOStegn("ADDR" + CNStr + ",1=" & LocCustReader.Item("ADDR1")))
                'sw.WriteLine(DOStegn("ADDR" + CNStr + ",2=" & LocCustReader.Item("ADDR2")))
                'sw.WriteLine("ZIP" + CNStr + "=" & LocCustReader.Item("ZIP"))
                'sw.WriteLine(DOStegn("CITY" + CNStr + "=" & LocCustReader.Item("CITY")))
                'sw.WriteLine("VATC" + CNStr + "=" & LocCustReader.Item("VATC"))
                'sw.WriteLine("VATN" + CNStr + "=" & LocCustReader.Item("VATN"))

                If LocCustReader.Item("Rabatt") > 0 Then
                    sw.WriteLine("LTYP" + CNStr + "=" & LocCustReader.Item("Rabatt"))
                    sw.WriteLine("LMLT" + CNStr + "=" & LocCustReader.Item("Multiplikator"))
                End If

                'If LocCustReader.Item("CRED") = True Then Temp = "YES" Else Temp = "NO"
                ' sw.WriteLine("CRED" & CNStr & "=" & Temp)

                'If Not IsNumeric(LocCustReader.Item("RCRED").ToString) Then
                'MessageBox.Show("Mangler RCRED i kundenr " & CNStr)
                ' End If
                'sw.WriteLine(s = "RCRED" & CNStr & "=" & FDec(LocCustReader.Item("RCRED")))
                'If Not IsNumeric(LocCustReader.Item("MCRED").ToString) Then
                'MessageBox.Show("Mangler MCRED i kundenr " & CNStr)
                'End If
                'sw.WriteLine(s = "MCRED" & CNStr & "=" & FDec(LocCustReader.Item("MCRED")))
                'sw.WriteLine("RBAL" & CNStr & "=" & LocCustReader.Item("RBAL"))



                CUST_IDcmd.Parameters("BrukerID").Value = LocCustReader.Item("ID").ToString()
                CustIDReader = CUST_IDcmd.ExecuteReader
                'write this Customers cards to the file
                i = 0
                Do While CustIDReader.Read()
                    'MessageBox.Show("Kort: " & CustIDReader.Item("info"))
                    sw.WriteLine("ID" & CNStr & "," & i + 1 & "=" & CustIDReader.Item("CardID"))
                    sw.WriteLine("INFO" & CNStr & "," & i + 1 & "=" & CustIDReader.Item("INFO"))
                    'Beregnes av ID sw.WriteLine("TRACK" & CNStr & "," & i + 1 & "=" & CustIDReader.Item("Track"))
                    s = GetTrack(CustIDReader.Item("CardID"), CustIDReader.Item("ExpDate"))
                    sw.WriteLine("TRACK" & CNStr & "," & i + 1 & "=" & s)
                    sw.WriteLine("PIN" & CNStr & "," & i + 1 & "=" & CustIDReader.Item("PIN"))
                    If CustIDReader.Item("Blocked") = True Then sw.WriteLine("BLCK" & CNStr & "," & i + 1 & "=YES") Else sw.WriteLine("BLCK" & CNStr & "," & i + 1 & "=NO")
                    i += 1
                Loop
                CustIDReader.Close()
            Loop
            LocCustReader.Close()
            AZUREConnection2.Close()
            AZUREConnection.Close()
            sw.WriteLine("[END_CUSTOMER_UPDATE]")
            sw.WriteLine("[END_FILE]")
        End Using
    End Sub

    Private Function GetArtMutNr(StationNr As [String])
        Dim ArtMutNr As [String] = ""
        Dim StationStatusData As DataSet1.StationStatusRow
        StationStatusData = DataSet1.StationStatus.FindByStation_Nr(StationNr)
        ArtMutNr = StationStatusData.LastArtMut
        Return ArtMutNr
    End Function

    Private Sub SetArtMutNr(StationNr As [String], ArtMutNr As [String])
        Dim StationStatusData As DataSet1.StationStatusRow
        StationStatusData = DataSet1.StationStatus.FindByStation_Nr(StationNr)
        StationStatusData.LastArtMut = ArtMutNr
        Me.StationStatusTableAdapter.Update(Me.DataSet1.StationStatus)
    End Sub

    Private Sub LagArtMutFilAzure()
        Dim PStr As [String] = ""
        Dim StartUpd As Boolean = False
        Dim StartDel As Boolean = False

        'Azure connection and Command 
        Dim Selectcmd As New SqlCommand
        Dim AZUREConnection As New SqlConnection("Server=tcp:fuelpos-server.database.windows.net,1433;Database=fuelpos-db;User ID=seiler_6@fuelpos-server;Password=Draugen2011;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
        Dim ArtReader As SqlDataReader

        Selectcmd.CommandType = CommandType.Text
        Selectcmd.Connection = AZUREConnection
        Selectcmd.CommandText = "SELECT * from Prod_pris"
        AZUREConnection.Open()
        Dim MutFilePathName As [String] = "C:\FPtemp\ArtMut\"
        Dim MUTnr As New Integer
        MUTnr = CInt(GetArtMutNr("2052"))
        MutFilePathName = MutFilePathName & "ART_MUT." & Format(MUTnr, "000")
        MUTnr += 1
        SetArtMutNr("2052", MUTnr)
        ArtReader = Selectcmd.ExecuteReader
        Using sw As New System.IO.StreamWriter(MutFilePathName, False, System.Text.Encoding.Default)
            sw.WriteLine("[START_FILE]")
            sw.WriteLine("[FUEL_UPDATE]")
            Do While ArtReader.Read()
                PStr = ArtReader.Item("Produkt_Nr")
                'Tags to MUT-file
                'Immediate price change
                sw.WriteLine("PRI_ACT_TP" & PStr & "=1")
                sw.WriteLine("PRI" + PStr + "=" & FDec(ArtReader.Item("Pris")))
            Loop
            ArtReader.Close()
            AZUREConnection.Close()
            sw.WriteLine("[END_FUEL_UPDATE]")
            sw.WriteLine("[END_FILE]")
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LagCustMutFilAzure()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LagArtMutFilAzure()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        'Beregner MOD10 av 18-sifret KortID, genererer kontroll siffer til track
        Dim i As Integer
        Dim sum As Integer
        Dim msum As Integer
        Dim s As String
        Dim multiplikator() As Integer = {2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1}
        s = CardNumber.Text
        For i = 1 To Len(s)
            'MessageBox.Show(s.Substring(Len(s) - i, 1))
            msum = CInt(s.Substring(Len(s) - i, 1) * multiplikator(i - 1))
            If msum > 9 Then
                'MessageBox.Show(msum)
                'MessageBox.Show("msum[0]=" & msum.ToString.Substring(0, 1) & " msum[1]=" & msum.ToString.Substring(1, 1))
                msum = CInt(msum.ToString.Substring(0, 1)) + CInt(msum.ToString.Substring(1, 1))
                'MessageBox.Show(msum)
            End If
            sum = sum + msum
        Next
        'MessageBox.Show("Sum= " & sum & " Luhn= " & 10 - (sum Mod 10))
        sum = 10 - (sum Mod 10)
        'Kortnummer + Luhn + "=" Exdate(YYMM) + "7770300000000?0"
        s = CardNumber.Text & sum.ToString(0) & "=" & "1903" & "7770300000000?0"
        MessageBox.Show(s)
    End Sub

    Private Function GetTrack(cardNr As String, expdate As String)
        'Beregner MOD10 av 18-sifret KortID, genererer kontroll siffer til track
        Dim i As Integer
        Dim sum As Integer
        Dim msum As Integer
        Dim s As String
        Dim multiplikator() As Integer = {2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1}
        s = cardNr
        For i = 1 To Len(s)
            msum = CInt(s.Substring(Len(s) - i, 1) * multiplikator(i - 1))
            If msum > 9 Then
                msum = CInt(msum.ToString.Substring(0, 1)) + CInt(msum.ToString.Substring(1, 1))
            End If
            sum = sum + msum
        Next
        sum = 10 - (sum Mod 10)
        s = CardNumber.Text & sum.ToString(0) & "=" & expdate & "7770300000000?0"
        Return s
    End Function

End Class
