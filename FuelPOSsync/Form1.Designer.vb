<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.DayTimerBtn = New System.Windows.Forms.Button()
        Me.DayInterval = New System.Windows.Forms.TextBox()
        Me.StationStatusDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn43 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn44 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn45 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn46 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn47 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StationStatusBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet1 = New FuelPOSsync.DataSet1()
        Me.DayReportFileName = New System.Windows.Forms.TextBox()
        Me.DayReportbtn = New System.Windows.Forms.Button()
        Me.btnArtMut = New System.Windows.Forms.Button()
        Me.RunningTotalsbtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TimerDelay = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LastRunTime = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DayReportRawDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn37 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn38 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn39 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn40 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn41 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn42 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DayReportRawBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.FP_TransBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FP_ItemsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TransImpsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me._fuelpos_dbDataSet = New FuelPOSsync._fuelpos_dbDataSet()
        Me.ItemImpsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TransImpsTableAdapter = New FuelPOSsync._fuelpos_dbDataSetTableAdapters.TransImpsTableAdapter()
        Me.TableAdapterManager1 = New FuelPOSsync._fuelpos_dbDataSetTableAdapters.TableAdapterManager()
        Me.ItemImpsTableAdapter = New FuelPOSsync._fuelpos_dbDataSetTableAdapters.ItemImpsTableAdapter()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImpTransBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ItemTableBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FuelImp1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.FP_TransTableAdapter = New FuelPOSsync.DataSet1TableAdapters.FP_TransTableAdapter()
        Me.TableAdapterManager = New FuelPOSsync.DataSet1TableAdapters.TableAdapterManager()
        Me.FP_ItemsTableAdapter = New FuelPOSsync.DataSet1TableAdapters.FP_ItemsTableAdapter()
        Me.FuelImp1TableAdapter = New FuelPOSsync.DataSet1TableAdapters.FuelImp1TableAdapter()
        Me.ImpTransTableAdapter = New FuelPOSsync.DataSet1TableAdapters.ImpTransTableAdapter()
        Me.ItemTableTableAdapter = New FuelPOSsync.DataSet1TableAdapters.ItemTableTableAdapter()
        Me.DayReportRawTableAdapter = New FuelPOSsync.DataSet1TableAdapters.DayReportRawTableAdapter()
        Me.StationStatusTableAdapter = New FuelPOSsync.DataSet1TableAdapters.StationStatusTableAdapter()
        Me.DayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.StationStatusDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.StationStatusBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DayReportRawDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DayReportRawBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.FP_TransBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FP_ItemsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransImpsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._fuelpos_dbDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemImpsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImpTransBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemTableBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FuelImp1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.HorizontalScrollbar = True
        Me.ListBox1.Location = New System.Drawing.Point(304, 72)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(212, 121)
        Me.ListBox1.TabIndex = 11
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(269, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(81, 35)
        Me.Button2.TabIndex = 12
        Me.Button2.Text = "Importer"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.DayTimerBtn)
        Me.Panel1.Controls.Add(Me.DayInterval)
        Me.Panel1.Controls.Add(Me.StationStatusDataGridView)
        Me.Panel1.Controls.Add(Me.DayReportFileName)
        Me.Panel1.Controls.Add(Me.DayReportbtn)
        Me.Panel1.Controls.Add(Me.btnArtMut)
        Me.Panel1.Controls.Add(Me.RunningTotalsbtn)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TimerDelay)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LastRunTime)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(795, 327)
        Me.Panel1.TabIndex = 7
        '
        'DayTimerBtn
        '
        Me.DayTimerBtn.Location = New System.Drawing.Point(13, 135)
        Me.DayTimerBtn.Name = "DayTimerBtn"
        Me.DayTimerBtn.Size = New System.Drawing.Size(75, 23)
        Me.DayTimerBtn.TabIndex = 26
        Me.DayTimerBtn.Text = "DayTimer"
        Me.DayTimerBtn.UseVisualStyleBackColor = True
        '
        'DayInterval
        '
        Me.DayInterval.Location = New System.Drawing.Point(99, 138)
        Me.DayInterval.Name = "DayInterval"
        Me.DayInterval.Size = New System.Drawing.Size(134, 20)
        Me.DayInterval.TabIndex = 25
        '
        'StationStatusDataGridView
        '
        Me.StationStatusDataGridView.AutoGenerateColumns = False
        Me.StationStatusDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.StationStatusDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn43, Me.DataGridViewTextBoxColumn44, Me.DataGridViewTextBoxColumn45, Me.DataGridViewTextBoxColumn46, Me.DataGridViewTextBoxColumn47})
        Me.StationStatusDataGridView.DataSource = Me.StationStatusBindingSource
        Me.StationStatusDataGridView.Location = New System.Drawing.Point(13, 199)
        Me.StationStatusDataGridView.Name = "StationStatusDataGridView"
        Me.StationStatusDataGridView.Size = New System.Drawing.Size(560, 108)
        Me.StationStatusDataGridView.TabIndex = 24
        '
        'DataGridViewTextBoxColumn43
        '
        Me.DataGridViewTextBoxColumn43.DataPropertyName = "Station_Nr"
        Me.DataGridViewTextBoxColumn43.HeaderText = "Station_Nr"
        Me.DataGridViewTextBoxColumn43.Name = "DataGridViewTextBoxColumn43"
        '
        'DataGridViewTextBoxColumn44
        '
        Me.DataGridViewTextBoxColumn44.DataPropertyName = "LastTransFileNr"
        Me.DataGridViewTextBoxColumn44.HeaderText = "LastTransFileNr"
        Me.DataGridViewTextBoxColumn44.Name = "DataGridViewTextBoxColumn44"
        '
        'DataGridViewTextBoxColumn45
        '
        Me.DataGridViewTextBoxColumn45.DataPropertyName = "LastCustMut"
        Me.DataGridViewTextBoxColumn45.HeaderText = "LastCustMut"
        Me.DataGridViewTextBoxColumn45.Name = "DataGridViewTextBoxColumn45"
        '
        'DataGridViewTextBoxColumn46
        '
        Me.DataGridViewTextBoxColumn46.DataPropertyName = "LastArtMut"
        Me.DataGridViewTextBoxColumn46.HeaderText = "LastArtMut"
        Me.DataGridViewTextBoxColumn46.Name = "DataGridViewTextBoxColumn46"
        '
        'DataGridViewTextBoxColumn47
        '
        Me.DataGridViewTextBoxColumn47.DataPropertyName = "LastDayRPTFileNr"
        Me.DataGridViewTextBoxColumn47.HeaderText = "LastDayRPTFileNr"
        Me.DataGridViewTextBoxColumn47.Name = "DataGridViewTextBoxColumn47"
        '
        'StationStatusBindingSource
        '
        Me.StationStatusBindingSource.DataMember = "StationStatus"
        Me.StationStatusBindingSource.DataSource = Me.DataSet1
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DayReportFileName
        '
        Me.DayReportFileName.Location = New System.Drawing.Point(304, 46)
        Me.DayReportFileName.Name = "DayReportFileName"
        Me.DayReportFileName.Size = New System.Drawing.Size(212, 20)
        Me.DayReportFileName.TabIndex = 24
        Me.DayReportFileName.Text = "C:\Users\Prince\Desktop\20520169.p"
        '
        'DayReportbtn
        '
        Me.DayReportbtn.Location = New System.Drawing.Point(441, 12)
        Me.DayReportbtn.Name = "DayReportbtn"
        Me.DayReportbtn.Size = New System.Drawing.Size(75, 35)
        Me.DayReportbtn.TabIndex = 23
        Me.DayReportbtn.Text = "DayReport"
        Me.DayReportbtn.UseVisualStyleBackColor = True
        '
        'btnArtMut
        '
        Me.btnArtMut.Location = New System.Drawing.Point(177, 13)
        Me.btnArtMut.Name = "btnArtMut"
        Me.btnArtMut.Size = New System.Drawing.Size(75, 34)
        Me.btnArtMut.TabIndex = 22
        Me.btnArtMut.Text = "SendArtMut"
        Me.btnArtMut.UseVisualStyleBackColor = True
        '
        'RunningTotalsbtn
        '
        Me.RunningTotalsbtn.Location = New System.Drawing.Point(356, 12)
        Me.RunningTotalsbtn.Name = "RunningTotalsbtn"
        Me.RunningTotalsbtn.Size = New System.Drawing.Size(79, 35)
        Me.RunningTotalsbtn.TabIndex = 20
        Me.RunningTotalsbtn.Text = "RunningTotal"
        Me.RunningTotalsbtn.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(223, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "ms"
        '
        'TimerDelay
        '
        Me.TimerDelay.Location = New System.Drawing.Point(99, 62)
        Me.TimerDelay.Name = "TimerDelay"
        Me.TimerDelay.Size = New System.Drawing.Size(118, 20)
        Me.TimerDelay.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(96, 86)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Last run"
        '
        'LastRunTime
        '
        Me.LastRunTime.Location = New System.Drawing.Point(99, 99)
        Me.LastRunTime.Name = "LastRunTime"
        Me.LastRunTime.Size = New System.Drawing.Size(134, 20)
        Me.LastRunTime.TabIndex = 15
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 62)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(81, 57)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Start timer"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DayReportRawDataGridView
        '
        Me.DayReportRawDataGridView.AutoGenerateColumns = False
        Me.DayReportRawDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DayReportRawDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn37, Me.DataGridViewTextBoxColumn38, Me.DataGridViewTextBoxColumn39, Me.DataGridViewTextBoxColumn40, Me.DataGridViewTextBoxColumn41, Me.DataGridViewTextBoxColumn42})
        Me.DayReportRawDataGridView.DataSource = Me.DayReportRawBindingSource
        Me.DayReportRawDataGridView.Location = New System.Drawing.Point(0, 28)
        Me.DayReportRawDataGridView.Name = "DayReportRawDataGridView"
        Me.DayReportRawDataGridView.Size = New System.Drawing.Size(772, 295)
        Me.DayReportRawDataGridView.TabIndex = 19
        '
        'DataGridViewTextBoxColumn37
        '
        Me.DataGridViewTextBoxColumn37.DataPropertyName = "ID"
        Me.DataGridViewTextBoxColumn37.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn37.Name = "DataGridViewTextBoxColumn37"
        Me.DataGridViewTextBoxColumn37.ReadOnly = True
        '
        'DataGridViewTextBoxColumn38
        '
        Me.DataGridViewTextBoxColumn38.DataPropertyName = "Section"
        Me.DataGridViewTextBoxColumn38.HeaderText = "Section"
        Me.DataGridViewTextBoxColumn38.Name = "DataGridViewTextBoxColumn38"
        '
        'DataGridViewTextBoxColumn39
        '
        Me.DataGridViewTextBoxColumn39.DataPropertyName = "ItemName"
        Me.DataGridViewTextBoxColumn39.HeaderText = "ItemName"
        Me.DataGridViewTextBoxColumn39.Name = "DataGridViewTextBoxColumn39"
        '
        'DataGridViewTextBoxColumn40
        '
        Me.DataGridViewTextBoxColumn40.DataPropertyName = "ItemNo"
        Me.DataGridViewTextBoxColumn40.HeaderText = "ItemNo"
        Me.DataGridViewTextBoxColumn40.Name = "DataGridViewTextBoxColumn40"
        '
        'DataGridViewTextBoxColumn41
        '
        Me.DataGridViewTextBoxColumn41.DataPropertyName = "ItemIndex"
        Me.DataGridViewTextBoxColumn41.HeaderText = "ItemIndex"
        Me.DataGridViewTextBoxColumn41.Name = "DataGridViewTextBoxColumn41"
        '
        'DataGridViewTextBoxColumn42
        '
        Me.DataGridViewTextBoxColumn42.DataPropertyName = "RptValue"
        Me.DataGridViewTextBoxColumn42.HeaderText = "RptValue"
        Me.DataGridViewTextBoxColumn42.Name = "DataGridViewTextBoxColumn42"
        '
        'DayReportRawBindingSource
        '
        Me.DayReportRawBindingSource.DataMember = "DayReportRaw"
        Me.DayReportRawBindingSource.DataSource = Me.DataSet1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.DayReportRawDataGridView)
        Me.Panel2.Location = New System.Drawing.Point(0, 333)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(795, 354)
        Me.Panel2.TabIndex = 8
        '
        'FP_TransBindingSource
        '
        Me.FP_TransBindingSource.DataMember = "FP_Trans"
        Me.FP_TransBindingSource.DataSource = Me.DataSet1
        '
        'FP_ItemsBindingSource
        '
        Me.FP_ItemsBindingSource.DataMember = "FK_FP_TRANS_FP_ITEM"
        Me.FP_ItemsBindingSource.DataSource = Me.FP_TransBindingSource
        '
        'TransImpsBindingSource
        '
        Me.TransImpsBindingSource.DataMember = "TransImps"
        Me.TransImpsBindingSource.DataSource = Me._fuelpos_dbDataSet
        '
        '_fuelpos_dbDataSet
        '
        Me._fuelpos_dbDataSet.DataSetName = "_fuelpos_dbDataSet"
        Me._fuelpos_dbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ItemImpsBindingSource
        '
        Me.ItemImpsBindingSource.DataMember = "FK_dbo.ItemImps_dbo.TransImps_TransImpID"
        Me.ItemImpsBindingSource.DataSource = Me.TransImpsBindingSource
        '
        'TransImpsTableAdapter
        '
        Me.TransImpsTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.ItemImpsTableAdapter = Me.ItemImpsTableAdapter
        Me.TableAdapterManager1.TransImpsTableAdapter = Me.TransImpsTableAdapter
        Me.TableAdapterManager1.UpdateOrder = FuelPOSsync._fuelpos_dbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'ItemImpsTableAdapter
        '
        Me.ItemImpsTableAdapter.ClearBeforeFill = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 3600000
        '
        'ImpTransBindingSource
        '
        Me.ImpTransBindingSource.DataMember = "ImpTrans"
        Me.ImpTransBindingSource.DataSource = Me.DataSet1
        '
        'ItemTableBindingSource
        '
        Me.ItemTableBindingSource.DataMember = "ItemTable"
        Me.ItemTableBindingSource.DataSource = Me.DataSet1
        '
        'FuelImp1BindingSource
        '
        Me.FuelImp1BindingSource.DataMember = "FuelImp1"
        Me.FuelImp1BindingSource.DataSource = Me.DataSet1
        '
        'FP_TransTableAdapter
        '
        Me.FP_TransTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.CUST_IDTableAdapter = Nothing
        Me.TableAdapterManager.DayReportRawTableAdapter = Nothing
        Me.TableAdapterManager.FP_ItemsTableAdapter = Me.FP_ItemsTableAdapter
        Me.TableAdapterManager.FP_TRANS_RAPPTableAdapter = Nothing
        Me.TableAdapterManager.FP_TransTableAdapter = Me.FP_TransTableAdapter
        Me.TableAdapterManager.FuelImp1TableAdapter = Me.FuelImp1TableAdapter
        Me.TableAdapterManager.ImpTransTableAdapter = Me.ImpTransTableAdapter
        Me.TableAdapterManager.InnlimingsfeilTableAdapter = Nothing
        Me.TableAdapterManager.ItemTableTableAdapter = Me.ItemTableTableAdapter
        Me.TableAdapterManager.LOC_CUSTTableAdapter = Nothing
        Me.TableAdapterManager.LTYPTableAdapter = Nothing
        Me.TableAdapterManager.RappConfigTableAdapter = Nothing
        Me.TableAdapterManager.RBALTableAdapter = Nothing
        Me.TableAdapterManager.ShopArtTableAdapter = Nothing
        Me.TableAdapterManager.StationStatusTableAdapter = Nothing
        Me.TableAdapterManager.StationTableAdapter = Nothing
        Me.TableAdapterManager.TransTableTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = FuelPOSsync.DataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.VATCTableAdapter = Nothing
        '
        'FP_ItemsTableAdapter
        '
        Me.FP_ItemsTableAdapter.ClearBeforeFill = True
        '
        'FuelImp1TableAdapter
        '
        Me.FuelImp1TableAdapter.ClearBeforeFill = True
        '
        'ImpTransTableAdapter
        '
        Me.ImpTransTableAdapter.ClearBeforeFill = True
        '
        'ItemTableTableAdapter
        '
        Me.ItemTableTableAdapter.ClearBeforeFill = True
        '
        'DayReportRawTableAdapter
        '
        Me.DayReportRawTableAdapter.ClearBeforeFill = True
        '
        'StationStatusTableAdapter
        '
        Me.StationStatusTableAdapter.ClearBeforeFill = True
        '
        'DayTimer
        '
        Me.DayTimer.Interval = 86400000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(795, 741)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.StationStatusDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.StationStatusBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DayReportRawDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DayReportRawBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.FP_TransBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FP_ItemsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransImpsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._fuelpos_dbDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemImpsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImpTransBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemTableBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FuelImp1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DataSet1 As FuelPOSsync.DataSet1
    Friend WithEvents FP_TransBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FP_TransTableAdapter As FuelPOSsync.DataSet1TableAdapters.FP_TransTableAdapter
    Friend WithEvents TableAdapterManager As FuelPOSsync.DataSet1TableAdapters.TableAdapterManager
    Friend WithEvents FP_ItemsTableAdapter As FuelPOSsync.DataSet1TableAdapters.FP_ItemsTableAdapter
    Friend WithEvents FP_ItemsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents _fuelpos_dbDataSet As FuelPOSsync._fuelpos_dbDataSet
    Friend WithEvents TransImpsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TransImpsTableAdapter As FuelPOSsync._fuelpos_dbDataSetTableAdapters.TransImpsTableAdapter
    Friend WithEvents TableAdapterManager1 As FuelPOSsync._fuelpos_dbDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ItemImpsTableAdapter As FuelPOSsync._fuelpos_dbDataSetTableAdapters.ItemImpsTableAdapter
    Friend WithEvents ItemImpsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FuelImp1TableAdapter As FuelPOSsync.DataSet1TableAdapters.FuelImp1TableAdapter
    Friend WithEvents FuelImp1BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ItemTableTableAdapter As FuelPOSsync.DataSet1TableAdapters.ItemTableTableAdapter
    Friend WithEvents ItemTableBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ImpTransTableAdapter As FuelPOSsync.DataSet1TableAdapters.ImpTransTableAdapter
    Friend WithEvents ImpTransBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LastRunTime As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TimerDelay As System.Windows.Forms.TextBox
    Friend WithEvents DayReportRawBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DayReportRawTableAdapter As FuelPOSsync.DataSet1TableAdapters.DayReportRawTableAdapter
    Friend WithEvents DayReportRawDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn37 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn38 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn39 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn40 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn41 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn42 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RunningTotalsbtn As System.Windows.Forms.Button
    Friend WithEvents btnArtMut As System.Windows.Forms.Button
    Friend WithEvents DayReportbtn As System.Windows.Forms.Button
    Friend WithEvents DayReportFileName As System.Windows.Forms.TextBox
    Friend WithEvents StationStatusBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StationStatusTableAdapter As FuelPOSsync.DataSet1TableAdapters.StationStatusTableAdapter
    Friend WithEvents StationStatusDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn43 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn44 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn45 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn46 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn47 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DayTimer As System.Windows.Forms.Timer
    Friend WithEvents DayTimerBtn As System.Windows.Forms.Button
    Friend WithEvents DayInterval As System.Windows.Forms.TextBox

End Class
