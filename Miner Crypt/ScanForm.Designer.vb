<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ScanForm
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
        Me.FormSkin1 = New Miner_Crypt.FormSkin()
        Me.urltext = New Miner_Crypt.FlatTextBox()
        Me.resulttext = New Miner_Crypt.FlatTextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.AV = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Result = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.FlatClose1 = New Miner_Crypt.FlatClose()
        Me.FormSkin1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FormSkin1
        '
        Me.FormSkin1.BackColor = System.Drawing.Color.White
        Me.FormSkin1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.FormSkin1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.FormSkin1.Controls.Add(Me.urltext)
        Me.FormSkin1.Controls.Add(Me.resulttext)
        Me.FormSkin1.Controls.Add(Me.ListView1)
        Me.FormSkin1.Controls.Add(Me.FlatClose1)
        Me.FormSkin1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FormSkin1.FlatColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.FormSkin1.Font = New System.Drawing.Font("Segoe WP SemiLight", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel)
        Me.FormSkin1.HeaderColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.FormSkin1.HeaderMaximize = False
        Me.FormSkin1.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.FormSkin1.Location = New System.Drawing.Point(0, 0)
        Me.FormSkin1.Name = "FormSkin1"
        Me.FormSkin1.Size = New System.Drawing.Size(329, 380)
        Me.FormSkin1.TabIndex = 0
        Me.FormSkin1.Text = "Scanner"
        '
        'urltext
        '
        Me.urltext.BackColor = System.Drawing.Color.Transparent
        Me.urltext.Location = New System.Drawing.Point(84, 348)
        Me.urltext.MaxLength = 32767
        Me.urltext.Multiline = False
        Me.urltext.Name = "urltext"
        Me.urltext.ReadOnly = False
        Me.urltext.Size = New System.Drawing.Size(241, 29)
        Me.urltext.TabIndex = 3
        Me.urltext.Text = "http://hackforums.net/"
        Me.urltext.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.urltext.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.urltext.UseSystemPasswordChar = False
        '
        'resulttext
        '
        Me.resulttext.BackColor = System.Drawing.Color.Transparent
        Me.resulttext.Location = New System.Drawing.Point(3, 348)
        Me.resulttext.MaxLength = 32767
        Me.resulttext.Multiline = False
        Me.resulttext.Name = "resulttext"
        Me.resulttext.ReadOnly = False
        Me.resulttext.Size = New System.Drawing.Size(75, 29)
        Me.resulttext.TabIndex = 2
        Me.resulttext.Text = "-/35"
        Me.resulttext.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.resulttext.TextColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.resulttext.UseSystemPasswordChar = False
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.AV, Me.Result})
        Me.ListView1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.Location = New System.Drawing.Point(3, 30)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(322, 312)
        Me.ListView1.TabIndex = 1
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'AV
        '
        Me.AV.Text = "AV"
        Me.AV.Width = 136
        '
        'Result
        '
        Me.Result.Text = "Result"
        Me.Result.Width = 182
        '
        'FlatClose1
        '
        Me.FlatClose1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FlatClose1.BackColor = System.Drawing.Color.White
        Me.FlatClose1.BaseColor = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.FlatClose1.Font = New System.Drawing.Font("Marlett", 12.0!)
        Me.FlatClose1.Location = New System.Drawing.Point(307, 6)
        Me.FlatClose1.Name = "FlatClose1"
        Me.FlatClose1.Size = New System.Drawing.Size(18, 18)
        Me.FlatClose1.TabIndex = 0
        Me.FlatClose1.Text = "FlatClose1"
        Me.FlatClose1.TextColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(220, Byte), Integer))
        '
        'ScanForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(329, 380)
        Me.Controls.Add(Me.FormSkin1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ScanForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ScanForm"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.FormSkin1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FormSkin1 As Miner_Crypt.FormSkin
    Friend WithEvents FlatClose1 As Miner_Crypt.FlatClose
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents AV As System.Windows.Forms.ColumnHeader
    Friend WithEvents Result As System.Windows.Forms.ColumnHeader
    Friend WithEvents urltext As Miner_Crypt.FlatTextBox
    Friend WithEvents resulttext As Miner_Crypt.FlatTextBox
End Class
