Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System
Imports System.IO
Imports System.Text
Imports System.Net
Imports System.Net.FtpClient
'Downloaded from https://netftp.codeplex.com/

Imports Microsoft.VisualBasic



Public Class Form1
    '  Globals for verdioverføring
    '  FuelTrans : FuelTransRec;
    '  FuelItem : FuelItemRec;
    Dim s As String
    Dim FileName As String = ""
    Dim TranFile As System.IO.StreamReader()
    '       Using sw As New System.IO.StreamWriter(MutFilePathName, False, System.Text.Encoding.Default)
    Dim SSection, SName, SStrValue As String
    Dim STrans, KeepTrans, SIndex, KeepIndex, SIntValue, kundenr, aar As Integer
    Dim SFloatValue As Decimal
    Dim IsSection, FirstTrans, FirstIndex, RTFile, CUSTFile As Boolean
    Dim FuelTrans As DataSet1.ImpTransRow
    Dim FuelItem As DataSet1.ItemTableRow
    Dim StationStatus As DataSet1.StationStatusRow

    Private Function DOStegn(s As String)
        s = s.Replace("æ", Chr(145))
        s = s.Replace("ø", Chr(155))
        s = s.Replace("å", Chr(134))
        s = s.Replace("Æ", Chr(146))
        s = s.Replace("Ø", Chr(157))
        s = s.Replace("Å", Chr(143))
        Return s
    End Function

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DataSet1.StationStatus' table. You can move, or remove it, as needed.
        Me.StationStatusTableAdapter.Fill(Me.DataSet1.StationStatus)
        'TODO: This line of code loads data into the 'DataSet1.StationStatus' table. You can move, or remove it, as needed.
        Me.StationStatusTableAdapter.Fill(Me.DataSet1.StationStatus)
        'TODO: This line of code loads data into the 'DataSet1.StationStatus' table. You can move, or remove it, as needed.
        Me.StationStatusTableAdapter.Fill(Me.DataSet1.StationStatus)
        'TODO: This line of code loads data into the 'DataSet1.DayReportRaw' table. You can move, or remove it, as needed.
        Me.DayReportRawTableAdapter.Fill(Me.DataSet1.DayReportRaw)
        'TODO: This line of code loads data into the 'DataSet1.ImpTrans' table. You can move, or remove it, as needed.
        Me.ImpTransTableAdapter.Fill(Me.DataSet1.ImpTrans)
        'TODO: This line of code loads data into the 'DataSet1.ItemTable' table. You can move, or remove it, as needed.
        Me.ItemTableTableAdapter.Fill(Me.DataSet1.ItemTable)
        'TODO: This line of code loads data into the 'DataSet1.FuelImp1' table. You can move, or remove it, as needed.
        Me.FuelImp1TableAdapter.Fill(Me.DataSet1.FuelImp1)
        'TODO: This line of code loads data into the '_fuelpos_dbDataSet.ItemImps' table. You can move, or remove it, as needed.
        If False Then Me.ItemImpsTableAdapter.Fill(Me._fuelpos_dbDataSet.ItemImps)
        'TODO: This line of code loads data into the '_fuelpos_dbDataSet.TransImps' table. You can move, or remove it, as needed.
        If False Then Me.TransImpsTableAdapter.Fill(Me._fuelpos_dbDataSet.TransImps)
        'TODO: This line of code loads data into the 'DataSet1.FP_Items' table. You can move, or remove it, as needed.
        Me.FP_ItemsTableAdapter.Fill(Me.DataSet1.FP_Items)
        Me.StationStatusTableAdapter.Fill(Me.DataSet1.StationStatus)

    End Sub
    Private Function FDec(f As Decimal)
        Dim t As String
        t = f.ToString("0.00")
        t = t.Replace(",", ".")
        Return t
    End Function

    Function getvalueType(name As String)
        Dim res As Boolean = True
        If name = "REF" Then res = True
        If name = "SEQ" Then res = True
        If name = "DATI" Then res = True
        If name = "PMP" Then res = False
        If name = "PRI" Then res = False
        If name = "QTY" Then res = False
        If name = "TYP" Then res = False
        If name = "STATION_NR" Then res = True
        If name = "CUST" Then res = False
        If name = "CNAM" Then res = True
        If name = "INFO" Then res = True
        If name = "PM" Then res = False
        If name = "PA" Then res = False
        If name = "NAM" Then res = True
        If name = "PRC" Then res = False
        If name = "VAMT" Then res = False
        If name = "DSCT" Then res = False
        If name = "DNAM" Then res = True
        If name = "DSC" Then res = False
        If name = "LDSC" Then res = False
        If name = "GAMT" Then res = False
        If name = "AMT" Then res = False
        If name = "ID" Then res = True
        If name = "PAN" Then res = True
        If name = "MERCH_ID" Then res = True
        If name = "MERCH_NAME" Then res = True
        If name = "PNAM" Then res = True

        Return res
    End Function

    Private Function CheckConfig(Name As String)
        Dim res As Boolean = False
        If Name = "REF" Then res = True
        If Name = "SEQ" Then res = True
        If Name = "DATI" Then res = True
        If Name = "PMP" Then res = True
        If Name = "PRI" Then res = True
        If Name = "QTY" Then res = True
        If Name = "TYP" Then res = True
        If Name = "STATION_NR" Then res = True
        If Name = "CUST" Then res = True
        If Name = "CNAM" Then res = True
        If Name = "INFO" Then res = True
        If Name = "PM" Then res = True
        If Name = "PA" Then res = True
        If Name = "NAM" Then res = True
        If Name = "PRC" Then res = True
        If Name = "VAMT" Then res = True
        If Name = "DSCT" Then res = True
        If Name = "DNAM" Then res = True
        If Name = "DSC" Then res = True
        If Name = "LDSC" Then res = True
        If Name = "GAMT" Then res = True
        If Name = "AMT" Then res = True
        If Name = "PNAM" Then res = True
        Return res
    End Function

    Private Sub ZeroFuelTrans()
        FuelTrans.Ref = ""
        FuelTrans.Seq = ""
        FuelTrans.Dati = ""
        FuelTrans.Typ = 0
        FuelTrans.Station_Nr = ""
        FuelTrans.Pm = 0
        FuelTrans.Pa = 0
        FuelTrans.Cust = 0
        FuelTrans.Cnam = ""
        FuelTrans.Info = ""
    End Sub
    Private Sub ZeroFuelItem()
        FuelItem.Ref = ""
        FuelItem.Pmp = 0
        FuelItem.Pri = 0
        FuelItem.Qty = 0
        FuelItem.Nam = ""
        FuelItem.Prc = 0
        FuelItem.Vamt = 0
        FuelItem.Dsct = 0
        FuelItem.Dnam = ""
        FuelItem.Dsc = 0
        FuelItem.Ldsc = 0
        FuelItem.Gamt = 0
        FuelItem.Amt = 0
    End Sub
    Private Sub VGen()
        Dim RefNull As Boolean = False 'Len(FuelTrans.Ref) > 0
        'Console.WriteLine("VGen")
        'IKKE I BRUK? FuelImp1TableAdapter.Insert(SSection, SName, STrans, SIndex, SStrValue)

        If FirstTrans And Not IsSection Then
            KeepTrans = STrans
            FirstTrans = False
        End If

        If FirstIndex And (SIndex > 0) Then
            KeepIndex = SIndex
            FuelItem.Index = SIndex
            FirstIndex = False
        End If

        RefNull = FuelTrans.IsNull(0) Or Len(FuelTrans.Ref) = 0 Or FuelTrans.Ref = ""

        If (((STrans <> KeepTrans) And CheckConfig(SName)) Or (SSection = "END_TRX")) And (Not RefNull) Then

            ImpTransTableAdapter.Insert(FuelTrans.Ref, FuelTrans.Dati, FuelTrans.Seq, FuelTrans.Typ, FuelTrans.Station_Nr, FuelTrans.Cust, FuelTrans.Cnam, FuelTrans.Info, FuelTrans.Pm, FuelTrans.Pa)
            'Me.DataSet1.ImpTrans.Rows.Add(FuelTrans)
            Me.ImpTransTableAdapter.Update(Me.DataSet1.ImpTrans)
            Me.DataSet1.AcceptChanges()
            KeepTrans = STrans
            FirstIndex = True
            ZeroFuelTrans()
        End If

        RefNull = FuelItem.IsRefNull Or FuelItem.Ref = ""
        If ((((STrans <> KeepTrans) Or (SIndex <> KeepIndex)) And CheckConfig(SName)) Or (SSection = "END_TRX")) And (Not RefNull) Then

            ItemTableTableAdapter.Insert(FuelItem.Ref, FuelItem.Index, FuelItem.Pmp, FuelItem.Nam, FuelItem.Qty, FuelItem.Pri, FuelItem.Prc, FuelItem.Vamt, FuelItem.Dsct, FuelItem.Dnam, FuelItem.Dsc, FuelItem.Ldsc, FuelItem.Gamt, FuelItem.Amt)
            'Me.DataSet1.ItemTable.Rows.Add(FuelItem)
            Me.ItemTableTableAdapter.Update(Me.DataSet1.ItemTable)
            Me.DataSet1.AcceptChanges()
            KeepIndex = SIndex
            FuelItem.Index = SIndex
            ZeroFuelItem()
        End If

        If SName = "REF" Then FuelTrans.Ref = SStrValue
        If SName = "SEQ" Then FuelTrans.Seq = SStrValue
        If SName = "DATI" Then FuelTrans.Dati = SStrValue
        If SName = "TYP" Then FuelTrans.Typ = SIntValue
        If SName = "STATION_NR" Then FuelTrans.Station_Nr = SStrValue
        If SName = "PM" Then FuelTrans.Pm = SIntValue
        If SName = "PA" Then FuelTrans.Pa = SFloatValue
        If SName = "CUST" Then FuelTrans.Cust = SIntValue
        If SName = "CNAM" Then FuelTrans.Cnam = SStrValue
        If SName = "INFO" Then FuelTrans.Info = SStrValue


        If SName = "REF" Then FuelItem.Ref = SStrValue
        If SName = "PMP" Then FuelItem.Pmp = SIntValue
        If SName = "PRI" Then FuelItem.Pri = SFloatValue
        If SName = "QTY" Then FuelItem.Qty = SFloatValue
        If SName = "NAM" Then FuelItem.Nam = SStrValue
        If SName = "PRC" Then FuelItem.Prc = SFloatValue
        If SName = "VAMT" Then FuelItem.Vamt = SFloatValue
        If SName = "DSCT" Then FuelItem.Dsct = SIntValue
        If SName = "DNAM" Then FuelItem.Dnam = SStrValue
        If SName = "DSC" Then FuelItem.Dsc = SFloatValue
        If SName = "LDSC" Then FuelItem.Ldsc = SFloatValue
        If SName = "GAMT" Then FuelItem.Gamt = SFloatValue
        If SName = "AMT" Then FuelItem.Amt = SFloatValue


    End Sub


    Private Sub SGenRunningTotal()
        'MessageBox.Show(s)
        'Console.WriteLine(s)
        Dim c As Char
        Dim i As Integer
        Dim Name, Number, ValueStr, StrValue As String
        Dim Trans, Index, IntValue As Integer
        Dim FloatValue As Double
        Dim IsIndex, IsValue, IsText As Boolean
        IsText = False
        IsIndex = False
        IsValue = False
        IsSection = False
        Index = 0
        Trans = 0
        FloatValue = 0.0
        IntValue = 0
        ValueStr = ""
        StrValue = ""
        Name = ""
        Number = ""

        If s.Contains("[") And s.Contains("]") Then
            SSection = s.Substring(s.IndexOf("[") + 1, s.IndexOf("]") - s.IndexOf("[") - 1)
            Console.WriteLine("Section = " & SSection)
            IsSection = True
        Else

            For i = 1 To Len(s)

                c = s.Substring(i - 1, 1)
                '  MessageBox.Show("SGEN c= " & c & " " & Microsoft.VisualBasic.Asc(c).ToString())

                If Asc(c) = 95 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If '_

                If Asc(c) >= 32 And Asc(c) <= 43 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If  '  !..+

                If Asc(c) >= 65 And Asc(c) <= 90 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                    '  MessageBox.Show("SGEN A..Z NAME=" & Name & " ValueStr= " & ValueStr)
                End If  '  A..Z

                If Asc(c) >= 134 And Asc(c) <= 157 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If 'Æ..Å, æ..å

                If Asc(c) >= 97 And Asc(c) <= 122 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If 'a..z

                If Asc(c) >= 48 And Asc(c) <= 57 Then
                    If IsValue Then
                        ValueStr = ValueStr + c
                        '  MessageBox.Show("SGen ISValue ValueStr=" & ValueStr)
                    Else
                        Number = Number + c
                        ' MessageBox.Show("SGEN 0..9 Number=" & Number & " ValueStr= " & ValueStr)
                    End If '0..9
                End If

                If Asc(c) = 46 Then
                    If IsValue Then ValueStr = ValueStr + c Else Number = Number + c
                End If '.

                If Asc(c) = 45 Then
                    If IsValue Then ValueStr = ValueStr + c Else Number = Number + c
                End If '-

                If Asc(c) = 61 Then
                    If IsIndex Then
                        Index = CInt(Number)
                        Number = ""
                        IsIndex = False
                        IsValue = True
                    Else
                        'Console.Write("SGen = IsValue settes TRUE, NAME=")
                        'Console.WriteLine(Name)
                        'Console.Write("NUMBER=")
                        'Console.WriteLine(Number)
                        '20150103 Legger til en test på om det er en verdi uten index, som CREATED=20141002000016
                        'Section [GENERIC_FILE_INFO]
                        If Number = "" Then Number = "0"
                        Trans = CInt(Number)
                        Number = ""
                        IsValue = True
                    End If
                End If '=

                If Asc(c) = 44 Then
                    If IsValue Then
                        ValueStr = ValueStr + c
                    Else
                        Trans = CInt(Number)
                        Number = ""
                        IsIndex = True
                    End If
                End If ',
            Next
            '<CR> {Les selve verdien}
            'MessageBox.Show("IsText Name=" & Name)

            IsText = getvalueType(Name)    'Finn verditype for denne item
            'MessageBox.Show("IsText=" & IsText)
            If IsText Then
                StrValue = ValueStr
            Else
                'DecimalSeparator = "."
                If ValueStr.Contains(".") Then
                    ValueStr = ValueStr.Replace(".", ",")
                    FloatValue = CDbl(ValueStr)
                    StrValue = CDbl(FloatValue)
                Else
                    'MessageBox.Show("ValueStr=" & ValueStr & " NAME=" & Name)
                    IntValue = CInt(ValueStr)
                    StrValue = IntValue.ToString
                End If
            End If
            ' MessageBox.Show("SGen NEXT ValueStr=" & ValueStr & " StrValue=" & StrValue)
        End If
        ' {SSection settes direkte når aktuell}
        SName = Name
        STrans = Trans
        'NorskeTegn(StrValue)
        SStrValue = StrValue
        SIntValue = IntValue
        SFloatValue = FloatValue
        SIndex = Index
        If SName <> "" Then Console.WriteLine("DayRpt : SNAME=" & SName & " STrans=" & STrans & " SStrValue=" & SStrValue & " SIntValue=" & SIntValue & " SFloatValue=" & SFloatValue & " SIndex=" & SIndex & " FirstTrans=" & FirstTrans & " IsSection=" & IsSection)
        ' Insert into database VGen()
        'Preliminary Insert into general table structure
        DayReportRawTableAdapter.Insert(SSection, SName, STrans, SIndex, SStrValue)
    End Sub

    Private Sub SGenCUST()
        'MessageBox.Show(s)
        'Console.WriteLine(s)
        Dim c As Char
        Dim i As Integer
        Dim Name, Number, ValueStr, StrValue As String
        Dim Trans, Index, IntValue As Integer
        Dim FloatValue As Double
        Dim IsIndex, IsValue, IsText, FirstTRACK As Boolean
        IsText = False
        IsIndex = False
        IsValue = False
        IsSection = False
        FirstTRACK = True
        Index = 0
        Trans = 0
        FloatValue = 0.0
        IntValue = 0
        ValueStr = ""
        StrValue = ""
        Name = ""
        Number = ""

        If s.Contains("[") And s.Contains("]") Then
            SSection = s.Substring(s.IndexOf("[") + 1, s.IndexOf("]") - s.IndexOf("[") - 1)
            Console.WriteLine("Section = " & SSection)
            IsSection = True
        Else

            For i = 1 To Len(s)

                c = s.Substring(i - 1, 1)
                'Console.WriteLine("SGEN Æ=  " & Microsoft.VisualBasic.Asc("Æ").ToString())
                'Console.WriteLine("SGEN Ø=  " & Microsoft.VisualBasic.Asc("Ø").ToString())
                'Console.WriteLine("SGEN Å=  " & Microsoft.VisualBasic.Asc("Å").ToString())
                'Console.WriteLine("SGEN c=" & c & " " & Microsoft.VisualBasic.Asc(c).ToString())
                If Asc(c) = 95 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If '_

                    If Asc(c) = 59 And Name = "TRACK" Then
                        If IsValue Then ValueStr = ValueStr + c
                    End If  ' 59 ; 63 ?  61=

                    If Asc(c) = 61 And Name = "TRACK" Then
                        If IsValue Then ValueStr = ValueStr + c
                    End If  ' 61=

                    If Asc(c) = 63 And Name = "TRACK" Then
                        If IsValue Then ValueStr = ValueStr + c
                    End If  ' 59 ; 63 ?  61=

                    If Asc(c) >= 32 And Asc(c) <= 43 Then
                        If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                    End If  '  !..+

                    If Asc(c) >= 65 And Asc(c) <= 90 Then
                        If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                        '  MessageBox.Show("SGEN A..Z NAME=" & Name & " ValueStr= " & ValueStr)
                    End If  '  A..Z

                    If Asc(c) >= 134 And Asc(c) <= 157 Then
                        If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                    End If 'Æ..Å, æ..å

                If Asc(c) >= 97 And Asc(c) <= 122 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If 'a..z


                'Spessial: Norske tegn er endret fra Windows 8bit til 7-bit små bokstaver
                If Asc(c) = 123 Then
                    If IsValue Then ValueStr = ValueStr + "Æ" Else Name = Name + c
                End If 'Æ
                If Asc(c) = 124 Then
                    If IsValue Then ValueStr = ValueStr + "Ø" Else Name = Name + c
                End If 'Ø
                If Asc(c) = 125 Then
                    If IsValue Then ValueStr = ValueStr + "Å" Else Name = Name + c
                End If 'Å

                If Asc(c) >= 48 And Asc(c) <= 57 Then
                    If IsValue Then
                        ValueStr = ValueStr + c
                        '  MessageBox.Show("SGen ISValue ValueStr=" & ValueStr)
                    Else
                        Number = Number + c
                        ' MessageBox.Show("SGEN 0..9 Number=" & Number & " ValueStr= " & ValueStr)
                    End If '0..9
                End If

                    If Asc(c) = 46 Then
                        If IsValue Then ValueStr = ValueStr + c Else Number = Number + c
                    End If '.

                    If Asc(c) = 45 Then
                        If IsValue Then ValueStr = ValueStr + c Else Number = Number + c
                    End If '-

                    If Asc(c) = 61 And Name <> "TRACK" Then
                        If IsIndex Then
                            Index = CInt(Number)
                            Number = ""
                            IsIndex = False
                            IsValue = True
                        Else
                            'Console.Write("SGen = IsValue settes TRUE, NAME=")
                            'Console.WriteLine(Name)
                            'Console.Write("NUMBER=")
                            'Console.WriteLine(Number)
                            '20150103 Legger til en test på om det er en verdi uten index, som CREATED=20141002000016
                            'Section [GENERIC_FILE_INFO]
                            If Number = "" Then Number = "0"
                            Trans = CInt(Number)
                            Number = ""
                            IsValue = True
                        End If
                    End If '=

                    If Asc(c) = 61 And Name = "TRACK" And FirstTRACK Then
                        FirstTRACK = False
                        If IsIndex Then
                            'MessageBox.Show("TRACK" & Number & " ValueStr= " & ValueStr)
                            Index = CInt(Number)
                            Number = ""
                            IsIndex = False
                            IsValue = True

                        Else
                            If Number = "" Then Number = "0"
                            Trans = CInt(Number)
                            Number = ""
                            IsValue = True
                            ' MessageBox.Show("TRACK firstrack false  Trans" & Trans.ToString)
                        End If
                    End If '=


                    If Asc(c) = 44 Then
                        If IsValue Then
                            ValueStr = ValueStr + c
                        Else
                            Trans = CInt(Number)
                            Number = ""
                            IsIndex = True
                        End If
                    End If ',
            Next
            '<CR> {Les selve verdien}
            'MessageBox.Show("IsText Name=" & Name)

            IsText = getvalueType(Name)    'Finn verditype for denne item
            'MessageBox.Show("IsText=" & IsText)
            If IsText Then
                StrValue = ValueStr
            Else
                'DecimalSeparator = "."
                If ValueStr.Contains(".") Then
                    ValueStr = ValueStr.Replace(".", ",")
                    FloatValue = CDbl(ValueStr)
                    StrValue = CDbl(FloatValue)
                Else
                    'MessageBox.Show("ValueStr=" & ValueStr & " NAME=" & Name)
                    IntValue = CInt(ValueStr)
                    StrValue = IntValue.ToString
                End If
            End If
            ' MessageBox.Show("SGen NEXT ValueStr=" & ValueStr & " StrValue=" & StrValue)
        End If
        ' {SSection settes direkte når aktuell}
        SName = Name
        STrans = Trans
        'NorskeTegn(StrValue)
        SStrValue = StrValue
        SIntValue = IntValue
        SFloatValue = FloatValue
        SIndex = Index
        'If SName <> "" Then Console.WriteLine("DayRpt : SNAME=" & SName & " STrans=" & STrans & " SStrValue=" & SStrValue & " SIntValue=" & SIntValue & " SFloatValue=" & SFloatValue & " SIndex=" & SIndex & " FirstTrans=" & FirstTrans & " IsSection=" & IsSection)
        ' Insert into database VGen()
        'Preliminary Insert into general table structure
        DayReportRawTableAdapter.Insert(SSection, SName, STrans, SIndex, SStrValue)
    End Sub



    Private Sub SGenDayRpt()
        'MessageBox.Show(s)
        'Console.WriteLine(s)
        Dim c As Char
        Dim i As Integer
        Dim Name, Number, ValueStr, StrValue As String
        Dim Trans, Index, IntValue As Integer
        Dim FloatValue As Double
        Dim IsIndex, IsValue, IsText As Boolean
        IsText = False
        IsIndex = False
        IsValue = False
        IsSection = False
        Index = 0
        Trans = 0
        FloatValue = 0.0
        IntValue = 0
        ValueStr = ""
        StrValue = ""
        Name = ""
        Number = ""

        If s.Contains("[") And s.Contains("]") Then
            SSection = s.Substring(s.IndexOf("[") + 1, s.IndexOf("]") - s.IndexOf("[") - 1)
            Console.WriteLine("Section = " & SSection)
            IsSection = True
        Else

            For i = 1 To Len(s)

                c = s.Substring(i - 1, 1)
                '  MessageBox.Show("SGEN c= " & c & " " & Microsoft.VisualBasic.Asc(c).ToString())

                If Asc(c) = 95 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If '_

                If Asc(c) >= 32 And Asc(c) <= 43 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If  '  !..+

                If Asc(c) >= 65 And Asc(c) <= 90 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                    '  MessageBox.Show("SGEN A..Z NAME=" & Name & " ValueStr= " & ValueStr)
                End If  '  A..Z

                If Asc(c) >= 134 And Asc(c) <= 157 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If 'Æ..Å, æ..å

                If Asc(c) >= 97 And Asc(c) <= 122 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If 'a..z

                If Asc(c) >= 48 And Asc(c) <= 57 Then
                    If IsValue Then
                        ValueStr = ValueStr + c
                        '  MessageBox.Show("SGen ISValue ValueStr=" & ValueStr)
                    Else
                        Number = Number + c
                        ' MessageBox.Show("SGEN 0..9 Number=" & Number & " ValueStr= " & ValueStr)
                    End If '0..9
                End If

                If Asc(c) = 46 Then
                    If IsValue Then ValueStr = ValueStr + c Else Number = Number + c
                End If '.

                If Asc(c) = 45 Then
                    If IsValue Then ValueStr = ValueStr + c Else Number = Number + c
                End If '-

                If Asc(c) = 61 Then
                    If IsIndex Then
                        Index = CInt(Number)
                        Number = ""
                        IsIndex = False
                        IsValue = True
                    Else
                        'Console.Write("SGen = IsValue settes TRUE, NAME=")
                        'Console.WriteLine(Name)
                        'Console.Write("NUMBER=")
                        'Console.WriteLine(Number)
                        '20150103 Legger til en test på om det er en verdi uten index, som CREATED=20141002000016
                        'Section [GENERIC_FILE_INFO]
                        If Number = "" Then Number = "0"
                        Trans = CInt(Number)
                        Number = ""
                        IsValue = True
                    End If
                End If '=

                If Asc(c) = 44 Then
                    If IsValue Then
                        ValueStr = ValueStr + c
                    Else
                        Trans = CInt(Number)
                        Number = ""
                        IsIndex = True
                    End If
                End If ',
            Next
            '<CR> {Les selve verdien}
            'MessageBox.Show("IsText Name=" & Name)

            IsText = getvalueType(Name)    'Finn verditype for denne item
            'MessageBox.Show("IsText=" & IsText)
            If IsText Then
                StrValue = ValueStr
            Else
                'DecimalSeparator = "."
                If ValueStr.Contains(".") Then
                    ValueStr = ValueStr.Replace(".", ",")
                    FloatValue = CDbl(ValueStr)
                    StrValue = CDbl(FloatValue)
                Else
                    'MessageBox.Show("ValueStr=" & ValueStr & " NAME=" & Name)
                    IntValue = CInt(ValueStr)
                    StrValue = IntValue.ToString
                End If
            End If
            ' MessageBox.Show("SGen NEXT ValueStr=" & ValueStr & " StrValue=" & StrValue)
        End If
        ' {SSection settes direkte når aktuell}
        SName = Name
        STrans = Trans
        'NorskeTegn(StrValue)
        SStrValue = StrValue
        SIntValue = IntValue
        SFloatValue = FloatValue
        SIndex = Index
        If SName <> "" Then Console.WriteLine("DayRpt : SNAME=" & SName & " STrans=" & STrans & " SStrValue=" & SStrValue & " SIntValue=" & SIntValue & " SFloatValue=" & SFloatValue & " SIndex=" & SIndex & " FirstTrans=" & FirstTrans & " IsSection=" & IsSection)
        ' Insert into database VGen()
        'Preliminary Insert into general table structure
        DayReportRawTableAdapter.Insert(SSection, SName, STrans, SIndex, SStrValue)
    End Sub


    Private Sub SGen()
        'MessageBox.Show(s)
        'Console.WriteLine(s)
        Dim c As Char
        Dim i As Integer
        Dim Name, Number, ValueStr, StrValue As String
        Dim Trans, Index, IntValue As Integer
        Dim FloatValue As Double
        Dim IsIndex, IsValue, IsText As Boolean
        IsText = False
        IsIndex = False
        IsValue = False
        IsSection = False
        Index = 0
        Trans = 0
        FloatValue = 0.0
        IntValue = 0
        ValueStr = ""
        StrValue = ""
        Name = ""
        Number = ""

        If s.Contains("[") And s.Contains("]") Then
            SSection = s.Substring(s.IndexOf("[") + 1, s.IndexOf("]") - s.IndexOf("[") - 1)
            'MessageBox.Show("Section = " & SSection)
            IsSection = True
        Else

            For i = 1 To Len(s)

                c = s.Substring(i - 1, 1)
                '  MessageBox.Show("SGEN c= " & c & " " & Microsoft.VisualBasic.Asc(c).ToString())

                If Microsoft.VisualBasic.Asc(c) = 95 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If '_

                If Microsoft.VisualBasic.Asc(c) >= 32 And Microsoft.VisualBasic.Asc(c) <= 43 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If  '  !..+

                If Microsoft.VisualBasic.Asc(c) >= 65 And Microsoft.VisualBasic.Asc(c) <= 90 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                    '  MessageBox.Show("SGEN A..Z NAME=" & Name & " ValueStr= " & ValueStr)
                End If  '  A..Z

                If Microsoft.VisualBasic.Asc(c) >= 134 And Microsoft.VisualBasic.Asc(c) <= 157 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If 'Æ..Å, æ..å

                If Microsoft.VisualBasic.Asc(c) >= 97 And Microsoft.VisualBasic.Asc(c) <= 122 Then
                    If IsValue Then ValueStr = ValueStr + c Else Name = Name + c
                End If 'a..z

                If Microsoft.VisualBasic.Asc(c) >= 48 And Microsoft.VisualBasic.Asc(c) <= 57 Then
                    If IsValue Then
                        ValueStr = ValueStr + c
                        '  MessageBox.Show("SGen ISValue ValueStr=" & ValueStr)
                    Else
                        Number = Number + c
                        ' MessageBox.Show("SGEN 0..9 Number=" & Number & " ValueStr= " & ValueStr)
                    End If '0..9
                End If

                If Microsoft.VisualBasic.Asc(c) = 46 Then
                    If IsValue Then ValueStr = ValueStr + c Else Number = Number + c
                End If '.

                If Microsoft.VisualBasic.Asc(c) = 45 Then
                    If IsValue Then ValueStr = ValueStr + c Else Number = Number + c
                End If '-

                If Microsoft.VisualBasic.Asc(c) = 61 Then
                    If IsIndex Then
                        Index = CInt(Number)
                        Number = ""
                        IsIndex = False
                        IsValue = True
                    Else
                        'Console.Write("SGen = IsValue settes TRUE, NAME=")
                        'Console.WriteLine(Name)
                        'Console.Write("NUMBER=")
                        'Console.WriteLine(Number)
                        '20150103 Legger til en test på om det er en verdi uten index, som CREATED=20141002000016
                        'Section [GENERIC_FILE_INFO]
                        If Number = "" Then Number = "0"
                        Trans = CInt(Number)
                        Number = ""
                        IsValue = True
                    End If
                End If '=

                If Microsoft.VisualBasic.Asc(c) = 44 Then
                    If IsValue Then
                        ValueStr = ValueStr + c
                    Else
                        Trans = CInt(Number)
                        Number = ""
                        IsIndex = True
                    End If
                End If ',
            Next
            '<CR> {Les selve verdien}
            'MessageBox.Show("IsText Name=" & Name)

            IsText = getvalueType(Name)    'Finn verditype for denne item
            'MessageBox.Show("IsText=" & IsText)
            If IsText Then
                StrValue = ValueStr
            Else
                'DecimalSeparator = "."
                If ValueStr.Contains(".") Then
                    ValueStr = ValueStr.Replace(".", ",")
                    FloatValue = CDbl(ValueStr)
                    StrValue = CDbl(FloatValue)
                Else
                    'MessageBox.Show("ValueStr=" & ValueStr & " NAME=" & Name)
                    IntValue = CInt(ValueStr)
                    StrValue = IntValue.ToString
                End If
            End If
            ' MessageBox.Show("SGen NEXT ValueStr=" & ValueStr & " StrValue=" & StrValue)
        End If
        ' {SSection settes direkte når aktuell}
        SName = Name
        STrans = Trans
        'NorskeTegn(StrValue)
        SStrValue = StrValue
        SIntValue = IntValue
        SFloatValue = FloatValue
        SIndex = Index
        '      MessageBox.Show("SGen : SNAME=" & SName & " STrans=" & STrans & " SStrValue=" & SStrValue & " SIntValue=" & SIntValue & " SFloatValue=" & SFloatValue & " SIndex=" & SIndex & " FirstTrans=" & FirstTrans & " IsSection=" & IsSection)
        VGen()
    End Sub


    Private Sub TGen()
        Using TranFile As StreamReader = New StreamReader(FileName, True)
            s = TranFile.ReadLine
            Do While Not TranFile.EndOfStream
                'Les inn kort fra CUST_MUT-fil If Len(s) > 0 Then SGenCUST()
                'TEST av RunningTotals RunningTotal
                If RTFile Then
                    If Len(s) > 0 Then SGenDayRpt()
                Else
                    If Len(s) > 0 Then SGen()
                End If
                s = TranFile.ReadLine
            Loop
        End Using
    End Sub

    Private Sub Prepareimport()
        FirstTrans = True
        FirstIndex = True
        STrans = 0
        KeepTrans = 0
        FuelTrans = Me.DataSet1.ImpTrans.NewImpTransRow
        FuelItem = Me.DataSet1.ItemTable.NewItemTableRow
        ZeroFuelTrans()
        ZeroFuelItem()
    End Sub

    Private Sub MoveFiles()
        RTFile = False
        Button1.Text = "Running..."
        'TEST  Leser samme filer flere ganger
        Me.ImpTransTableAdapter.Delete()
        Me.ItemTableTableAdapter.Delete()
        Me.FP_TransTableAdapter.DeleteAll()
        Me.FP_ItemsTableAdapter.DeleteAll()
        'Flytter alle nye filer fra FTP til importområdet
        'importerer en og en fil Fra C:\FPtemp Til "C:\FuelPOS\<anlegg>\EXPORT\EBOC\"
        'Deretter slettes alle fra FTP.
        Dim startnr, filnr As Integer
        Dim ImpPath, FTPpath, BakPath, ImpFile As String
        FTPpath = "C:\FPtemp\"
        ImpPath = "C:\FuelPOS\L2052\EXPORT\EBOC\"
        BakPath = "C:\FuelPOS\L2052\EXPORT\EBOC\BAK\"
        'test startnr = 20041240 - 20041351 'Station_ID(4) + REF(4)
        startnr = GetFilenr("2052")
        filnr = 0
        ' NB! Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories tar med alt og alle!
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(FTPpath, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.ctf")
            filnr = CInt(foundFile.Substring(foundFile.IndexOf(".") - 8, 8))
            If (filnr > startnr) Then
                ListBox1.Items.Add(foundFile)
                ImpFile = foundFile.Substring(foundFile.IndexOf(".") - 8, 12)
                'Kopierer til import path 
                My.Computer.FileSystem.CopyFile(foundFile, ImpPath & ImpFile, True)
                FileName = ImpPath & ImpFile
                Prepareimport()
                TGen()
                'Flytter fil til BAK
                My.Computer.FileSystem.MoveFile(ImpPath & ImpFile, BakPath & ImpFile, True)
            End If
        Next
        ' Sletter alt fra TEMP
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(FTPpath, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            My.Computer.FileSystem.DeleteFile(foundFile)
        Next
        If filnr > startnr Then
            SetFilenr("2052", filnr)
            'MessageBox.Show(filnr)
            KopierNye(startnr)
            KopierAzureSQLDB(startnr)
        End If
        Button1.Text = "Waiting..."
    End Sub

    Private Sub MoveDayRPTFiles()
        'Flytter alle nye filer fra FTP til importområdet
        'importerer en og en fil Fra C:\FPtemp Til "C:\FuelPOS\<anlegg>\EXPORT\EBOC\"
        'Deretter slettes alle fra FTP.
        Dim startnr, filnr As Integer
        Dim ImpPath, FTPpath, BakPath, ImpFile As String
        FTPpath = "C:\FPtemp\"
        ImpPath = "C:\FuelPOS\L2052\EXPORT\EBOC\"
        BakPath = "C:\FuelPOS\L2052\EXPORT\EBOC\BAK\"
        'Filenr is Station_ID(4) + REF(4)
        startnr = GetDayRPTFilenr("2052")
        filnr = 0
        ' NB! Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories tar med alt og alle!
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(FTPpath, Microsoft.VisualBasic.FileIO.SearchOption.SearchAllSubDirectories, "*.p")
            filnr = CInt(foundFile.Substring(foundFile.IndexOf(".") - 8, 8))
            If (filnr > startnr) Then
                ListBox1.Items.Add(foundFile)
                ImpFile = foundFile.Substring(foundFile.IndexOf(".") - 8, 10)
                'Kopierer til import path 
                My.Computer.FileSystem.CopyFile(foundFile, ImpPath & ImpFile, True)
                FileName = ImpPath & ImpFile
                ZeroRT()
                TGen()
                UpdateDayReportAzure() 'Insert to Azure database
                'Flytter fil til BAK
                My.Computer.FileSystem.MoveFile(ImpPath & ImpFile, BakPath & ImpFile, True)
            End If
        Next
        ' Sletter alt fra TEMP
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(FTPpath, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "*.*")
            My.Computer.FileSystem.DeleteFile(foundFile)
        Next
        If filnr > startnr Then
            SetDayRPTFilenr("2052", filnr)
        End If
    End Sub

    Private Sub OpenFile()
        Dim OpenFileDialog As New OpenFileDialog
        ' OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.InitialDirectory = "C:\FuelPosData\POS Importer\data"
        OpenFileDialog.Filter = "Text Files (*.ctf)|*.ctf|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            FileName = OpenFileDialog.FileName
        End If
    End Sub

    Private Sub KopierNye(FileNr As [String])
        FileNr = FileNr.Substring(4, 4) & "000000"
        'MessageBox.Show(FileNr)
        Dim Antall As Integer
        Dim cmd As New Odbc.OdbcCommand
        Dim ODBCConnection As New Odbc.OdbcConnection("DSN=FuelPOS")
        cmd.CommandText = "Insert into FP_TRANS SELECT * FROM ImpTrans where REF > ?"
        cmd.CommandType = CommandType.Text
        cmd.Connection = ODBCConnection
        ODBCConnection.Open()
        cmd.Parameters.Add(New OdbcParameter("ref", OdbcType.NVarChar))
        cmd.Parameters("ref").Value = FileNr
        Antall = cmd.ExecuteNonQuery()
        'MessageBox.Show(" Antall nye TRANS er " & Antall.ToString)
        ODBCConnection.Close()
        cmd.CommandText = "Insert into FP_Items SELECT * FROM ItemTable where REF > ?"
        cmd.CommandType = CommandType.Text
        cmd.Connection = ODBCConnection
        ODBCConnection.Open()
        cmd.Parameters.Add(New OdbcParameter("ref", OdbcType.NVarChar))
        cmd.Parameters("ref").Value = FileNr
        Antall = cmd.ExecuteNonQuery()
        'MessageBox.Show(" Antall nye ITEMS er " & Antall.ToString)
        ODBCConnection.Close()
    End Sub

    Private Sub KopierAzureSQLDB(FileNr As [String])
        'Bruker SQLDB mot Azure og ODBC mot Access
        'Parameterized cmd-query mot Azure
        FileNr = FileNr.Substring(4, 4) & "000000"
        Dim returnValue As Integer

        'Access database, ODBC
        Dim cmd As New Odbc.OdbcCommand
        Dim ODBCConnection As New Odbc.OdbcConnection("DSN=FuelPOS")
        Dim TransReader As Odbc.OdbcDataReader

        'Transation headers        
        'Tar alle nå, må filtere på kun nye
        cmd.CommandText = "SELECT * FROM FP_Trans where REF > ?"
        cmd.CommandType = CommandType.Text
        cmd.Connection = ODBCConnection
        ODBCConnection.Open()
        cmd.Parameters.Add(New OdbcParameter("ref", OdbcType.NVarChar))
        cmd.Parameters("ref").Value = FileNr

        'Azure connection and Command 
        Dim insertcmd As New SqlCommand
        Dim AZUREConnection As New SqlConnection("Server=tcp:fuelpos-server.database.windows.net,1433;Database=fuelpos-db;User ID=seiler_6@fuelpos-server;Password=Draugen2011;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")

        insertcmd.CommandType = CommandType.Text
        insertcmd.Connection = AZUREConnection
        insertcmd.CommandText = "INSERT into TransImps (Dati, Seq, Typ, Station_Nr, Cust, Cnam, Info, Pm, Pa, Ref) VALUES (@Dati, @Seq, @Typ, @Station_Nr, @Cust, @Cnam, @Info, @Pm, @Pa, @TransRef)"
        AZUREConnection.Open()
        insertcmd.Parameters.Add(New SqlParameter("Dati", SqlDbType.NVarChar))
        insertcmd.Parameters.Add(New SqlParameter("Seq", SqlDbType.NVarChar))
        insertcmd.Parameters.Add(New SqlParameter("Typ", SqlDbType.Int))
        insertcmd.Parameters.Add(New SqlParameter("Station_Nr", SqlDbType.Int))
        insertcmd.Parameters.Add(New SqlParameter("Cust", SqlDbType.Int))
        insertcmd.Parameters.Add(New SqlParameter("Cnam", SqlDbType.NVarChar))
        insertcmd.Parameters.Add(New SqlParameter("Info", SqlDbType.NVarChar))
        insertcmd.Parameters.Add(New SqlParameter("Pm", SqlDbType.Int, 200))
        insertcmd.Parameters.Add(New SqlParameter("Pa", SqlDbType.Float, 200))
        insertcmd.Parameters.Add(New SqlParameter("TransRef", SqlDbType.NVarChar))

        TransReader = cmd.ExecuteReader
        Do While TransReader.Read()
            'MessageBox.Show("Nye TRANS til AZURE: " & TransReader.Item("Ref"))
            insertcmd.Parameters("Dati").Value = TransReader.Item("Dati").ToString()
            insertcmd.Parameters("Seq").Value = TransReader.Item("Seq").ToString()
            insertcmd.Parameters("Typ").Value = TransReader.Item("Typ").ToString()
            insertcmd.Parameters("Station_Nr").Value = TransReader.Item("Station_Nr").ToString()
            insertcmd.Parameters("Cust").Value = TransReader.Item("Cust").ToString()
            insertcmd.Parameters("Cnam").Value = TransReader.Item("Cnam").ToString()
            insertcmd.Parameters("Info").Value = TransReader.Item("Info").ToString()
            insertcmd.Parameters("Pm").Value = TransReader.Item("Pm").ToString()
            insertcmd.Parameters("Pa").Value = TransReader.Item("Pa").ToString()
            insertcmd.Parameters("TransRef").Value = TransReader.Item("Ref").ToString()
            insertcmd.ExecuteNonQuery()
            'MessageBox.Show("Insert til AZURE: " & insertcmd.CommandText)
        Loop
        ODBCConnection.Close()
        'Commit
        AZUREConnection.Close()

        'Transation details        
        'Tar alle nå, må filtere på kun nye
        cmd.CommandText = "SELECT * FROM FP_Items where REF > ?"
        cmd.CommandType = CommandType.Text
        cmd.Connection = ODBCConnection
        ODBCConnection.Open()
        cmd.Parameters.Add(New OdbcParameter("ref", OdbcType.NVarChar))
        cmd.Parameters("ref").Value = FileNr
        TransReader = cmd.ExecuteReader

        'Azure
        insertcmd.CommandText = "INSERT into ItemImps (TransImpID, Pmp, [Index], Nam,Qty,Pri,Prc,Vamt,Dsct,Dnam,Dsc,Ldsc,Gamt,Amt) VALUES (@TransImpID, @Pmp, @Index, @Nam,@Qty,@Pri,@Prc,@Vamt,@Dsct,@Dnam,@Dsc,@Ldsc,@Gamt,@Amt)"
        AZUREConnection.Open()
        insertcmd.Parameters.Add(New SqlParameter("TransImpId", SqlDbType.Int))
        insertcmd.Parameters.Add(New SqlParameter("Pmp", SqlDbType.Int))
        insertcmd.Parameters.Add(New SqlParameter("Index", SqlDbType.Int))
        insertcmd.Parameters.Add(New SqlParameter("Nam", SqlDbType.NVarChar))
        insertcmd.Parameters.Add(New SqlParameter("DNam", SqlDbType.NVarChar))
        insertcmd.Parameters.Add(New SqlParameter("Qty", SqlDbType.Float))
        insertcmd.Parameters.Add(New SqlParameter("Pri", SqlDbType.Float))
        insertcmd.Parameters.Add(New SqlParameter("Prc", SqlDbType.Int))
        insertcmd.Parameters.Add(New SqlParameter("Dsct", SqlDbType.Int))
        insertcmd.Parameters.Add(New SqlParameter("Ldsc", SqlDbType.Int))
        insertcmd.Parameters.Add(New SqlParameter("Dsc", SqlDbType.Int))
        insertcmd.Parameters.Add(New SqlParameter("Gamt", SqlDbType.Float))
        insertcmd.Parameters.Add(New SqlParameter("Vamt", SqlDbType.Float))
        insertcmd.Parameters.Add(New SqlParameter("Amt", SqlDbType.Float))

        Do While TransReader.Read()
            'Fill the new row
            returnValue = CType(TransImpsTableAdapter.GetDataByRef(TransReader.Item("Ref").ToString()).Rows(0)("ID"), Integer)
            insertcmd.Parameters("TransImpId").Value = returnValue
            insertcmd.Parameters("Pmp").Value = TransReader.Item("Pmp").ToString()
            insertcmd.Parameters("Index").Value = TransReader.Item("Index").ToString()
            insertcmd.Parameters("Nam").Value = TransReader.Item("Nam").ToString()
            insertcmd.Parameters("DNam").Value = TransReader.Item("DNam").ToString()
            insertcmd.Parameters("Qty").Value = TransReader.Item("Qty").ToString()
            insertcmd.Parameters("Pri").Value = TransReader.Item("Pri").ToString()
            insertcmd.Parameters("Prc").Value = TransReader.Item("Prc").ToString()
            insertcmd.Parameters("Dsct").Value = TransReader.Item("Dsct").ToString()
            insertcmd.Parameters("Ldsc").Value = TransReader.Item("Ldsc").ToString()
            insertcmd.Parameters("Dsc").Value = TransReader.Item("Dsc").ToString()
            insertcmd.Parameters("Gamt").Value = TransReader.Item("Gamt").ToString()
            insertcmd.Parameters("Vamt").Value = TransReader.Item("Vamt").ToString()
            insertcmd.Parameters("Amt").Value = TransReader.Item("Amt").ToString()
            'MessageBox.Show("Insert til AZURE: " & insertcmd.CommandText)
            insertcmd.ExecuteNonQuery()

        Loop
        ODBCConnection.Close()
        AZUREConnection.Close()

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GetCTF()
        MoveFiles()
    End Sub

    Private Sub FuelImp1BindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.FuelImp1BindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DataSet1)

    End Sub

    Private Sub FP_TransBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs)
        Me.Validate()
        Me.FP_TransBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DataSet1)

    End Sub

    Private Sub FP_TransBindingNavigatorSaveItem_Click_1(sender As Object, e As EventArgs)
        Me.Validate()
        Me.FP_TransBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DataSet1)

    End Sub

    Private Sub FP_TransBindingNavigatorSaveItem_Click_2(sender As Object, e As EventArgs)
        Me.Validate()
        Me.FP_TransBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DataSet1)

    End Sub

    Private Function GetFilenr(StationNr As [String])
        Dim NewFileNr As [String] = ""
        Dim StationStatusData As DataSet1.StationStatusRow
        StationStatusData = DataSet1.StationStatus.FindByStation_Nr(StationNr)
        NewFileNr = StationStatusData.LastTransFileNr
        Return NewFileNr
    End Function

    Private Function GetDayRPTFilenr(StationNr As [String])
        Dim NewFileNr As [String] = ""
        Dim StationStatusData As DataSet1.StationStatusRow
        StationStatusData = DataSet1.StationStatus.FindByStation_Nr(StationNr)
        NewFileNr = StationStatusData.LastDayRPTFileNr
        Return NewFileNr
    End Function

    Private Sub SetFilenr(StationNr As [String], FileNr As [String])
        Dim StationStatusData As DataSet1.StationStatusRow
        StationStatusData = DataSet1.StationStatus.FindByStation_Nr(StationNr)
        StationStatusData.LastTransFileNr = FileNr
        Me.StationStatusTableAdapter.Update(Me.DataSet1.StationStatus)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        LastRunTime.Text = DateAndTime.Now
        'Transer - kun manuelt i testperioden
        'GetCTF()
        'MoveFiles()

        'RunningTotals kun manuelt
        'GetRT()
        LagArtMutFilAzure()
        Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Timer1.Enabled = False Then
            Timer1.Enabled = True
            Button1.Text = "Timer set " & Timer1.Interval.ToString() & " ms"
        Else
            Timer1.Enabled = False
            Button1.Text = "Start timer"
        End If
    End Sub

    Private Sub GetCTF()
        'Send file from local PC to ftp-host
        'https://msdn.microsoft.com/en-us/library/dfkdh7eb%28v=vs.90%29.aspx
        'Download from FTP
        'https://msdn.microsoft.com/en-us/library/ack30t8y%28v=vs.90%29.aspx
        'List files on host:
        'http://stackoverflow.com/questions/14076973/how-to-list-directory-contents-of-an-ftp-connection

        'Put files on the FTP-site
        ' My.Computer.Network.UploadFile("C:\temp\Order.txt", ftp.Host,  ftp.Credentials.UserName, ftp.Credentials.Password, False, 500, True)

        'Get files from FuelPOS to C:\FPTemp
        'Assumes VPN is connected
        ConnectVPN()
        Using ftp = New FtpClient()
            ftp.Host = "10.84.208.163"
            ftp.Credentials = New NetworkCredential("FTP_E01", "2FFB17966")

            ftp.SetWorkingDirectory("C:/EXPORT/EBOC/")
            For Each item In ftp.GetListing()

                Select Case item.Type
                    Case FtpFileSystemObjectType.Directory
                        Console.WriteLine("Folder:" + item.FullName)
                    Case FtpFileSystemObjectType.File
                        Console.WriteLine("File: " + ftp.Host & "/" & item.FullName.Substring(3, Len(item.FullName) - 3) & " " & item.Name)
                        My.Computer.Network.DownloadFile("ftp://" & ftp.Host & "/" & item.FullName.Substring(3, Len(item.FullName) - 3), "C:\FPtemp\" & item.Name, ftp.Credentials.UserName, ftp.Credentials.Password, False, 50000, True)
                End Select
            Next
        End Using
        DisconnectVPN()
    End Sub

    Private Sub GetRT()
        'Complete fetch and update Running Totals
        RTFile = True
        ZeroRT()
        'Get files from FuelPOS to C:\FPTemp
        'Assumes VPN is connected
        ConnectVPN()
        Using ftp = New FtpClient()
            ftp.Host = "10.84.208.163"
            ftp.Credentials = New NetworkCredential("FTP_E01", "2FFB17966")
            'ftp.SetWorkingDirectory("C:/pro_boc/EBOC/")
            Try
                My.Computer.Network.DownloadFile("ftp://10.84.208.163/pro_bo/EBOC/20520000.RT", "C:\FPtemp\20520000.RT", ftp.Credentials.UserName, ftp.Credentials.Password, False, 50000, True)
            Catch ex As Exception
                MessageBox.Show("ftp failed download RT-file: " & ex.Message)
            End Try
        End Using
        DisconnectVPN()
        FileName = "C:\FPtemp\20520000.RT"
        TGen()
        UpdateRTAzure()
        UpdateTankStatusAzure()
    End Sub


    Private Sub GetDayReport()
        'Complete fetch and update Day Report
        MessageBox.Show("Hent Dayreport! Sett filnavn")
        RTFile = True
        ZeroRT()
        'Assumes File is present
        FileName = DayReportFileName.Text
        '"C:\Users\Prince\Desktop\20520051.p"
        TGen()
    End Sub


    Private Sub ConnectVPN()
        Dim StartFTP As Process = Process.Start("cmd", "/c C:\Temp\VPNConnectL2052.cmd")
        StartFTP.WaitForExit()
    End Sub

    Private Sub DisconnectVPN()
        Dim StopFTP As Process = Process.Start("cmd", "/c C:\Temp\VPNDisconnectL2052.cmd")
        StopFTP.WaitForExit()
    End Sub


    Private Sub FtpPutArtFiles()
        Dim FTPpath, BakPath, ImpFile As String
        FTPpath = "C:\FPtemp\ArtMut\"
        BakPath = "C:\FPtemp\ArtMut\BAK\"
        ConnectVPN()
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(FTPpath, Microsoft.VisualBasic.FileIO.SearchOption.SearchTopLevelOnly, "ART_MUT.*")
            ImpFile = foundFile.Substring(foundFile.IndexOf(".") - 7, 11)
            'MessageBox.Show("Fil: " & ImpFile)

            ' set up request...
            Dim clsRequest As System.Net.FtpWebRequest = _
                DirectCast(System.Net.WebRequest.Create("ftp://10.84.208.163/pro_bo/EBOC/" & ImpFile), System.Net.FtpWebRequest)
            clsRequest.Credentials = New System.Net.NetworkCredential("FTP_E01", "2FFB17966")
            clsRequest.Method = System.Net.WebRequestMethods.Ftp.UploadFile

            ' read in file...
            Dim bFile() As Byte = System.IO.File.ReadAllBytes(FTPpath & ImpFile)

            ' upload file...
            Dim clsStream As System.IO.Stream = _
                clsRequest.GetRequestStream()
            clsStream.Write(bFile, 0, bFile.Length)
            clsStream.Close()
            clsStream.Dispose()
            'Flytter fil til BAK
            My.Computer.FileSystem.MoveFile(FTPpath & ImpFile, BakPath & ImpFile, True)
        Next
        DisconnectVPN()
    End Sub
    Private Sub PutART()
        'Send file from local PC to ftp-host
        'https://msdn.microsoft.com/en-us/library/dfkdh7eb%28v=vs.90%29.aspx
        'Download from FTP
        'https://msdn.microsoft.com/en-us/library/ack30t8y%28v=vs.90%29.aspx
        'List files on host:
        'http://stackoverflow.com/questions/14076973/how-to-list-directory-contents-of-an-ftp-connection

        'Put files on the FTP-site
        ' My.Computer.Network.UploadFile("C:\temp\Order.txt", ftp.Host,  ftp.Credentials.UserName, ftp.Credentials.Password, False, 500, True)

        'Put files from C:\FPtemp\ArtMut\ to FuelPOS
        'Assumes VPN is connected
        Using ftp = New FtpClient()
            ftp.Host = "ftp://10.84.208.163"
            ftp.Credentials = New NetworkCredential("FTP_E01", "2FFB17966")
            ftp.SetWorkingDirectory("C:/pro_bo/EBOC/")
            My.Computer.Network.UploadFile("C:\FPtemp\ArtMut\ART_MUT.019", ftp.Host, ftp.Credentials.UserName, ftp.Credentials.Password, False, 500, True)
        End Using
    End Sub


    Private Sub TimerDelay_TextChanged(sender As Object, e As EventArgs) Handles TimerDelay.TextChanged
        Timer1.Interval = CInt(TimerDelay.Text)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        ' Running Totals
        RTFile = True
        ZeroRT()
        'Assumes files are fetched from FuelPOS to C:\FPTemp
        FileName = "C:\FPtemp\20520000.RT"
        TGen()
        UpdateRTAzure()
        'MessageBox.Show("Nå Azure Tankstatus!")
        UpdateTankStatusAzure()
    End Sub

    Private Sub UpdateRTAzure()
        'Access database, ODBC
        Dim cmd As New Odbc.OdbcCommand
        Dim ODBCConnection As New Odbc.OdbcConnection("DSN=FuelPOS")
        Dim TransReader As Odbc.OdbcDataReader
        'Read FuelNo, FuelName, Quantity 
        cmd.CommandText = "SELECT FuelNo, FuelName, Quantity FROM TANK_STATUS"
        cmd.CommandType = CommandType.Text
        cmd.Connection = ODBCConnection
        ODBCConnection.Open()
        'Azure connection and Command 
        Dim insertcmd As New SqlCommand
        Dim AZUREConnection As New SqlConnection("Server=tcp:fuelpos-server.database.windows.net,1433;Database=fuelpos-db;User ID=seiler_6@fuelpos-server;Password=Draugen2011;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
        insertcmd.CommandType = CommandType.Text
        insertcmd.Connection = AZUREConnection
        'Bruker DB-dato, kan bruke [GLOBAL_FUEL_INDEX] DATI = 20150513141259
        'Må legge til 2 timer METDST
        insertcmd.CommandText = "UPDATE TankStatus set AktVolum= @Quantity, Oppdatert= DATEADD(hh,2,getdate())  where Drivstoff=@FuelName"
        AZUREConnection.Open()
        insertcmd.Parameters.Add(New SqlParameter("Quantity", SqlDbType.Float))
        insertcmd.Parameters.Add(New SqlParameter("FuelName", SqlDbType.NVarChar))
        ' insertcmd.Parameters.Add(New SqlParameter("Dato", SqlDbType.Date))

        TransReader = cmd.ExecuteReader
        Do While TransReader.Read()
            'MessageBox.Show("Nye TRANS til AZURE: " & (TransReader.Item("Quantity").ToString().Substring(0, TransReader.Item("Quantity").ToString().IndexOf("."))))
            insertcmd.Parameters("Quantity").Value = (TransReader.Item("Quantity").ToString().Substring(0, TransReader.Item("Quantity").ToString().IndexOf(".")))
            insertcmd.Parameters("FuelName").Value = TransReader.Item("FuelName").ToString()
            ' insertcmd.Parameters("Dato").Value = DateString()
            insertcmd.ExecuteNonQuery()
        Loop
        ODBCConnection.Close()
        AZUREConnection.Close()
    End Sub

    Private Sub UpdateDayReportAzure()
        'Insert one instance of dayReport into Azure
        'Access database, ODBC
        Dim cmd As New Odbc.OdbcCommand
        Dim DateCmd As New Odbc.OdbcCommand
        Dim ODBCConnection As New Odbc.OdbcConnection("DSN=FuelPOS")
        Dim TransReader As Odbc.OdbcDataReader

        'Read date for this report
        Dim ReportDateStr As String
        Dim ReportDate As Date
        Dim pattern As String = "yyyyMMddHHmmss"
        DateCmd.CommandText = "SELECT ReportDate FROM DayReportDate"
        DateCmd.CommandType = CommandType.Text
        DateCmd.Connection = ODBCConnection
        ODBCConnection.Open()
        TransReader = DateCmd.ExecuteReader()
        TransReader.Read()
        ReportDateStr = TransReader.Item("ReportDate") '20150712235319
        'MessageBox.Show("dato= " + ReportDateStr)
        If DateTime.TryParseExact(ReportDateStr, pattern, Nothing,
                                    DateTimeStyles.None, ReportDate) Then
            Console.WriteLine("Converted '{0}' to {1:d}.",
                              ReportDateStr, ReportDate)
        Else
            Console.WriteLine("Unable to convert '{0}' to a date and time.",
                              ReportDateStr)
        End If
        ODBCConnection.Close()

        'Read FuelNo, FuelName, Quantity 
        cmd.CommandText = "SELECT FuelNo, FuelName, Quantity, GAMT, PRI, ITEMIndex FROM DayReport1"
        cmd.CommandType = CommandType.Text
        cmd.Connection = ODBCConnection
        ODBCConnection.Open()
        'Azure connection and Command 
        Dim insertcmd As New SqlCommand
        Dim AZUREConnection As New SqlConnection("Server=tcp:fuelpos-server.database.windows.net,1433;Database=fuelpos-db;User ID=seiler_6@fuelpos-server;Password=Draugen2011;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
        insertcmd.CommandType = CommandType.Text
        insertcmd.Connection = AZUREConnection
        'Sletter de gamle først???
        'insertcmd.CommandText = "Delete FROM DayReports"
        'AZUREConnection.Open()
        'insertcmd.ExecuteNonQuery()
        'AZUREConnection.Close()

        'Må legge til 2 timer METDST
        insertcmd.CommandText = "INSERT into DayReports (BFL, NAM, QUA, GAMT, PRI, Oppdatert, Stasjon) VALUES (@BFL, @NAM, @QUA, @GAMT, @PRI, @Oppdatert, @Stasjon)"
        AZUREConnection.Open()
        insertcmd.Parameters.Add(New SqlParameter("BFL", SqlDbType.Int, 200))
        insertcmd.Parameters.Add(New SqlParameter("NAM", SqlDbType.NVarChar))
        insertcmd.Parameters.Add(New SqlParameter("QUA", SqlDbType.Float, 200))
        insertcmd.Parameters.Add(New SqlParameter("GAMT", SqlDbType.Float, 200))
        insertcmd.Parameters.Add(New SqlParameter("PRI", SqlDbType.Float, 200))
        insertcmd.Parameters.Add(New SqlParameter("Oppdatert", SqlDbType.Date))
        insertcmd.Parameters.Add(New SqlParameter("Stasjon", SqlDbType.Int, 200))

        TransReader = cmd.ExecuteReader
        Do While TransReader.Read()
            insertcmd.Parameters("BFL").Value = TransReader.Item("FuelNo")
            insertcmd.Parameters("NAM").Value = TransReader.Item("FuelName")
            insertcmd.Parameters("QUA").Value = TransReader.Item("Quantity").ToString().Replace(".", ",")
            insertcmd.Parameters("GAMT").Value = TransReader.Item("GAMT").ToString().Replace(".", ",")
            insertcmd.Parameters("PRI").Value = TransReader.Item("PRI").ToString().Replace(".", ",")
            insertcmd.Parameters("Stasjon").Value = 2052
            insertcmd.Parameters("Oppdatert").Value = ReportDate 'Date.Today
            insertcmd.ExecuteNonQuery()
        Loop
        ODBCConnection.Close()
        AZUREConnection.Close()

        '
        '200150831:
        'Legger til ymse rapportverdier i ny tabell
        '
        'Read Bank amounts
        cmd.CommandText = "SELECT BANKAXEPT, VISA, MASTERCARD FROM DayReportBank"
        cmd.CommandType = CommandType.Text
        cmd.Connection = ODBCConnection
        ODBCConnection.Open()
        'Azure connection and Command 
        insertcmd.CommandType = CommandType.Text
        insertcmd.Connection = AZUREConnection
        insertcmd.CommandText = "INSERT into DayReportValues (Stasjon, Oppdatert, ValueName, ReportValue, ReportText ) VALUES (@Stasjon, @Oppdatert, @ValueName, @ReportValue, @ReportText)"
        AZUREConnection.Open()
        insertcmd.Parameters.Add(New SqlParameter("ValueName", SqlDbType.NVarChar))
        insertcmd.Parameters.Add(New SqlParameter("ReportValue", SqlDbType.Float, 200))
        insertcmd.Parameters.Add(New SqlParameter("ReportText", SqlDbType.NVarChar))

        TransReader = cmd.ExecuteReader
        Do While TransReader.Read()
            insertcmd.Parameters("Stasjon").Value = 2052
            insertcmd.Parameters("Oppdatert").Value = ReportDate 'Date.Today   
            insertcmd.Parameters("ValueName").Value = "BANKAXEPT"
            insertcmd.Parameters("ReportValue").Value = TransReader.Item("BANKAXEPT").ToString().Replace(".", ",")
            insertcmd.Parameters("ReportText").Value = "BANKAXEPT"
            insertcmd.ExecuteNonQuery()
            insertcmd.Parameters("ValueName").Value = "VISA"
            insertcmd.Parameters("ReportValue").Value = TransReader.Item("VISA").ToString().Replace(".", ",")
            insertcmd.Parameters("ReportText").Value = "VISA"
            insertcmd.ExecuteNonQuery()
            insertcmd.Parameters("ValueName").Value = "MASTERCARD"
            insertcmd.Parameters("ReportValue").Value = TransReader.Item("MASTERCARD").ToString().Replace(".", ",")
            insertcmd.Parameters("ReportText").Value = "MASTERCARD"
            insertcmd.ExecuteNonQuery()
        Loop
        ODBCConnection.Close()
        AZUREConnection.Close()

        'Read mva amounts
        cmd.CommandText = "SELECT TEX, TVA, TOT FROM DayReportMVA"
        cmd.CommandType = CommandType.Text
        cmd.Connection = ODBCConnection
        ODBCConnection.Open()
        'Azure connection and Command 
        insertcmd.CommandType = CommandType.Text
        insertcmd.Connection = AZUREConnection
        insertcmd.CommandText = "INSERT into DayReportValues (Stasjon, Oppdatert, ValueName, ReportValue, ReportText ) VALUES (@Stasjon, @Oppdatert, @ValueName, @ReportValue, @ReportText)"
        AZUREConnection.Open()
        TransReader = cmd.ExecuteReader
        Do While TransReader.Read()
            insertcmd.Parameters("Stasjon").Value = 2052
            insertcmd.Parameters("Oppdatert").Value = ReportDate 'Date.Today   
            insertcmd.Parameters("ValueName").Value = "TEX"
            insertcmd.Parameters("ReportValue").Value = TransReader.Item("TEX").ToString().Replace(".", ",")
            insertcmd.Parameters("ReportText").Value = "Total Ex MVA"
            insertcmd.ExecuteNonQuery()
            insertcmd.Parameters("ValueName").Value = "TVA"
            insertcmd.Parameters("ReportValue").Value = TransReader.Item("TVA").ToString().Replace(".", ",")
            insertcmd.Parameters("ReportText").Value = "Total MVA"
            insertcmd.ExecuteNonQuery()
            insertcmd.Parameters("ValueName").Value = "TOT"
            insertcmd.Parameters("ReportValue").Value = TransReader.Item("TOT").ToString().Replace(".", ",")
            insertcmd.Parameters("ReportText").Value = "Total inkl MVA"
            insertcmd.ExecuteNonQuery()
        Loop
        ODBCConnection.Close()
        AZUREConnection.Close()





















    End Sub

    Private Sub SetDayRPTFilenr(StationNr As [String], FileNr As String)
        Dim StationStatusData As DataSet1.StationStatusRow
        StationStatusData = DataSet1.StationStatus.FindByStation_Nr(StationNr)
        StationStatusData.LastDayRPTFileNr = FileNr
        Me.StationStatusTableAdapter.Update(Me.DataSet1.StationStatus)
    End Sub

    Private Sub UpdateTankStatusAzure()
        'Access database, ODBC
        Dim cmd As New Odbc.OdbcCommand
        Dim ODBCConnection As New Odbc.OdbcConnection("DSN=FuelPOS")
        Dim TransReader As Odbc.OdbcDataReader
        'Read FuelNo, FuelName, Quantity 
        cmd.CommandText = "SELECT FuelNo, FuelName, Quantity FROM TANK_STATUS"
        cmd.CommandType = CommandType.Text
        cmd.Connection = ODBCConnection
        ODBCConnection.Open()
        'Azure connection and Command 
        Dim insertcmd As New SqlCommand
        Dim AZUREConnection As New SqlConnection("Server=tcp:tankstatus.database.windows.net,1433;Database=TankStatus_db;User ID=Stavanger@tankstatus;Password=St@vanger2015;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
        insertcmd.CommandType = CommandType.Text
        insertcmd.Connection = AZUREConnection
        'Bruker DB-dato, kan bruke [GLOBAL_FUEL_INDEX] DATI = 20150513141259
        'Må legge til 2 timer METDST
        insertcmd.CommandText = "UPDATE tankvolums set AktVolum= @Quantity, Oppdatert= DATEADD(hh,2,getdate())  where Drivstoff=@FuelName"
        AZUREConnection.Open()
        insertcmd.Parameters.Add(New SqlParameter("Quantity", SqlDbType.Float))
        insertcmd.Parameters.Add(New SqlParameter("FuelName", SqlDbType.NVarChar))
        ' insertcmd.Parameters.Add(New SqlParameter("Dato", SqlDbType.Date))

        TransReader = cmd.ExecuteReader
        Do While TransReader.Read()
            'MessageBox.Show("Nye TRANS til AZURE: " & (TransReader.Item("Quantity").ToString().Substring(0, TransReader.Item("Quantity").ToString().IndexOf("."))))
            insertcmd.Parameters("Quantity").Value = (TransReader.Item("Quantity").ToString().Substring(0, TransReader.Item("Quantity").ToString().IndexOf(".")))
            insertcmd.Parameters("FuelName").Value = TransReader.Item("FuelName").ToString()
            ' insertcmd.Parameters("Dato").Value = DateString()
            insertcmd.ExecuteNonQuery()
        Loop
        ODBCConnection.Close()
        AZUREConnection.Close()
    End Sub

    Private Sub ZeroRT()
        'Access database, ODBC
        Dim cmd As New Odbc.OdbcCommand
        Dim ODBCConnection As New Odbc.OdbcConnection("DSN=FuelPOS")
        'Delete tep-table
        cmd.CommandText = "Delete FROM DayReportRaw"
        cmd.CommandType = CommandType.Text
        cmd.Connection = ODBCConnection
        ODBCConnection.Open()
        cmd.ExecuteNonQuery()
        ODBCConnection.Close()
    End Sub

    Private Sub RunningTotalsbtn_Click(sender As Object, e As EventArgs) Handles RunningTotalsbtn.Click
        GetRT()
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
    Private Sub LagArtMutFilAzureOLD()
        Dim PStr As [String] = ""
        Dim StartUpd As Boolean = False
        Dim StartDel As Boolean = False

        'Azure connection and Command 
        Dim Selectcmd As New SqlCommand
        Dim CheckForUpdatescmd As New SqlCommand
        Dim AZUREConnection As New SqlConnection("Server=tcp:fuelpos-server.database.windows.net,1433;Database=fuelpos-db;User ID=seiler_6@fuelpos-server;Password=Draugen2011;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
        Dim ArtReader As SqlDataReader

        'Er det endrede priser?
        Dim PriceChange As Boolean
        CheckForUpdatescmd.CommandType = CommandType.Text
        CheckForUpdatescmd.Connection = AZUREConnection
        CheckForUpdatescmd.CommandText = "SELECT * from Kunderegions where ID=1"
        AZUREConnection.Open()
        ArtReader = CheckForUpdatescmd.ExecuteReader()
        If ArtReader.HasRows Then
            PriceChange = True
        End If
        'UPDATE Kunderegions set Navn=Oslo where ID=1
        ArtReader.Close()
        AZUREConnection.Close()
        If PriceChange Then
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
            PriceChange = False
        End If 'PriceChange
    End Sub

    Private Sub LagArtMutFilAzure()
        Dim PStr As [String] = ""
        'Azure connection and Command 
        Dim Selectcmd As New SqlCommand
        Dim updatecmd As New SqlCommand
        Dim CheckForUpdatescmd As New SqlCommand
        Dim AZUREConnection As New SqlConnection("Server=tcp:tankstatus.database.windows.net,1433;Database=TankStatus_db;User ID=Stavanger@tankstatus;Password=St@vanger2015;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;")
        Dim ArtReader As SqlDataReader

        'Er det endrede priser?
        Dim PriceChange As Boolean
        updatecmd.CommandType = CommandType.Text
        updatecmd.Connection = AZUREConnection
        CheckForUpdatescmd.CommandType = CommandType.Text
        CheckForUpdatescmd.Connection = AZUREConnection
        CheckForUpdatescmd.CommandText = "SELECT * from TankVolums where Prisoppdatert=0 and NyPris>0.0 and NyPris<>AktPris"
        Try
            AZUREConnection.Open()
            ArtReader = CheckForUpdatescmd.ExecuteReader()
            If ArtReader.HasRows Then
                PriceChange = True
            End If
            ArtReader.Close()
        Catch ex As Exception
            Console.WriteLine("Databaseread failed!")
            ListBox1.Items.Add(DateAndTime.Now + " Databaseread failed!")
            PriceChange = False
        End Try

        If PriceChange Then
            Selectcmd.CommandType = CommandType.Text
            Selectcmd.Connection = AZUREConnection
            Selectcmd.CommandText = "SELECT Produktnr, NyPris from Produkts join TankVolums on ProduktID=Tanknummer where Prisoppdatert=0 and NyPris>0.0 and NyPris<>AktPris"
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
                    PStr = ArtReader.Item("Produktnr")
                    'Tags to MUT-file
                    'Immediate price change
                    sw.WriteLine("PRI_ACT_TP" & PStr & "=1")
                    sw.WriteLine("PRI" + PStr + "=" & FDec(ArtReader.Item("NyPris")))
                Loop
                ArtReader.Close()
                sw.WriteLine("[END_FUEL_UPDATE]")
                sw.WriteLine("[END_FILE]")
            End Using
            AZUREConnection.Close()
            FtpPutArtFiles()
            'If success....
            AZUREConnection.Open()
            'Skriv endringsloggen
            updatecmd.CommandText = "insert into Prisloggs (Stasjonsnr, Produktnr, Dato, NyPris) select '2052', Produktnr, getdate(), NyPris from Produkts join TankVolums on ProduktID=Tanknummer where Prisoppdatert=0 and NyPris>0.0 and NyPris<>AktPris"
            updatecmd.ExecuteNonQuery()
            'Setter oppdatertflagget=1
            updatecmd.CommandText = "UPDATE TankVolums set PrisOppdatert=1"
            updatecmd.ExecuteNonQuery()
            'Setter AktPris=Nypris
            updatecmd.CommandText = "UPDATE TankVolums set AktPris= NyPris where NyPris>0.0 and NyPris<>AktPris"
            updatecmd.ExecuteNonQuery()
            PriceChange = False
        End If 'PriceChange
    End Sub

    Private Sub btnArtMut_Click(sender As Object, e As EventArgs) Handles btnArtMut.Click
        LagArtMutFilAzure()
    End Sub

    Private Sub DayReportbtn_Click(sender As Object, e As EventArgs) Handles DayReportbtn.Click
        'Testversjon med fast filnavn 
        'GetDayReport()
        'UpdateDayReportAzure()
        RTFile = True
        ZeroRT()
        GetCTF() 'Trenger ikke denne for å lese filene på nytt  fra lokal disk Get files from FTP-server/VPN
        MoveDayRPTFiles() 'Import to local database and Azure
    End Sub




    Private Sub DayTimer_Tick(sender As Object, e As EventArgs) Handles DayTimer.Tick
        Timer1.Enabled = False
        DayTimer.Enabled = False

        'Tankstatus
        GetRT()

        'Dayreport
        RTFile = True
        ZeroRT()
        GetCTF() 'Trenger ikke denne for å lese filene på nytt  fra lokal disk Get files from FTP-server/VPN
        MoveDayRPTFiles() 'Import to local database and Azure

        'CTF
        GetCTF()
        MoveFiles()

        DayTimer.Enabled = True
        Timer1.Enabled = True
    End Sub

    Private Sub DayTimerBtn_Click(sender As Object, e As EventArgs) Handles DayTimerBtn.Click
        DayTimer.Interval = CInt(DayInterval.Text)
        DayTimer.Enabled = True

    End Sub
End Class
