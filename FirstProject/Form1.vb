Imports System.Drawing.Printing
Imports System.IO
Imports MySql.Data.MySqlClient

Public Class Form1
    Private connectionString As String = "server=localhost;user=root;password=Churtnoel1224lj!;database=voucher_db;"
    Private voucherList As New List(Of String)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MessageBox.Show("Welcome to Coco")
        LoadVouchersFromCSV("D:\Desktop\Churt FILES\OJT\Fuso Files\mySQL\vouchers.csv") ' Change this to your actual CSV path
        Timer1.Start()
        LoadRoomsFromDatabase()

        Dim stVoucherCode As String = voucherList(0)

        'Show the current voucher code in Form
        LblVouch.Text = stVoucherCode
    End Sub

    Private Sub LoadVouchersFromCSV(filePath As String)
        Try
            If File.Exists(filePath) Then
                Dim lines As String() = File.ReadAllLines(filePath)
                voucherList.AddRange(lines) ' Store vouchers in a list
                MessageBox.Show($"Loaded {voucherList.Count} vouchers.")
            Else
                MessageBox.Show("CSV file not found!")
            End If
        Catch ex As Exception
            MessageBox.Show("Error reading CSV: " & ex.Message)
        End Try
    End Sub

    Private Sub PrintButton_Click(sender As Object, e As EventArgs) Handles PrintButton.Click
        If voucherList.Count = 0 Then
            MessageBox.Show("No vouchers available!")
            Return
        End If

        If DDRooms.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a room!")
            Return
        End If

        Dim stVoucherCode As String = voucherList(0) ' Take the first voucher from the list
        Dim stDate As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ' Auto-generated date
        Dim iRoomNumber As Integer = Integer.Parse(DDRooms.SelectedItem.ToString())
        Dim stComment As String = TxtComment.Text

        ' Get room_id from dictionary
        Dim roomDictionary As Dictionary(Of String, Integer) = CType(DDRooms.Tag, Dictionary(Of String, Integer))
        Dim iRoomId As Integer = roomDictionary(iRoomNumber)

        ' Save to MySQL
        SaveToDatabase(stVoucherCode, stDate, iRoomId, stComment)

        ' Print only the voucher code
        MessageBox.Show($"Printing Voucher Code: {stVoucherCode}")
        PrintDocument1.Print()

        ' Remove the used voucher from the list
        voucherList.RemoveAt(0)

        ' Update CSV file to remove the printed voucher
        UpdateCSV("D:\Desktop\Churt FILES\OJT\Fuso Files\mySQL\vouchers.csv")

        ' Update the label with the next voucher (if available)
        If voucherList.Count > 0 Then
            LblVouch.Text = voucherList(0) ' Show next voucher
        Else
            LblVouch.Text = "No more vouchers"
        End If
    End Sub

    Private Sub SaveToDatabase(voucher As String, dateIssued As String, roomId As Integer, comment As String)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "INSERT INTO vouchers (voucher_code, date_issued, room_id, comment) VALUES (@voucher, @dateIssued, @room, @comment)"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@voucher", voucher)
                    cmd.Parameters.AddWithValue("@dateIssued", dateIssued)
                    cmd.Parameters.AddWithValue("@room", roomId)
                    cmd.Parameters.AddWithValue("@comment", comment)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Data saved successfully!")
        Catch ex As Exception
            MessageBox.Show("Database Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LblDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") ' Update time every second
    End Sub

    Private Sub UpdateCSV(filePath As String)
        Try
            File.WriteAllLines(filePath, voucherList) ' Rewrite CSV with updated vouchers
        Catch ex As Exception
            MessageBox.Show("Error updating CSV: " & ex.Message)
        End Try
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font As New Font("Arial", 12, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)
        Dim startX As Integer = 10
        Dim startY As Integer = 10
        Dim lineHeight As Integer = 30

        ' Print Header
        e.Graphics.DrawString("Voucher Code", font, brush, startX, startY)
        startY += lineHeight

        ' Print Voucher Code
        e.Graphics.DrawString(LblVouch.Text, font, brush, startX, startY)
        startY += lineHeight

        ' Print Timestamp
        e.Graphics.DrawString("Printed on: " & DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), font, brush, startX, startY)
    End Sub

    Private Sub LoadRoomsFromDatabase()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "SELECT room_id, room_number FROM rooms"
                Using cmd As New MySqlCommand(query, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        DDRooms.Items.Clear()
                        Dim roomDictionary As New Dictionary(Of String, Integer) ' Store room name → ID
                        While reader.Read()
                            Dim roomNumber As String = reader("room_number").ToString()
                            Dim roomId As Integer = reader("room_id")
                            roomDictionary.Add(roomNumber, roomId)
                            DDRooms.Items.Add(roomNumber) ' Show room number in dropdown
                        End While
                        DDRooms.Tag = roomDictionary ' Store dictionary for later use
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading rooms: " & ex.Message)
        End Try
    End Sub




End Class
