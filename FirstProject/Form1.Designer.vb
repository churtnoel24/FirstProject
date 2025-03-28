<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        PrintButton = New Button()
        lblVoucher = New Label()
        lblDuration = New Label()
        lblRoomNumber = New Label()
        Label1 = New Label()
        TxtComment = New TextBox()
        Timer1 = New Timer(components)
        LblDate = New Label()
        LblVouch = New Label()
        PrintDocument1 = New Printing.PrintDocument()
        DDRooms = New ComboBox()
        SuspendLayout()
        ' 
        ' PrintButton
        ' 
        PrintButton.Location = New Point(191, 338)
        PrintButton.Name = "PrintButton"
        PrintButton.Size = New Size(232, 119)
        PrintButton.TabIndex = 0
        PrintButton.Text = "Print"
        PrintButton.UseVisualStyleBackColor = True
        ' 
        ' lblVoucher
        ' 
        lblVoucher.AutoSize = True
        lblVoucher.Location = New Point(162, 66)
        lblVoucher.Name = "lblVoucher"
        lblVoucher.Size = New Size(101, 20)
        lblVoucher.TabIndex = 4
        lblVoucher.Text = "Voucher Code"
        ' 
        ' lblDuration
        ' 
        lblDuration.AutoSize = True
        lblDuration.Location = New Point(162, 127)
        lblDuration.Name = "lblDuration"
        lblDuration.Size = New Size(41, 20)
        lblDuration.TabIndex = 5
        lblDuration.Text = "Date"
        ' 
        ' lblRoomNumber
        ' 
        lblRoomNumber.AutoSize = True
        lblRoomNumber.Location = New Point(162, 196)
        lblRoomNumber.Name = "lblRoomNumber"
        lblRoomNumber.Size = New Size(107, 20)
        lblRoomNumber.TabIndex = 6
        lblRoomNumber.Text = "Room Number"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(162, 269)
        Label1.Name = "Label1"
        Label1.Size = New Size(74, 20)
        Label1.TabIndex = 8
        Label1.Text = "Comment"
        ' 
        ' TxtComment
        ' 
        TxtComment.Location = New Point(283, 269)
        TxtComment.Name = "TxtComment"
        TxtComment.Size = New Size(125, 27)
        TxtComment.TabIndex = 7
        ' 
        ' Timer1
        ' 
        ' 
        ' LblDate
        ' 
        LblDate.AutoSize = True
        LblDate.Location = New Point(283, 127)
        LblDate.Name = "LblDate"
        LblDate.Size = New Size(53, 20)
        LblDate.TabIndex = 9
        LblDate.Text = "Label2"
        ' 
        ' LblVouch
        ' 
        LblVouch.AutoSize = True
        LblVouch.Location = New Point(283, 66)
        LblVouch.Name = "LblVouch"
        LblVouch.Size = New Size(46, 20)
        LblVouch.TabIndex = 10
        LblVouch.Text = "COde"
        ' 
        ' PrintDocument1
        ' 
        ' 
        ' DDRooms
        ' 
        DDRooms.FormattingEnabled = True
        DDRooms.Location = New Point(283, 188)
        DDRooms.Name = "DDRooms"
        DDRooms.Size = New Size(151, 28)
        DDRooms.TabIndex = 11
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(617, 500)
        Controls.Add(DDRooms)
        Controls.Add(LblVouch)
        Controls.Add(LblDate)
        Controls.Add(Label1)
        Controls.Add(TxtComment)
        Controls.Add(lblRoomNumber)
        Controls.Add(lblDuration)
        Controls.Add(lblVoucher)
        Controls.Add(PrintButton)
        Name = "Form1"
        Text = "PfSense Hotspot"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PrintButton As Button
    Friend WithEvents lblVoucher As Label
    Friend WithEvents lblDuration As Label
    Friend WithEvents lblRoomNumber As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtComment As TextBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LblDate As Label
    Friend WithEvents LblVouch As Label
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents DDRooms As ComboBox

End Class
