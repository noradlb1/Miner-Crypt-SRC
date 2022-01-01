﻿' Credit to iSynthesis
' Edited by Huracan

' DARK FLAT UI

Imports System.Drawing.Drawing2D, System.ComponentModel, System.Windows.Forms
Imports System.Runtime.InteropServices

''' <summary>
''' Flat UI Theme
''' Creator: iSynthesis (HF)
''' Version: 1.0.3
''' Date Created: 17/06/2013
''' Date Changed: 20/06/2013
''' UID: 374648
''' For any bugs / errors, PM me.
''' </summary>
''' <remarks></remarks>

Module Helpers

#Region " Variables"
    Friend G As Graphics, B As Bitmap
    Friend _FlatColor As Color = Color.FromArgb(35, 168, 109)
    Friend NearSF As New StringFormat() With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Near}
    Friend CenterSF As New StringFormat() With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center}
#End Region

#Region " Functions"

    Public Function RoundRec(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function

    Public Function RoundRect(x!, y!, w!, h!, Optional r! = 0.3, Optional TL As Boolean = True, Optional TR As Boolean = True, Optional BR As Boolean = True, Optional BL As Boolean = True) As GraphicsPath
        Dim d! = Math.Min(w, h) * r, xw = x + w, yh = y + h
        RoundRect = New GraphicsPath

        With RoundRect
            If TL Then .AddArc(x, y, d, d, 180, 90) Else .AddLine(x, y, x, y)
            If TR Then .AddArc(xw - d, y, d, d, 270, 90) Else .AddLine(xw, y, xw, y)
            If BR Then .AddArc(xw - d, yh - d, d, d, 0, 90) Else .AddLine(xw, yh, xw, yh)
            If BL Then .AddArc(x, yh - d, d, d, 90, 90) Else .AddLine(x, yh, x, yh)

            .CloseFigure()
        End With
    End Function

    '-- Credit: AeonHack
    Public Function DrawArrow(x As Integer, y As Integer, flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()

        Dim W As Integer = 12
        Dim H As Integer = 6

        If flip Then
            GP.AddLine(x + 1, y, x + W + 1, y)
            GP.AddLine(x + W, y, x + H, y + H - 1)
        Else
            GP.AddLine(x, y + H, x + W, y + H)
            GP.AddLine(x + W, y + H, x + H, y)
        End If

        GP.CloseFigure()
        Return GP
    End Function

#End Region

End Module

#Region " Mouse States"
Enum MouseState As Byte
    None = 0
    Over = 1
    Down = 2
    Block = 3
End Enum
#End Region

Class FormSkin : Inherits ContainerControl

#Region " Variables"

    Private W, H As Integer
    Private Cap As Boolean = False
    Private _HeaderMaximize As Boolean = False
    Private MousePoint As New Point(0, 0)
    Private MoveHeight = 50

#End Region

#Region " Properties"

#Region " Colors"

    <Category("Colors")> _
    Public Property HeaderColor() As Color
        Get
            Return _HeaderColor
        End Get
        Set(value As Color)
            _HeaderColor = value
        End Set
    End Property
    <Category("Colors")> _
    Public Property BaseColor() As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property
    <Category("Colors")> _
    Public Property BorderColor() As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value
        End Set
    End Property
    <Category("Colors")> _
    Public Property FlatColor() As Color
        Get
            Return _FlatColor
        End Get
        Set(value As Color)
            _FlatColor = value
        End Set
    End Property

#End Region

#Region " Options"

    <Category("Options")> _
    Public Property HeaderMaximize As Boolean
        Get
            Return _HeaderMaximize
        End Get
        Set(value As Boolean)
            _HeaderMaximize = value
        End Set
    End Property

#End Region

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width, MoveHeight).Contains(e.Location) Then
            Cap = True
            MousePoint = e.Location
        End If
    End Sub

    Private Sub FormSkin_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick
        If HeaderMaximize Then
            If e.Button = Windows.Forms.MouseButtons.Left And New Rectangle(0, 0, Width, MoveHeight).Contains(e.Location) Then
                If FindForm.WindowState = FormWindowState.Normal Then
                    FindForm.WindowState = FormWindowState.Maximized : FindForm.Refresh()
                ElseIf FindForm.WindowState = FormWindowState.Maximized Then
                    FindForm.WindowState = FormWindowState.Normal : FindForm.Refresh()
                End If
            End If
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e) : Cap = False
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Cap Then
            Parent.Location = MousePosition - MousePoint
        End If
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        ParentForm.FormBorderStyle = FormBorderStyle.None
        ParentForm.AllowTransparency = False
        ParentForm.TransparencyKey = Color.Fuchsia
        ParentForm.FindForm.StartPosition = FormStartPosition.CenterScreen
        Dock = DockStyle.Fill
        Invalidate()
    End Sub

#End Region

#Region " Colors"

#Region " Dark Colors"

    Private _HeaderColor As Color = Color.FromArgb(50, 50, 50)
    Private _BaseColor As Color = Color.FromArgb(50, 50, 50)
    Private _BorderColor As Color = Color.FromArgb(21, 133, 181)
    Private TextColor As Color = Color.FromArgb(255, 255, 255)

#End Region

#Region " Light Colors"

    Private _HeaderLight As Color = Color.FromArgb(171, 171, 172)
    Private _BaseLight As Color = Color.FromArgb(196, 199, 200)
    Public TextLight As Color = Color.FromArgb(45, 47, 49)

#End Region

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.White
        Font = New Font("Segoe WP Semilight", 18, FontStyle.Regular, GraphicsUnit.Pixel)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Font = New Font("Segoe WP Semilight", 18, FontStyle.Regular, GraphicsUnit.Pixel)


        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width : H = Height

        Dim Base As New Rectangle(0, 0, W, H), Header As New Rectangle(0, 0, W, 30)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            '-- Base
            .FillRectangle(New SolidBrush(_BaseColor), Base)

            '-- Header
            .FillRectangle(New SolidBrush(_HeaderColor), Header)

            '-- Logo
            '.FillRectangle(New SolidBrush(Color.FromArgb(243, 243, 243)), New Rectangle(8, 5, 4, 18))
            '.FillRectangle(New SolidBrush(Color.FromArgb(243, 243, 243)), 16, 5, 4, 18)
            .DrawString(Text, Font, New SolidBrush(TextColor), New Rectangle(5, 3, W, H), NearSF)

            '-- Border
            .DrawRectangle(New Pen(_BorderColor), Base)
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Class FlatClose : Inherits Control

#Region " Variables"

    Private State As MouseState = MouseState.None
    Private x As Integer

#End Region

#Region " Properties"

#Region " Mouse States"

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        x = e.X : Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        'Environment.Exit(0)
    End Sub

#End Region

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(18, 18)
    End Sub

#Region " Colors"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
        End Set
    End Property

#End Region

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(50, 50, 50)
    Private _TextColor As Color = Color.FromArgb(220, 220, 220)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.White
        Size = New Size(18, 18)
        Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Font = New Font("Marlett", 12)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)

        Dim Base As New Rectangle(0, 0, Width, Height)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            '-- Base
            .FillRectangle(New SolidBrush(_BaseColor), Base)

            '-- X
            .DrawString("r", Font, New SolidBrush(TextColor), New Rectangle(0, 0, Width, Height), CenterSF)

            '-- Hover/down
            Select Case State
                Case MouseState.Over
                    .FillRectangle(New SolidBrush(Color.FromArgb(30, Color.White)), Base)
                Case MouseState.Down
                    .FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Black)), Base)
            End Select
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Class FlatMax : Inherits Control

#Region " Variables"

    Private State As MouseState = MouseState.None
    Private x As Integer

#End Region

#Region " Properties"

#Region " Mouse States"

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        x = e.X : Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Select Case FindForm.WindowState
            Case FormWindowState.Maximized
                FindForm.WindowState = FormWindowState.Normal
            Case FormWindowState.Normal
                FindForm.WindowState = FormWindowState.Maximized
        End Select
    End Sub

#End Region

#Region " Colors"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
        End Set
    End Property

#End Region

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(18, 18)
    End Sub

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(50, 50, 50)
    Private _TextColor As Color = Color.FromArgb(243, 243, 243)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.White
        Size = New Size(18, 18)
        Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Font = New Font("Marlett", 12)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)

        Dim Base As New Rectangle(0, 0, Width, Height)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            '-- Base
            .FillRectangle(New SolidBrush(_BaseColor), Base)

            '-- Maximize
            If FindForm.WindowState = FormWindowState.Maximized Then
                .DrawString("1", Font, New SolidBrush(TextColor), New Rectangle(1, 1, Width, Height), CenterSF)
            ElseIf FindForm.WindowState = FormWindowState.Normal Then
                .DrawString("2", Font, New SolidBrush(TextColor), New Rectangle(1, 1, Width, Height), CenterSF)
            End If

            '-- Hover/down
            Select Case State
                Case MouseState.Over
                    .FillRectangle(New SolidBrush(Color.FromArgb(30, Color.White)), Base)
                Case MouseState.Down
                    .FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Black)), Base)
            End Select
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Class FlatMini : Inherits Control

#Region " Variables"

    Private State As MouseState = MouseState.None
    Private x As Integer

#End Region

#Region " Properties"

#Region " Mouse States"

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        x = e.X : Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Select Case FindForm.WindowState
            Case FormWindowState.Normal
                FindForm.WindowState = FormWindowState.Minimized
            Case FormWindowState.Maximized
                FindForm.WindowState = FormWindowState.Minimized
        End Select
    End Sub

#End Region

#Region " Colors"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
        End Set
    End Property

#End Region

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Size = New Size(18, 18)
    End Sub

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(50, 50, 50)
    Private _TextColor As Color = Color.FromArgb(243, 243, 243)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.White
        Size = New Size(18, 18)
        Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Font = New Font("Marlett", 12)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)

        Dim Base As New Rectangle(0, 0, Width, Height)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            '-- Base
            .FillRectangle(New SolidBrush(_BaseColor), Base)

            '-- Minimize
            .DrawString("0", Font, New SolidBrush(TextColor), New Rectangle(2, 1, Width, Height), CenterSF)

            '-- Hover/down
            Select Case State
                Case MouseState.Over
                    .FillRectangle(New SolidBrush(Color.FromArgb(30, Color.White)), Base)
                Case MouseState.Down
                    .FillRectangle(New SolidBrush(Color.FromArgb(30, Color.Black)), Base)
            End Select
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Class FlatGroupBox : Inherits ContainerControl

#Region " Variables"

    Private W, H As Integer
    Private _ShowText As Boolean = True

#End Region

#Region " Properties"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    Public Property ShowText As Boolean
        Get
            Return _ShowText
        End Get
        Set(value As Boolean)
            _ShowText = value
        End Set
    End Property

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(60, 60, 60)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Size = New Size(240, 180)
        Font = New Font("Segoe ui", 10)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim GP, GP2, GP3 As New GraphicsPath
        Dim Base As New Rectangle(8, 8, W - 16, H - 16)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            '-- Base
            GP = Helpers.RoundRec(Base, 8)
            .FillPath(New SolidBrush(_BaseColor), GP)

            '-- Arrows
            GP2 = Helpers.DrawArrow(28, 2, False)
            .FillPath(New SolidBrush(_BaseColor), GP2)
            GP3 = Helpers.DrawArrow(28, 8, True)
            .FillPath(New SolidBrush(Color.FromArgb(60, 70, 73)), GP3)

            '-- if ShowText
            If ShowText Then
                .DrawString(Text, Font, New SolidBrush(Color.FromArgb(21, 133, 181)), New Rectangle(16, 16, W, H), NearSF)
            End If
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Public Class FlatGroupBox2 : Inherits ContainerControl

#Region " Variables"

    Private W, H As Integer
    Private _ShowText As Boolean = True

#End Region

#Region " Properties"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    Public Property ShowText As Boolean
        Get
            Return _ShowText
        End Get
        Set(value As Boolean)
            _ShowText = value
        End Set
    End Property

#End Region

#Region " Colors"

    Public Shared _BaseColor As Color = Color.FromArgb(60, 70, 73)

    Public Shared _ForeColor As Color = Color.FromArgb(21, 133, 181) 'Color.FromArgb(102, 204, 255)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Size = New Size(240, 180)
        Font = New Font("Segoe ui", 10)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim GP As New GraphicsPath
        Dim GP2 As New GraphicsPath
        Dim Base As New Rectangle(8, 8, W - 16, H - 16)
        Dim Overline As New Rectangle(8, 3, W - 16, H - 20)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            '-- Base
            .FillRectangle(New SolidBrush(Color.FromArgb(21, 133, 181)), Overline)

            .FillRectangle(New SolidBrush(_BaseColor), Base)

            '-- if ShowText
            If ShowText Then
                .DrawString(Text, Font, New SolidBrush(Color.White), New Rectangle(0, 13, W, H), New StringFormat With {.LineAlignment = StringAlignment.Near, .Alignment = StringAlignment.Center})
            End If
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Class FlatButton : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private _Rounded As Boolean = False
    Private State As MouseState = MouseState.None

#End Region

#Region " Properties"

#Region " Colors"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
        End Set
    End Property

    <Category("Options")> _
    Public Property Rounded As Boolean
        Get
            Return _Rounded
        End Get
        Set(value As Boolean)
            _Rounded = value
        End Set
    End Property

#End Region

#Region " Mouse States"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(21, 133, 181)
    Private _TextColor As Color = Color.FromArgb(243, 243, 243)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(106, 32)
        BackColor = Color.Transparent
        Font = New Font("Segoe UI", 10)
        Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim GP As New GraphicsPath
        Dim Base As New Rectangle(0, 0, W, H)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            Select Case State
                Case MouseState.None
                    If Rounded Then
                        '-- Base
                        GP = Helpers.RoundRec(Base, 6)
                        .FillPath(New SolidBrush(_BaseColor), GP)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    Else
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), Base)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    End If
                Case MouseState.Over
                    If Rounded Then
                        '-- Base
                        GP = Helpers.RoundRec(Base, 6)
                        .FillPath(New SolidBrush(_BaseColor), GP)
                        .FillPath(New SolidBrush(Color.FromArgb(20, Color.White)), GP)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    Else
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), Base)
                        .FillRectangle(New SolidBrush(Color.FromArgb(20, Color.White)), Base)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    End If
                Case MouseState.Down
                    If Rounded Then
                        '-- Base
                        GP = Helpers.RoundRec(Base, 6)
                        .FillPath(New SolidBrush(_BaseColor), GP)
                        .FillPath(New SolidBrush(Color.FromArgb(20, Color.Black)), GP)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    Else
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), Base)
                        .FillRectangle(New SolidBrush(Color.FromArgb(20, Color.Black)), Base)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    End If
            End Select
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

<DefaultEvent("CheckedChanged")> Class FlatToggle : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private O As _Options
    Private _Checked As Boolean = False
    Private State As MouseState = MouseState.None

#End Region

#Region " Properties"
    Public Event CheckedChanged(ByVal sender As Object)

    <Flags()> _
    Enum _Options
        Style1
        Style2
        Style3
        Style4 '-- TODO: New Style
        Style5 '-- TODO: New Style
    End Enum

#Region " Options"

    <Category("Options")> _
    Public Property Options As _Options
        Get
            Return O
        End Get
        Set(value As _Options)
            O = value
        End Set
    End Property

    <Category("Options")> _
    Public Property Checked As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
        End Set
    End Property

#End Region

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e) : Invalidate()
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Width = 76
        Height = 33
    End Sub

#Region " Mouse States"

    Protected Overrides Sub OnMouseEnter(ByVal e As System.EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        _Checked = Not _Checked
        RaiseEvent CheckedChanged(Me)
    End Sub

#End Region

#End Region

#Region " Colors"

    Private BaseColor As Color = Color.FromArgb(21, 133, 181)
    Private BaseColorRed As Color = Color.FromArgb(21, 133, 181)
    Private BGColor As Color = Color.FromArgb(84, 85, 86)
    Private ToggleColor As Color = Color.FromArgb(45, 47, 49)
    Private TextColor As Color = Color.FromArgb(243, 243, 243)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        Size = New Size(44, Height + 1)
        Cursor = Cursors.Hand
        Font = New Font("Segoe UI", 10)
        Size = New Size(56, 13)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim GP, GP2 As New GraphicsPath
        Dim Base As New Rectangle(0, 0, W, H), Toggle As New Rectangle(CInt(W \ 2), 0, 38, H)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            Select Case O
                Case _Options.Style1   '-- Style 1
                    '-- Base
                    GP = Helpers.RoundRec(Base, 6)
                    GP2 = Helpers.RoundRec(Toggle, 6)
                    .FillPath(New SolidBrush(BGColor), GP)
                    .FillPath(New SolidBrush(ToggleColor), GP2)

                    '-- Text
                    .DrawString("OFF", Font, New SolidBrush(BGColor), New Rectangle(19, 1, W, H), CenterSF)

                    If Checked Then
                        '-- Base
                        GP = Helpers.RoundRec(Base, 6)
                        GP2 = Helpers.RoundRec(New Rectangle(CInt(W \ 2), 0, 38, H), 6)
                        .FillPath(New SolidBrush(ToggleColor), GP)
                        .FillPath(New SolidBrush(BaseColor), GP2)

                        '-- Text
                        .DrawString("ON", Font, New SolidBrush(BaseColor), New Rectangle(8, 7, W, H), NearSF)
                    End If
                Case _Options.Style2   '-- Style 2
                    '-- Base
                    GP = Helpers.RoundRec(Base, 6)
                    Toggle = New Rectangle(4, 4, 36, H - 8)
                    GP2 = Helpers.RoundRec(Toggle, 4)
                    .FillPath(New SolidBrush(BaseColorRed), GP)
                    .FillPath(New SolidBrush(ToggleColor), GP2)

                    '-- Lines
                    .DrawLine(New Pen(BGColor), 18, 20, 18, 12)
                    .DrawLine(New Pen(BGColor), 22, 20, 22, 12)
                    .DrawLine(New Pen(BGColor), 26, 20, 26, 12)

                    '-- Text
                    .DrawString("r", New Font("Marlett", 8), New SolidBrush(TextColor), New Rectangle(19, 2, Width, Height), CenterSF)

                    If Checked Then
                        GP = Helpers.RoundRec(Base, 6)
                        Toggle = New Rectangle(CInt(W \ 2) - 2, 4, 36, H - 8)
                        GP2 = Helpers.RoundRec(Toggle, 4)
                        .FillPath(New SolidBrush(BaseColor), GP)
                        .FillPath(New SolidBrush(ToggleColor), GP2)

                        '-- Lines
                        .DrawLine(New Pen(BGColor), CInt(W \ 2) + 12, 20, CInt(W \ 2) + 12, 12)
                        .DrawLine(New Pen(BGColor), CInt(W \ 2) + 16, 20, CInt(W \ 2) + 16, 12)
                        .DrawLine(New Pen(BGColor), CInt(W \ 2) + 20, 20, CInt(W \ 2) + 20, 12)

                        '-- Text
                        .DrawString("ü", New Font("Wingdings", 14), New SolidBrush(TextColor), New Rectangle(8, 7, Width, Height), NearSF)
                    End If
                Case _Options.Style3   '-- Style 3
                    '-- Base
                    GP = Helpers.RoundRec(Base, 16)
                    Toggle = New Rectangle(W - 28, 4, 22, H - 8)
                    GP2.AddEllipse(Toggle)
                    .FillPath(New SolidBrush(ToggleColor), GP)
                    .FillPath(New SolidBrush(BaseColorRed), GP2)

                    '-- Text
                    .DrawString("OFF", Font, New SolidBrush(BaseColorRed), New Rectangle(-12, 2, W, H), CenterSF)

                    If Checked Then
                        '-- Base
                        GP = Helpers.RoundRec(Base, 16)
                        Toggle = New Rectangle(6, 4, 22, H - 8)
                        GP2.Reset()
                        GP2.AddEllipse(Toggle)
                        .FillPath(New SolidBrush(ToggleColor), GP)
                        .FillPath(New SolidBrush(BaseColor), GP2)

                        '-- Text
                        .DrawString("ON", Font, New SolidBrush(BaseColor), New Rectangle(12, 2, W, H), CenterSF)
                    End If
                Case _Options.Style4
                    '-- TODO: New Styles
                    If Checked Then
                        '--
                    End If
                Case _Options.Style5
                    '-- TODO: New Styles
                    If Checked Then
                        '--
                    End If
            End Select

        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

<DefaultEvent("CheckedChanged")> Class RadioButton : Inherits Control

#Region " Variables"

    Private State As MouseState = MouseState.None
    Private W, H As Integer
    Private O As _Options
    Private _Checked As Boolean

#End Region

#Region " Properties"
    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(value As Boolean)
            _Checked = value
            InvalidateControls()
            RaiseEvent CheckedChanged(Me)
            Invalidate()
        End Set
    End Property
    Event CheckedChanged(ByVal sender As Object)
    Protected Overrides Sub OnClick(e As EventArgs)
        If Not _Checked Then Checked = True
        MyBase.OnClick(e)
    End Sub
    Private Sub InvalidateControls()
        If Not IsHandleCreated OrElse Not _Checked Then Return
        For Each C As Control In Parent.Controls
            If C IsNot Me AndAlso TypeOf C Is RadioButton Then
                DirectCast(C, RadioButton).Checked = False
                Invalidate()
            End If
        Next
    End Sub
    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        InvalidateControls()
    End Sub

    <Flags> _
    Enum _Options
        Style1
        Style2
    End Enum

    <Category("Options")> _
    Public Property Options As _Options
        Get
            Return O
        End Get
        Set(value As _Options)
            O = value
        End Set
    End Property

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 22
    End Sub

#Region " Mouse States"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region
#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
    Private _BorderColor As Color = Color.FromArgb(21, 133, 181) '_FlatColor
    Private _TextColor As Color = Color.FromArgb(243, 243, 243)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                   ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Cursor = Cursors.Hand
        Size = New Size(100, 22)
        BackColor = Color.FromArgb(60, 70, 73)
        Font = New Font("Segoe UI", 10)
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim Base As New Rectangle(0, 2, Height - 5, Height - 5), Dot As New Rectangle(4, 6, H - 12, H - 12)

        With G
            .SmoothingMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            Select Case O
                Case _Options.Style1
                    '-- Base
                    .FillEllipse(New SolidBrush(_BaseColor), Base)

                    Select Case State
                        Case MouseState.Over
                            .DrawEllipse(New Pen(_BorderColor), Base)
                        Case MouseState.Down
                            .DrawEllipse(New Pen(_BorderColor), Base)
                    End Select

                    '-- If Checked 
                    If Checked Then
                        .FillEllipse(New SolidBrush(_BorderColor), Dot)
                    End If

                    If Me.Enabled = False Then
                        '-- Base
                        .FillEllipse(New SolidBrush(_BaseColor), Base)
                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(Color.FromArgb(140, 142, 143)), New Rectangle(20, 2, W, H), NearSF)
                    End If
                Case _Options.Style2
                    '-- Base
                    .FillEllipse(New SolidBrush(_BaseColor), Base)

                    Select Case State
                        Case MouseState.Over
                            '-- Base
                            .DrawEllipse(New Pen(_BorderColor), Base)
                            .FillEllipse(New SolidBrush(Color.FromArgb(118, 213, 170)), Base)
                        Case MouseState.Down
                            '-- Base
                            .DrawEllipse(New Pen(_BorderColor), Base)
                            .FillEllipse(New SolidBrush(Color.FromArgb(118, 213, 170)), Base)
                    End Select

                    '-- If Checked
                    If Checked Then
                        '-- Base
                        .FillEllipse(New SolidBrush(_BorderColor), Dot)
                    End If
            End Select

            .DrawString(Text, Font, New SolidBrush(_TextColor), New Rectangle(20, 2, W, H), NearSF)
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

<DefaultEvent("CheckedChanged")> Class FlatCheckBox : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private State As MouseState = MouseState.None
    Private O As _Options
    Private _Checked As Boolean

#End Region

#Region " Properties"
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        Invalidate()
    End Sub

    Property Checked() As Boolean
        Get
            Return _Checked
        End Get
        Set(ByVal value As Boolean)
            _Checked = value
            Invalidate()
        End Set
    End Property

    Event CheckedChanged(ByVal sender As Object)
    Protected Overrides Sub OnClick(ByVal e As System.EventArgs)
        _Checked = Not _Checked
        RaiseEvent CheckedChanged(Me)
        MyBase.OnClick(e)
    End Sub

    <Flags> _
    Enum _Options
        Style1
        Style2
    End Enum

    <Category("Options")> _
    Public Property Options As _Options
        Get
            Return O
        End Get
        Set(value As _Options)
            O = value
        End Set
    End Property

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 22
    End Sub

#Region " Colors"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property BorderColor As Color
        Get
            Return _BorderColor
        End Get
        Set(value As Color)
            _BorderColor = value
        End Set
    End Property

#End Region

#Region " Mouse States"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(60, 60, 60)
    Private _BorderColor As Color = Color.FromArgb(21, 133, 181)
    Private _TextColor As Color = Color.FromArgb(243, 243, 243)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.FromArgb(50, 50, 50)
        Cursor = Cursors.Hand
        Font = New Font("Segoe UI", 10)
        Size = New Size(112, 22)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim Base As New Rectangle(0, 2, Height - 5, Height - 5)

        With G
            .SmoothingMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)
            Select Case O
                Case _Options.Style1 '-- Style 1
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), Base)

                    Select Case State
                        Case MouseState.Over
                            '-- Base
                            .DrawRectangle(New Pen(_BorderColor), Base)
                        Case MouseState.Down
                            '-- Base
                            .DrawRectangle(New Pen(_BorderColor), Base)
                    End Select

                    '-- If Checked
                    If Checked Then
                        .DrawString("ü", New Font("Wingdings", 18), New SolidBrush(_BorderColor), New Rectangle(5, 7, H - 9, H - 9), CenterSF)
                    End If

                    '-- If Enabled
                    If Me.Enabled = False Then
                        .FillRectangle(New SolidBrush(Color.FromArgb(54, 58, 61)), Base)
                        .DrawString(Text, Font, New SolidBrush(Color.FromArgb(140, 142, 143)), New Rectangle(20, 2, W, H), NearSF)
                    End If

                    '-- Text
                    .DrawString(Text, Font, New SolidBrush(_TextColor), New Rectangle(20, 2, W, H), NearSF)
                Case _Options.Style2 '-- Style 2
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), Base)

                    Select Case State
                        Case MouseState.Over
                            '-- Base
                            .DrawRectangle(New Pen(_BorderColor), Base)
                            .FillRectangle(New SolidBrush(Color.FromArgb(118, 213, 170)), Base)
                        Case MouseState.Down
                            '-- Base
                            .DrawRectangle(New Pen(_BorderColor), Base)
                            .FillRectangle(New SolidBrush(Color.FromArgb(118, 213, 170)), Base)
                    End Select

                    '-- If Checked
                    If Checked Then
                        .DrawString("ü", New Font("Wingdings", 18), New SolidBrush(_BorderColor), New Rectangle(5, 7, H - 9, H - 9), CenterSF)
                    End If

                    '-- If Enabled
                    If Me.Enabled = False Then
                        .FillRectangle(New SolidBrush(Color.FromArgb(54, 58, 61)), Base)
                        .DrawString(Text, Font, New SolidBrush(Color.FromArgb(48, 119, 91)), New Rectangle(20, 2, W, H), NearSF)
                    End If

                    '-- Text
                    .DrawString(Text, Font, New SolidBrush(_TextColor), New Rectangle(20, 2, W, H), NearSF)
            End Select
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

<DefaultEvent("TextChanged")> Class FlatTextBox : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private State As MouseState = MouseState.None
    Private WithEvents TB As Windows.Forms.TextBox

#End Region

#Region " Properties"

#Region " TextBox Properties"

    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    <Category("Options")> _
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
            End If
        End Set
    End Property
    Private _MaxLength As Integer = 32767
    <Category("Options")> _
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If TB IsNot Nothing Then
                TB.MaxLength = value
            End If
        End Set
    End Property
    Private _ReadOnly As Boolean
    <Category("Options")> _
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property
    Private _UseSystemPasswordChar As Boolean
    <Category("Options")> _
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property
    Private _Multiline As Boolean
    <Category("Options")> _
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If TB IsNot Nothing Then
                TB.Multiline = value

                If value Then
                    TB.Height = Height - 11
                Else
                    Height = TB.Height + 11
                End If

            End If
        End Set
    End Property
    <Category("Options")> _
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property
    <Category("Options")> _
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If TB IsNot Nothing Then
                TB.Font = value
                TB.Location = New Point(3, 5)
                TB.Width = Width - 6

                If Not _Multiline Then
                    Height = TB.Height + 11
                End If
            End If
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
        End If
    End Sub
    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = TB.Text
    End Sub
    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TB.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            TB.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub
    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        TB.Location = New Point(5, 5)
        TB.Width = Width - 10

        If _Multiline Then
            TB.Height = Height - 11
        Else
            Height = TB.Height + 11
        End If

        MyBase.OnResize(e)
    End Sub

#End Region

#Region " Colors"

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
        End Set
    End Property

    Public Overrides Property ForeColor() As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
        End Set
    End Property

#End Region

#Region " Mouse States"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : TB.Focus() : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : TB.Focus() : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(35, 35, 35)
    Private _TextColor As Color = Color.FromArgb(192, 192, 192)
    Private _BorderColor As Color = Color.FromArgb(21, 133, 181)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True

        BackColor = Color.Transparent

        TB = New Windows.Forms.TextBox
        TB.Font = New Font("Segoe UI", 10)
        TB.Text = Text
        TB.BackColor = _BaseColor
        TB.ForeColor = _TextColor
        TB.MaxLength = _MaxLength
        TB.Multiline = _Multiline
        TB.ReadOnly = _ReadOnly
        TB.UseSystemPasswordChar = _UseSystemPasswordChar
        TB.BorderStyle = BorderStyle.None
        TB.Location = New Point(5, 5)
        TB.Width = Width - 10

        TB.Cursor = Cursors.IBeam

        If _Multiline Then
            TB.Height = Height - 11
        Else
            Height = TB.Height + 11
        End If

        AddHandler TB.TextChanged, AddressOf OnBaseTextChanged
        AddHandler TB.KeyDown, AddressOf OnBaseKeyDown
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim Base As New Rectangle(1, 1, W - 1, H - 1)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            '-- Colors
            TB.BackColor = _BaseColor
            TB.ForeColor = _TextColor

            '-- Base

            .FillRectangle(New SolidBrush(_BaseColor), Base)

            TekenRondeRechthoek(G, New Pen(New SolidBrush(Color.FromArgb(90, 90, 90))), Base, 0.5!)

            'TekenRondeRechthoek(G, New Pen(New SolidBrush(Color.FromArgb(125, 125, 125))), Base, 0.5!)

        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

    Private Sub TekenRondeRechthoek(ByVal g As Graphics, _
            ByVal pen As Pen, ByVal rectangle As Rectangle, _
            ByVal radius As Single)
        Dim size As Single = (radius * 2.0!)
        Dim gp As GraphicsPath = New GraphicsPath
        gp.AddArc(rectangle.X, rectangle.Y, size, size, 180, 90)

        gp.AddArc((rectangle.X + (rectangle.Width - size)), rectangle.Y, size, size, 270, 90)

        gp.AddArc((rectangle.X + (rectangle.Width - size)), (rectangle.Y + (rectangle.Height - size)), size, size, 0, 90)

        gp.AddArc(rectangle.X, (rectangle.Y + (rectangle.Height - size)), size, size, 90, 90)
        gp.CloseFigure()
        g.DrawPath(pen, gp)
        gp.Dispose()
    End Sub

End Class

Class FlatTabControl : Inherits TabControl

#Region " Variables"

    Private W, H As Integer

#End Region

#Region " Properties"

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

#Region " Colors"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ActiveColor As Color
        Get
            Return _ActiveColor
        End Get
        Set(value As Color)
            _ActiveColor = value
        End Set
    End Property

#End Region

#End Region

#Region " Colors"

    Private BGColor As Color = Color.FromArgb(50, 50, 50)
    Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
    Private _ActiveColor As Color = Color.FromArgb(21, 133, 181)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.FromArgb(41, 41, 41)

        Font = New Font("Segoe UI", 10)
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(120, 40)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(_BaseColor)

            Try : SelectedTab.BackColor = BGColor : Catch : End Try

            For i = 0 To TabCount - 1
                Dim Base As New Rectangle(New Point(GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y), New Size(GetTabRect(i).Width, GetTabRect(i).Height))
                Dim BaseSize As New Rectangle(Base.Location, New Size(Base.Width, Base.Height))

                If i = SelectedIndex Then
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), BaseSize)

                    '-- Gradiant
                    '.fill
                    .FillRectangle(New SolidBrush(_ActiveColor), BaseSize)

                    '-- ImageList
                    If ImageList IsNot Nothing Then
                        Try
                            If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                                '-- Image
                                .DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6))
                                '-- Text
                                .DrawString("      " & TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
                            Else
                                '-- Text
                                .DrawString(TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    Else
                        '-- Text
                        .DrawString(TabPages(i).Text, Font, Brushes.White, BaseSize, CenterSF)
                    End If
                Else
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), BaseSize)

                    '-- ImageList
                    If ImageList IsNot Nothing Then
                        Try
                            If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                                '-- Image
                                .DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6))
                                '-- Text
                                .DrawString("      " & TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                            Else
                                '-- Text
                                .DrawString(TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                            End If
                        Catch ex As Exception
                            Throw New Exception(ex.Message)
                        End Try
                    Else
                        '-- Text
                        .DrawString(TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                    End If
                End If
            Next
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Class PrecisionTimer
    Implements IDisposable

    Private _Enabled As Boolean
    ReadOnly Property Enabled() As Boolean
        Get
            Return _Enabled
        End Get
    End Property

    Private Handle As IntPtr
    Private TimerCallback As TimerDelegate

    <DllImport("kernel32.dll", EntryPoint:="CreateTimerQueueTimer")> _
    Private Shared Function CreateTimerQueueTimer( _
    ByRef handle As IntPtr, _
    ByVal queue As IntPtr, _
    ByVal callback As TimerDelegate, _
    ByVal state As IntPtr, _
    ByVal dueTime As UInteger, _
    ByVal period As UInteger, _
    ByVal flags As UInteger) As Boolean
    End Function

    <DllImport("kernel32.dll", EntryPoint:="DeleteTimerQueueTimer")> _
    Private Shared Function DeleteTimerQueueTimer( _
    ByVal queue As IntPtr, _
    ByVal handle As IntPtr, _
    ByVal callback As IntPtr) As Boolean
    End Function

    Delegate Sub TimerDelegate(ByVal reserve As IntPtr, ByVal reserve As Boolean)

    Sub Create(ByVal dueTime As UInteger, ByVal period As UInteger, ByVal callback As TimerDelegate)
        If _Enabled Then Return

        TimerCallback = callback
        Dim Success As Boolean = CreateTimerQueueTimer(Handle, IntPtr.Zero, TimerCallback, IntPtr.Zero, dueTime, period, 0)

        If Not Success Then ThrowNewException("CreateTimerQueueTimer")
        _Enabled = Success
    End Sub

    Sub Delete()
        If Not _Enabled Then Return
        Dim Success As Boolean = DeleteTimerQueueTimer(IntPtr.Zero, Handle, IntPtr.Zero)

        If Not Success AndAlso Not Marshal.GetLastWin32Error = 997 Then
            ThrowNewException("DeleteTimerQueueTimer")
        End If

        _Enabled = Not Success
    End Sub

    Private Sub ThrowNewException(ByVal name As String)
        Throw New Exception(String.Format("{0} failed. Win32Error: {1}", name, Marshal.GetLastWin32Error))
    End Sub

    Private Sub Dispose() Implements IDisposable.Dispose
        Delete()
    End Sub
End Class

Public Class FlatTabControl2 : Inherits TabControl

#Region " Variables"

    Private W, H As Integer

#End Region

#Region " Properties"

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

#Region " Colors"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> Public Property ActiveColor As Color
        Get
            Return _ActiveColor
        End Get
        Set(value As Color)
            _ActiveColor = value
        End Set
    End Property

#End Region

#End Region

#Region " Colors"

    Private BGColor As Color = Color.FromArgb(39, 39, 39)
    Private _BaseColor As Color = Color.FromArgb(45, 47, 49)
    Private _ActiveColor As Color = _FlatColor

#End Region

    Dim hover
    Private Shared AnimateNum As Integer = 0
    Private Shared AnimateNum2 As Integer = 40
    Private Shared PixelActiveWhile As Integer = 0
    Private Shared HoveredTab As Integer = -1
    Private Shared Tabs As List(Of Integer)
    Public Shared fadecolor As Color = Color.FromArgb(125, 125, 125)
    Dim rr As Integer = 125
    Dim gg As Integer = 125
    Dim bb As Integer = 125

    Dim Timerr As New PrecisionTimer

    Private Sub DoCallback(ByVal state As IntPtr, ByVal reserve As Boolean)

        Try

            If Not rr < 21 Then
                rr -= 1
            End If

            If Not gg > 133 Then
                gg += 2
            End If

            If Not bb > 181 Then
                bb += 2
            End If

            If Not fadecolor = Color.FromArgb(21, 133, 181) Then
                fadecolor = Color.FromArgb(rr, gg, bb) 'AvgColor(Color.FromArgb(125, 125, 125), Color.FromArgb(21, 133, 181), tickValue, tickCount)
                'Invalidate()
            End If

            'If Not AnimateNum2 = 33 Then
            '    Invalidate()
            '    AnimateNum2 -= 1
            'End If

            'If Not AnimateNum >= 5 Then
            '    Invalidate()
            '    AnimateNum += 1
            'End If

        Catch
        End Try

    End Sub

    Sub New()

        'CreateTimer()

        'Timerr = New PrecisionTimer
        'Timerr.Create(0, 20, AddressOf DoCallback)

        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                         ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.FromArgb(60, 70, 73)

        Font = New Font("Segoe UI", 10, FontStyle.Regular, GraphicsUnit.Pixel)
        SizeMode = TabSizeMode.Fixed
        ItemSize = New Size(95, 47)
        Tabs = New List(Of Integer)()
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        AnimateNum = -10
        AnimateNum2 = 41
        HoveredTab = -1
        fadecolor = Color.FromArgb(125, 125, 125)
        rr = 125
        gg = 125
        bb = 125
        MyBase.OnMouseLeave(e)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)

        Font = New Font("Segoe UI Regular", 22, FontStyle.Regular, GraphicsUnit.Pixel)

        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(_BaseColor)

            Try : SelectedTab.BackColor = BGColor : Catch : End Try

            For i = 0 To TabCount - 1

                Dim Base As New Rectangle(New Point(GetTabRect(i).Location.X + 2, GetTabRect(i).Location.Y), New Size(GetTabRect(i).Width, GetTabRect(i).Height))
                Dim BaseSize As New Rectangle(Base.Location, New Size(Base.Width, Base.Height + 1))

                If i = SelectedIndex Then

                    '-- Base
                    '.FillRectangle(New SolidBrush(_BaseColor), BaseSize)

                    '.FillRectangle(New SolidBrush(Color.Transparent), New Rectangle(0, GetTabRect(i).Height, GetTabRect(i).Location.X, 3))

                    '-- Gradiant
                    '.fill
                    '.FillRectangle(New SolidBrush(Color.FromArgb(21, 133, 181)), BaseSize)

                    .FillRectangle(New SolidBrush(_BaseColor), New Rectangle(Base.Location, New Size(Base.Width, Base.Height - 4)))

                    .DrawString(TabPages(i).Text, Font, New SolidBrush(Color.FromArgb(21, 133, 181)), BaseSize, CenterSF)

                    '-- ImageList
                    'If ImageList IsNot Nothing Then
                    'Try
                    '    If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                    '        '-- Image
                    '        .DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6))
                    '        '-- Text
                    '        .DrawString("      " & TabPages(i).Text, Font, New SolidBrush(Color.FromArgb(21, 133, 181)), BaseSize, CenterSF)
                    '    Else
                    '        '-- Text
                    '        .DrawString(TabPages(i).Text, Font, New SolidBrush(Color.FromArgb(21, 133, 181)), BaseSize, CenterSF)
                    '    End If
                    'Catch ex As Exception
                    '    Throw New Exception(ex.Message)
                    'End Try
                    'Else
                    '-- Text
                    'End If

                ElseIf i = HoveredTab Then

                    G.FillRectangle(New SolidBrush(Color.FromArgb(21, 133, 181)), New Rectangle(New Point(BaseSize.Location.X, AnimateNum2), New Size(GetTabRect(i).Size.Width, AnimateNum)))

                    '.DrawString(TabPages(i).Text, Font, New SolidBrush(Color.FromArgb(21, 133, 181)), BaseSize, CenterSF)

                    .DrawString(TabPages(i).Text, Font, New SolidBrush(fadecolor), BaseSize, CenterSF)

                    Invalidate()

                Else

                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), BaseSize)

                    .FillRectangle(New SolidBrush(Color.Transparent), New Rectangle(0, GetTabRect(i).Height, GetTabRect(i).Location.X, 3))

                    .DrawString(TabPages(i).Text, Font, New SolidBrush(Color.FromArgb(125, 125, 125)), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})

                    '-- ImageList
                    'If ImageList IsNot Nothing Then
                    '    Try
                    '        If ImageList.Images(TabPages(i).ImageIndex) IsNot Nothing Then
                    '            '-- Image
                    '            .DrawImage(ImageList.Images(TabPages(i).ImageIndex), New Point(BaseSize.Location.X + 8, BaseSize.Location.Y + 6))
                    '            '-- Text
                    '            .DrawString("      " & TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                    '        Else
                    '            '-- Text
                    '            .DrawString(TabPages(i).Text, Font, New SolidBrush(Color.White), BaseSize, New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Center})
                    '        End If
                    '    Catch ex As Exception
                    '        Throw New Exception(ex.Message)
                    '    End Try
                    'Else
                    '-- Text
                    'End If
                End If

            Next

        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

    Public Sub DisposeTimer()
        Timerr.Delete()
    End Sub

    Public Sub CreateTimer()
        Timerr = New PrecisionTimer
        Timerr.Create(0, 10, AddressOf DoCallback)
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        If Not HoveredTab = IdentTab(e.X) Then
            AnimateNum = 0
            AnimateNum2 = 41
            fadecolor = Color.FromArgb(125, 125, 125)
            rr = 125
            gg = 125
            bb = 125
            'If Timerr.Enabled = True Then
            '    DisposeTimer()
            'End If
        End If
        HoveredTab = IdentTab(e.X)
        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
        If TypeOf e.Control Is TabPage Then
            If Not (TabCount <= 0) Then
                Tabs.Add(TabCount * 95)
                e.Control.Tag = Tabs.Count - 1
            End If
        End If
        MyBase.OnControlAdded(e)
    End Sub

    Protected Overrides Sub OnControlRemoved(e As ControlEventArgs)
        If TypeOf e.Control Is TabPage Then
            Tabs.RemoveAt(Convert.ToInt32(e.Control.Tag))
        End If
        MyBase.OnControlRemoved(e)
    End Sub

    Public Function IdentTab(x As Integer) As Integer
        Try
            x -= 4
            If x < Tabs(0) Then
                Return 0
            End If
            If x < Tabs(1) Then
                Return 1
            End If
            If x < Tabs(2) Then
                Return 2
            End If
            If x < Tabs(3) Then
                Return 3
            End If
            If x < Tabs(4) Then
                Return 4
            End If
            If x < Tabs(5) Then
                Return 5
            End If
            If x < Tabs(6) Then
                Return 6
            End If
            If x < Tabs(7) Then
                Return 7
            End If
            If x < Tabs(8) Then
                Return 8
            End If
        Catch
        End Try
    End Function

End Class

MustInherit Class ThemeControl
    Inherits Control

#Region " Initialization "

    Protected G As Graphics, B As Bitmap
    Sub New()
        SetStyle(DirectCast(139270, ControlStyles), True)
        B = New Bitmap(1, 1)
        G = Graphics.FromImage(B)
    End Sub

    Sub AllowTransparent()
        SetStyle(ControlStyles.Opaque, False)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal v As String)
            MyBase.Text = v
            Invalidate()
        End Set
    End Property
#End Region

#Region " Mouse Handling "

    Protected Enum State As Byte
        MouseNone = 0
        MouseOver = 1
        MouseDown = 2
    End Enum

    Protected MouseState As State
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
        ChangeMouseState(State.MouseNone)
        MyBase.OnMouseLeave(e)
    End Sub
    Protected Overrides Sub OnMouseEnter(ByVal e As EventArgs)
        ChangeMouseState(State.MouseOver)
        MyBase.OnMouseEnter(e)
    End Sub
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ChangeMouseState(State.MouseOver)
        MyBase.OnMouseUp(e)
    End Sub
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then ChangeMouseState(State.MouseDown)
        MyBase.OnMouseDown(e)
    End Sub

    Private Sub ChangeMouseState(ByVal e As State)
        MouseState = e
        Invalidate()
    End Sub

#End Region

#Region " Convienence "

    MustOverride Sub PaintHook()
    Protected NotOverridable Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        If Width = 0 OrElse Height = 0 Then Return
        PaintHook()
        e.Graphics.DrawImage(B, 0, 0)
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Not Width = 0 AndAlso Not Height = 0 Then
            B = New Bitmap(Width, Height)
            G = Graphics.FromImage(B)
            Invalidate()
        End If
        MyBase.OnSizeChanged(e)
    End Sub

    Private _NoRounding As Boolean
    Property NoRounding() As Boolean
        Get
            Return _NoRounding
        End Get
        Set(ByVal v As Boolean)
            _NoRounding = v
            Invalidate()
        End Set
    End Property

    Private _Image As Image
    Property Image() As Image
        Get
            Return _Image
        End Get
        Set(ByVal value As Image)
            _Image = value
            Invalidate()
        End Set
    End Property
    ReadOnly Property ImageWidth() As Integer
        Get
            If _Image Is Nothing Then Return 0
            Return _Image.Width
        End Get
    End Property
    ReadOnly Property ImageTop() As Integer
        Get
            If _Image Is Nothing Then Return 0
            Return Height \ 2 - _Image.Height \ 2
        End Get
    End Property

    Private _Size As Size
    Private _Rectangle As Rectangle
    Private _Gradient As LinearGradientBrush
    Private _Brush As SolidBrush

    Protected Sub DrawCorners(ByVal c As Color, ByVal rect As Rectangle)
        If _NoRounding Then Return

        B.SetPixel(rect.X, rect.Y, c)
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y, c)
        B.SetPixel(rect.X, rect.Y + (rect.Height - 1), c)
        B.SetPixel(rect.X + (rect.Width - 1), rect.Y + (rect.Height - 1), c)
    End Sub

    Protected Sub DrawBorders(ByVal p1 As Pen, ByVal p2 As Pen, ByVal rect As Rectangle)
        G.DrawRectangle(p1, rect.X, rect.Y, rect.Width - 1, rect.Height - 1)
        G.DrawRectangle(p2, rect.X + 1, rect.Y + 1, rect.Width - 3, rect.Height - 3)
    End Sub

    Protected Sub DrawText(ByVal a As HorizontalAlignment, ByVal c As Color, ByVal x As Integer)
        DrawText(a, c, x, 0)
    End Sub
    Protected Sub DrawText(ByVal a As HorizontalAlignment, ByVal c As Color, ByVal x As Integer, ByVal y As Integer)
        If String.IsNullOrEmpty(Text) Then Return
        _Size = G.MeasureString(Text, Font).ToSize
        _Brush = New SolidBrush(c)

        Select Case a
            Case HorizontalAlignment.Left
                G.DrawString(Text, Font, _Brush, x, Height \ 2 - _Size.Height \ 2 + y)
            Case HorizontalAlignment.Right
                G.DrawString(Text, Font, _Brush, Width - _Size.Width - x, Height \ 2 - _Size.Height \ 2 + y)
            Case HorizontalAlignment.Center
                G.DrawString(Text, Font, _Brush, Width \ 2 - _Size.Width \ 2 + x, Height \ 2 - _Size.Height \ 2 + y)
        End Select
    End Sub

    Protected Sub DrawIcon(ByVal a As HorizontalAlignment, ByVal x As Integer)
        DrawIcon(a, x, 0)
    End Sub
    Protected Sub DrawIcon(ByVal a As HorizontalAlignment, ByVal x As Integer, ByVal y As Integer)
        If _Image Is Nothing Then Return
        Select Case a
            Case HorizontalAlignment.Left
                G.DrawImage(_Image, x, Height \ 2 - _Image.Height \ 2 + y)
            Case HorizontalAlignment.Right
                G.DrawImage(_Image, Width - _Image.Width - x, Height \ 2 - _Image.Height \ 2 + y)
            Case HorizontalAlignment.Center
                G.DrawImage(_Image, Width \ 2 - _Image.Width \ 2, Height \ 2 - _Image.Height \ 2)
        End Select
    End Sub

    Protected Sub DrawGradient(ByVal c1 As Color, ByVal c2 As Color, ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal angle As Single)
        _Rectangle = New Rectangle(x, y, width, height)
        _Gradient = New LinearGradientBrush(_Rectangle, c1, c2, angle)
        G.FillRectangle(_Gradient, _Rectangle)
    End Sub
#End Region

End Class

<DefaultEvent("CharacterSelection")>
Class RandomPool
    Inherits ThemeControl

    Private GO As Graphics, _Size As Size
    Event CharacterSelection(ByVal s As Object, ByVal c As Char)

    Sub New()
        GO = Graphics.FromHwndInternal(Handle)
    End Sub

    Private _Range As String = "0123456789ABCDEFGHILMNOPQRSTUVZWXYJKabcdefghilmnopqrstuvzwxyk"
    Property Range() As String
        Get
            Return _Range
        End Get
        Set(ByVal v As String)
            _Range = v
            UpdateSize()
        End Set
    End Property

    Private _RangePadding As Integer = 2
    Public Property RangePadding() As Integer
        Get
            Return _RangePadding
        End Get
        Set(ByVal v As Integer)
            _RangePadding = v
            UpdateSize()
        End Set
    End Property

    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal v As Font)
            MyBase.Font = v
            UpdateSize()
        End Set
    End Property

    Private Count As Integer
    Private Sub UpdateSize()
        _Size = New Size(0, 0)

        Dim T As Size
        For I As Integer = 0 To _Range.Length - 1
            T = GO.MeasureString(_Range(I), Font).ToSize()
            T.Width += _RangePadding
            T.Height += _RangePadding

            If T.Height > _Size.Height Then _Size.Height = T.Height
            If T.Width > _Size.Width Then _Size.Width = T.Width
        Next

        Randomize()
    End Sub

    Private Index1, Index2 As Integer, Items As Char()
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        Index1 = GetIndex(e.X, e.Y)

        If Index1 = Index2 Then Return

        RaiseEvent CharacterSelection(Me, Items(Index1))

        Randomize(Index1 - Count)
        Randomize(Index1 - 1)
        Randomize(Index1)
        Randomize(Index1 + 1)
        Randomize(Index1 + Count)

        Index2 = Index1
        Invalidate()
    End Sub
    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If _Size.Width = 0 Then UpdateSize() Else Randomize()
        MyBase.OnSizeChanged(e)
    End Sub

    Overrides Sub PaintHook()
        G.Clear(BackColor)

        For X As Integer = 0 To Width - 1 Step _Size.Width
            For Y As Integer = 0 To Height - 1 Step _Size.Height
                G.DrawString(Items(GetIndex(X, Y)), Font, New SolidBrush(Color.FromArgb(21, 133, 181)), X, Y)
            Next
        Next

    End Sub

    Private Function GetIndex(ByVal x As Integer, ByVal y As Integer) As Integer
        Return (y \ _Size.Height) * Count + (x \ _Size.Width)
    End Function

    Private RN As Random
    Private Sub Randomize()
        Count = CInt(Math.Ceiling(Width / _Size.Width))

        RN = New Random(Guid.NewGuid.GetHashCode)
        Items = New Char(CInt(Math.Ceiling(Width / _Size.Width) * Math.Ceiling(Height / _Size.Height)) - 1) {}

        For I As Integer = 0 To Items.Length - 1
            Items(I) = _Range(RN.Next(_Range.Length))
        Next

        Invalidate()
    End Sub
    Private Sub Randomize(ByVal index As Integer)
        If index > -1 AndAlso index < Items.Length Then Items(index) = _Range(RN.Next(_Range.Length))
    End Sub

End Class

Class FlatAlertBox : Inherits Control

    ''' <summary>
    ''' How to use: FlatAlertBox.ShowControl(Kind, String, Interval)
    ''' </summary>
    ''' <remarks></remarks>

#Region " Variables"

    Private W, H As Integer
    Private K As _Kind
    Private _Text As String
    Private State As MouseState = MouseState.None
    Private X As Integer
    Private WithEvents T As Timer

#End Region

#Region " Properties"

    <Flags()> _
    Enum _Kind
        [Success]
        [Error]
        [Info]
    End Enum

#Region " Options"

    <Category("Options")> _
    Public Property kind As _Kind
        Get
            Return K
        End Get
        Set(value As _Kind)
            K = value
        End Set
    End Property

    <Category("Options")> _
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If _Text IsNot Nothing Then
                _Text = value
            End If
        End Set
    End Property

    <Category("Options")> _
    Shadows Property Visible As Boolean
        Get
            Return MyBase.Visible = False
        End Get
        Set(value As Boolean)
            MyBase.Visible = value
        End Set
    End Property

#End Region

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e) : Invalidate()
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 42
    End Sub

    Public Sub ShowControl(Kind As _Kind, Str As String, Interval As Integer)
        K = Kind
        Text = Str
        Me.Visible = True
        T = New Timer
        T.Interval = Interval
        T.Enabled = True
    End Sub

    Private Sub T_Tick(sender As Object, e As EventArgs) Handles T.Tick
        Me.Visible = False
        T.Enabled = False
        T.Dispose()
    End Sub

#Region " Mouse States"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        X = e.X : Invalidate()
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e)
        Me.Visible = False
    End Sub

#End Region

#End Region

#Region " Colors"

    Private SuccessColor As Color = Color.FromArgb(60, 85, 79)
    Private SuccessText As Color = Color.FromArgb(35, 169, 110)
    Private ErrorColor As Color = Color.FromArgb(87, 71, 71)
    Private ErrorText As Color = Color.FromArgb(254, 142, 122)
    Private InfoColor As Color = Color.FromArgb(70, 91, 94)
    Private InfoText As Color = Color.FromArgb(97, 185, 186)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.FromArgb(60, 70, 73)
        Size = New Size(576, 42)
        Location = New Point(10, 61)
        Font = New Font("Segoe UI", 10)
        Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim Base As New Rectangle(0, 0, W, H)

        With G
            .SmoothingMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            Select Case K
                Case _Kind.Success
                    '-- Base
                    .FillRectangle(New SolidBrush(SuccessColor), Base)

                    '-- Ellipse
                    .FillEllipse(New SolidBrush(SuccessText), New Rectangle(8, 9, 24, 24))
                    .FillEllipse(New SolidBrush(SuccessColor), New Rectangle(10, 11, 20, 20))

                    '-- Checked Sign
                    .DrawString("ü", New Font("Wingdings", 22), New SolidBrush(SuccessText), New Rectangle(7, 7, W, H), NearSF)
                    .DrawString(Text, Font, New SolidBrush(SuccessText), New Rectangle(48, 12, W, H), NearSF)

                    '-- X button
                    .FillEllipse(New SolidBrush(Color.FromArgb(35, Color.Black)), New Rectangle(W - 30, H - 29, 17, 17))
                    .DrawString("r", New Font("Marlett", 8), New SolidBrush(SuccessColor), New Rectangle(W - 28, 16, W, H), NearSF)

                    Select Case State ' -- Mouse Over
                        Case MouseState.Over
                            .DrawString("r", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(25, Color.White)), New Rectangle(W - 28, 16, W, H), NearSF)
                    End Select

                Case _Kind.Error
                    '-- Base
                    .FillRectangle(New SolidBrush(ErrorColor), Base)

                    '-- Ellipse
                    .FillEllipse(New SolidBrush(ErrorText), New Rectangle(8, 9, 24, 24))
                    .FillEllipse(New SolidBrush(ErrorColor), New Rectangle(10, 11, 20, 20))

                    '-- X Sign
                    .DrawString("r", New Font("Marlett", 16), New SolidBrush(ErrorText), New Rectangle(6, 11, W, H), NearSF)
                    .DrawString(Text, Font, New SolidBrush(ErrorText), New Rectangle(48, 12, W, H), NearSF)

                    '-- X button
                    .FillEllipse(New SolidBrush(Color.FromArgb(35, Color.Black)), New Rectangle(W - 32, H - 29, 17, 17))
                    .DrawString("r", New Font("Marlett", 8), New SolidBrush(ErrorColor), New Rectangle(W - 30, 17, W, H), NearSF)

                    Select Case State
                        Case MouseState.Over ' -- Mouse Over
                            .DrawString("r", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(25, Color.White)), New Rectangle(W - 30, 15, W, H), NearSF)
                    End Select

                Case _Kind.Info
                    '-- Base
                    .FillRectangle(New SolidBrush(InfoColor), Base)

                    '-- Ellipse
                    .FillEllipse(New SolidBrush(InfoText), New Rectangle(8, 9, 24, 24))
                    .FillEllipse(New SolidBrush(InfoColor), New Rectangle(10, 11, 20, 20))

                    '-- Info Sign
                    .DrawString("¡", New Font("Segoe UI", 20, FontStyle.Bold), New SolidBrush(InfoText), New Rectangle(12, -4, W, H), NearSF)
                    .DrawString(Text, Font, New SolidBrush(InfoText), New Rectangle(48, 12, W, H), NearSF)

                    '-- X button
                    .FillEllipse(New SolidBrush(Color.FromArgb(35, Color.Black)), New Rectangle(W - 32, H - 29, 17, 17))
                    .DrawString("r", New Font("Marlett", 8), New SolidBrush(InfoColor), New Rectangle(W - 30, 17, W, H), NearSF)

                    Select Case State
                        Case MouseState.Over ' -- Mouse Over
                            .DrawString("r", New Font("Marlett", 8), New SolidBrush(Color.FromArgb(25, Color.White)), New Rectangle(W - 30, 17, W, H), NearSF)
                    End Select
            End Select

        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

End Class

Class FlatProgressBar : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100

#End Region

#Region " Properties"

#Region " Control"

    <Category("Control")>
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                    Invalidate()
                Case Else
                    Return _Value
                    Invalidate()
            End Select
        End Get
        Set(V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Invalidate()
        End Set
    End Property

#End Region

#Region " Colors"

    <Category("Colors")>
    Public Property ProgressColor As Color
        Get
            Return _ProgressColor
        End Get
        Set(value As Color)
            _ProgressColor = value
        End Set
    End Property

    <Category("Colors")>
    Public Property DarkerProgress As Color
        Get
            Return _DarkerProgress
        End Get
        Set(value As Color)
            _DarkerProgress = value
        End Set
    End Property

#End Region

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 42
    End Sub

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Height = 42
    End Sub

    Public Sub Increment(ByVal Amount As Integer)
        Value += Amount
    End Sub

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(60, 60, 60)
    Private _ProgressColor As Color = Color.FromArgb(21, 133, 181)
    Private _DarkerProgress As Color = Color.FromArgb(21, 133, 181)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        BackColor = Color.FromArgb(50, 50, 50)
        Height = 30
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim Base As New Rectangle(0, 24, W, H)
        Dim GP, GP2, GP3 As New GraphicsPath

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            '-- Progress Value
            Dim iValue As Integer = CInt(_Value / _Maximum * Width)

            Select Case Value
                Case 0
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), Base)
                    '--Progress
                    .FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, 24, iValue - 1, H - 1))
                Case 100
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), Base)
                    '--Progress
                    .FillRectangle(New SolidBrush(_ProgressColor), New Rectangle(0, 24, iValue - 1, H - 1))
                Case Else
                    '-- Base
                    .FillRectangle(New SolidBrush(_BaseColor), Base)

                    '--Progress
                    GP.AddRectangle(New Rectangle(0, 24, iValue - 1, H - 1))
                    .FillPath(New SolidBrush(_ProgressColor), GP)

                    '-- Hatch Brush
                    Dim HB As New HatchBrush(HatchStyle.Plaid, _DarkerProgress, _ProgressColor)
                    .FillRectangle(HB, New Rectangle(0, 24, iValue - 1, H - 1))

                    '-- Balloon
                    Dim Balloon As New Rectangle(iValue - 18, 0, 34, 16)
                    GP2 = Helpers.RoundRec(Balloon, 4)
                    .FillPath(New SolidBrush(_BaseColor), GP2)

                    '-- Arrow
                    GP3 = Helpers.DrawArrow(iValue - 9, 16, True)
                    .FillPath(New SolidBrush(_BaseColor), GP3)

                    '-- Value > You can add "%" > value & "%"
                    .DrawString(Value, New Font("Segoe UI", 10), New SolidBrush(_ProgressColor), New Rectangle(iValue - 11, -2, W, H), NearSF)
            End Select
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

End Class

Class FlatComboBox : Inherits Windows.Forms.ComboBox

#Region " Variables"

    Private W, H As Integer
    Private _StartIndex As Integer = 0
    Private x, y As Integer

#End Region

#Region " Properties"

#Region " Mouse States"

    Private State As MouseState = MouseState.None
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        x = e.Location.X
        y = e.Location.Y
        Invalidate()
        If e.X < Width - 41 Then Cursor = Cursors.IBeam Else Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnDrawItem(e As DrawItemEventArgs)
        MyBase.OnDrawItem(e) : Invalidate()
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            Invalidate()
        End If
    End Sub

    Protected Overrides Sub OnClick(e As EventArgs)
        MyBase.OnClick(e) : Invalidate()
    End Sub

#End Region

#Region " Colors"

    <Category("Colors")> _
    Public Property HoverColor As Color
        Get
            Return _HoverColor
        End Get
        Set(value As Color)
            _HoverColor = value
        End Set
    End Property

#End Region

    Private Property StartIndex As Integer
        Get
            Return _StartIndex
        End Get
        Set(ByVal value As Integer)
            _StartIndex = value
            Try
                MyBase.SelectedIndex = value
            Catch
            End Try
            Invalidate()
        End Set
    End Property

    Sub DrawItem_(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        If e.Index < 0 Then Exit Sub
        e.DrawBackground()
        e.DrawFocusRectangle()

        e.Graphics.SmoothingMode = 2
        e.Graphics.PixelOffsetMode = 2
        e.Graphics.TextRenderingHint = 3
        e.Graphics.InterpolationMode = 7

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
            '-- Selected item
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(21, 133, 181)), e.Bounds)
        Else
            '-- Not Selected
            e.Graphics.FillRectangle(New SolidBrush(_BaseColor), e.Bounds)
        End If

        '-- Text
        e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), New Font("Segoe UI", 8), _
                     Brushes.White, New Rectangle(e.Bounds.X + 2, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height))


        e.Graphics.Dispose()
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 18
    End Sub

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(60, 60, 60)
    Private _BGColor As Color = Color.FromArgb(60, 60, 60)
    Private _HoverColor As Color = Color.FromArgb(21, 133, 181)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True

        DrawMode = DrawMode.OwnerDrawFixed
        BackColor = Color.FromArgb(50, 50, 50)
        ForeColor = Color.White
        DropDownStyle = ComboBoxStyle.DropDownList
        Cursor = Cursors.Hand
        StartIndex = 0
        ItemHeight = 18
        Font = New Font("Segoe UI", 8, FontStyle.Regular)

    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width : H = Height

        Dim Base As New Rectangle(0, 0, W, H)
        Dim Button As New Rectangle(CInt(W - 40), 0, W, H)
        Dim GP, GP2 As New GraphicsPath

        If Not Items.Count = Nothing Then
            If SelectedIndex = -1 Then
                SelectedIndex = 0
            End If
        End If


        With G
            .Clear(Color.FromArgb(21, 133, 181))
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3

            '-- Base
            .FillRectangle(New SolidBrush(_BGColor), Base)

            '-- Button
            GP.Reset()
            GP.AddRectangle(Button)
            .SetClip(GP)
            .FillRectangle(New SolidBrush(_BaseColor), Button)
            .ResetClip()

            '-- Lines
            .DrawLine(Pens.White, W - 10, 6, W - 30, 6)
            .DrawLine(Pens.White, W - 10, 12, W - 30, 12)
            .DrawLine(Pens.White, W - 10, 18, W - 30, 18)

            '-- Text
            .DrawString(Text, Font, Brushes.White, New Point(4, 6), NearSF)
        End With

        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Class FlatStickyButton : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private State As MouseState = MouseState.None
    Private _Rounded As Boolean = False

#End Region

#Region " Properties"

#Region " MouseStates"

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        State = MouseState.Over : Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region

#Region " Function"

    Private Function GetConnectedSides() As Boolean()
        Dim Bool = New Boolean(3) {False, False, False, False}

        For Each B As Control In Parent.Controls
            If TypeOf B Is FlatStickyButton Then
                If B Is Me Or Not Rect.IntersectsWith(Rect) Then Continue For
                Dim A = Math.Atan2(Left() - B.Left, Top - B.Top) * 2 / Math.PI
                If A \ 1 = A Then Bool(A + 1) = True
            End If
        Next

        Return Bool
    End Function

    Private ReadOnly Property Rect() As Rectangle
        Get
            Return New Rectangle(Left, Top, Width, Height)
        End Get
    End Property

#End Region

#Region " Colors"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
        End Set
    End Property

    <Category("Options")> _
    Public Property Rounded As Boolean
        Get
            Return _Rounded
        End Get
        Set(value As Boolean)
            _Rounded = value
        End Set
    End Property

#End Region

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        'Height = 32
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        'Size = New Size(112, 32)
    End Sub

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(21, 133, 181)
    Private _TextColor As Color = Color.FromArgb(243, 243, 243)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
        ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
        ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Size = New Size(106, 32)
        BackColor = Color.Transparent
        Font = New Font("Segoe UI", 10)
        Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width : H = Height

        Dim GP As New GraphicsPath

        Dim GCS = GetConnectedSides()
        Dim RoundedBase = Helpers.RoundRect(0, 0, W, H, , Not (GCS(2) Or GCS(1)), Not (GCS(1) Or GCS(0)), Not (GCS(3) Or GCS(0)), Not (GCS(3) Or GCS(2)))
        Dim Base As New Rectangle(0, 0, W, H)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            Select Case State
                Case MouseState.None
                    If Rounded Then
                        '-- Base
                        GP = RoundedBase
                        .FillPath(New SolidBrush(_BaseColor), GP)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    Else
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), Base)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    End If
                Case MouseState.Over
                    If Rounded Then
                        '-- Base
                        GP = RoundedBase
                        .FillPath(New SolidBrush(_BaseColor), GP)
                        .FillPath(New SolidBrush(Color.FromArgb(20, Color.White)), GP)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    Else
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), Base)
                        .FillRectangle(New SolidBrush(Color.FromArgb(20, Color.White)), Base)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    End If
                Case MouseState.Down
                    If Rounded Then
                        '-- Base
                        GP = RoundedBase
                        .FillPath(New SolidBrush(_BaseColor), GP)
                        .FillPath(New SolidBrush(Color.FromArgb(20, Color.Black)), GP)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    Else
                        '-- Base
                        .FillRectangle(New SolidBrush(_BaseColor), Base)
                        .FillRectangle(New SolidBrush(Color.FromArgb(20, Color.Black)), Base)

                        '-- Text
                        .DrawString(Text, Font, New SolidBrush(_TextColor), Base, CenterSF)
                    End If
            End Select

        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

End Class

Class FlatNumeric : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private State As MouseState = MouseState.None
    Private x, y As Integer
    Private _Value, _Min, _Max As Long
    Private Bool As Boolean

#End Region

#Region " Properties"

    Public Property Value As Long
        Get
            Return _Value
        End Get
        Set(value As Long)
            If value <= _Max And value >= _Min Then _Value = value
            Invalidate()
        End Set
    End Property

    Public Property Maximum As Long
        Get
            Return _Max
        End Get
        Set(value As Long)
            If value > _Min Then _Max = value
            If _Value > _Max Then _Value = _Max
            Invalidate()
        End Set
    End Property

    Public Property Minimum As Long
        Get
            Return _Min
        End Get
        Set(value As Long)
            If value < _Max Then _Min = value
            If _Value < _Min Then _Value = Minimum
            Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        x = e.Location.X
        y = e.Location.Y
        Invalidate()
        If e.X < Width - 23 Then Cursor = Cursors.IBeam Else Cursor = Cursors.Hand
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If x > Width - 21 AndAlso x < Width - 3 Then
            If y < 15 Then
                If (Value + 1) <= _Max Then _Value += 1
            Else
                If (Value - 1) >= _Min Then _Value -= 1
            End If
        Else
            Bool = Not Bool
            Focus()
        End If
        Invalidate()
    End Sub

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        MyBase.OnKeyPress(e)
        Try
            If Bool Then _Value = CStr(CStr(_Value) & e.KeyChar.ToString())
            If _Value > _Max Then _Value = _Max
            Invalidate()
        Catch : End Try
    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.KeyCode = Keys.Back Then
            Value = 0
        End If
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 30
    End Sub

#Region " Colors"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property ButtonColor As Color
        Get
            Return _ButtonColor
        End Get
        Set(value As Color)
            _ButtonColor = value
        End Set
    End Property

#End Region

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(60, 60, 60)
    Private _ButtonColor As Color = Color.FromArgb(21, 133, 181)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
        ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
        ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        Font = New Font("Segoe UI", 10)
        BackColor = Color.FromArgb(60, 70, 73)
        ForeColor = Color.White
        _Min = 0
        _Max = 9999999
    End Sub


    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width : H = Height

        Dim Base As New Rectangle(0, 0, W, H)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            '-- Base
            .FillRectangle(New SolidBrush(_BaseColor), Base)
            .FillRectangle(New SolidBrush(_ButtonColor), New Rectangle(Width - 24, 0, 24, H))

            '-- Add
            .DrawString("+", New Font("Segoe UI", 12), Brushes.White, New Point(Width - 12, 8), CenterSF)
            '-- Subtract
            .DrawString("-", New Font("Segoe UI", 10, FontStyle.Bold), Brushes.White, New Point(Width - 12, 22), CenterSF)

            '-- Text
            .DrawString(Value, Font, Brushes.White, New Rectangle(5, 1, W, H), New StringFormat() With {.LineAlignment = StringAlignment.Center})
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

End Class

Class FlatListBox : Inherits Control

#Region " Variables"

    Private WithEvents ListBx As New ListBox
    Private _items As String() = {""}

#End Region

#Region " Poperties"

    <Category("Options")> _
    Public Property items As String()
        Get
            Return _items
        End Get
        Set(value As String())
            _items = value
            ListBx.Items.Clear()
            ListBx.Items.AddRange(value)
            Invalidate()
        End Set
    End Property

    <Category("Colors")> _
    Public Property SelectedColor As Color
        Get
            Return _SelectedColor
        End Get
        Set(value As Color)
            _SelectedColor = value
        End Set
    End Property

    Public ReadOnly Property SelectedItem() As String
        Get
            Return ListBx.SelectedItem
        End Get
    End Property

    Public ReadOnly Property SelectedIndex() As Integer
        Get
            Return ListBx.SelectedIndex
            If ListBx.SelectedIndex < 0 Then Exit Property
        End Get
    End Property

    Sub Drawitem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles ListBx.DrawItem
        If e.Index < 0 Then Exit Sub
        e.DrawBackground()
        e.DrawFocusRectangle()

        e.Graphics.SmoothingMode = 2
        e.Graphics.PixelOffsetMode = 2
        e.Graphics.InterpolationMode = 7
        e.Graphics.TextRenderingHint = 3

        If InStr(e.State.ToString, "Selected,") > 0 Then '-- if selected
            '-- Base
            e.Graphics.FillRectangle(New SolidBrush(_SelectedColor), New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))

            '-- Text
            e.Graphics.DrawString(" " & ListBx.Items(e.Index).ToString(), New Font("Segoe UI", 8), Brushes.White, e.Bounds.X, e.Bounds.Y + 2)
        Else
            '-- Base
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(60, 60, 60)), New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height))

            '-- Text
            e.Graphics.DrawString(" " & ListBx.Items(e.Index).ToString(), New Font("Segoe UI", 8), Brushes.White, e.Bounds.X, e.Bounds.Y + 2)
        End If

        e.Graphics.Dispose()
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(ListBx) Then
            Controls.Add(ListBx)
        End If
    End Sub

    Sub AddRange(ByVal items As Object())
        ListBx.Items.Remove("")
        ListBx.Items.AddRange(items)
    End Sub

    Sub AddItem(ByVal item As Object)
        ListBx.Items.Remove("")
        ListBx.Items.Add(item)
    End Sub

#End Region

#Region " Colors"

    Private BaseColor As Color = Color.FromArgb(60, 60, 60)
    Private _SelectedColor As Color = Color.FromArgb(21, 133, 181)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
            ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True

        ListBx.DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        ListBx.ScrollAlwaysVisible = False
        ListBx.HorizontalScrollbar = False
        ListBx.BorderStyle = BorderStyle.None
        ListBx.BackColor = BaseColor
        ListBx.ForeColor = Color.White
        ListBx.Location = New Point(3, 3)
        ListBx.Font = New Font("Segoe UI", 8)
        ListBx.ItemHeight = 20
        ListBx.Items.Clear()
        ListBx.IntegralHeight = False

        Size = New Size(131, 101)
        BackColor = BaseColor
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)

        Dim Base As New Rectangle(0, 0, Width, Height)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            '-- Size
            ListBx.Size = New Size(Width - 6, Height - 2)

            '-- Base
            .FillRectangle(New SolidBrush(BaseColor), Base)
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

End Class

Class FlatContextMenuStrip : Inherits ContextMenuStrip

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e) : Invalidate()
    End Sub

    Sub New()
        MyBase.New()
        Renderer = New ToolStripProfessionalRenderer(New TColorTable())
        ShowImageMargin = False
        ForeColor = Color.White
        Font = New Font("Segoe UI", 8)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.TextRenderingHint = 3
    End Sub

    Class TColorTable : Inherits ProfessionalColorTable

#Region " Properties"

#Region " Colors"

        <Category("Colors")> _
        Public Property _BackColor As Color
            Get
                Return BackColor
            End Get
            Set(value As Color)
                BackColor = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property _CheckedColor As Color
            Get
                Return CheckedColor
            End Get
            Set(value As Color)
                CheckedColor = value
            End Set
        End Property

        <Category("Colors")> _
        Public Property _BorderColor As Color
            Get
                Return BorderColor
            End Get
            Set(value As Color)
                BorderColor = value
            End Set
        End Property

#End Region

#End Region

#Region " Colors"

        Private BackColor As Color = Color.FromArgb(60, 60, 60)
        Private CheckedColor As Color = Color.FromArgb(21, 133, 181)
        Private BorderColor As Color = Color.FromArgb(21, 133, 181)

#End Region

#Region " Overrides"

        Public Overrides ReadOnly Property ButtonSelectedBorder As Color
            Get
                Return BackColor
            End Get
        End Property
        Public Overrides ReadOnly Property CheckBackground() As Color
            Get
                Return CheckedColor
            End Get
        End Property
        Public Overrides ReadOnly Property CheckPressedBackground() As Color
            Get
                Return CheckedColor
            End Get
        End Property
        Public Overrides ReadOnly Property CheckSelectedBackground() As Color
            Get
                Return CheckedColor
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginGradientBegin() As Color
            Get
                Return CheckedColor
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginGradientEnd() As Color
            Get
                Return CheckedColor
            End Get
        End Property
        Public Overrides ReadOnly Property ImageMarginGradientMiddle() As Color
            Get
                Return CheckedColor
            End Get
        End Property
        Public Overrides ReadOnly Property MenuBorder() As Color
            Get
                Return BorderColor
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemBorder() As Color
            Get
                Return BorderColor
            End Get
        End Property
        Public Overrides ReadOnly Property MenuItemSelected() As Color
            Get
                Return CheckedColor
            End Get
        End Property
        Public Overrides ReadOnly Property SeparatorDark() As Color
            Get
                Return BorderColor
            End Get
        End Property
        Public Overrides ReadOnly Property ToolStripDropDownBackground() As Color
            Get
                Return BackColor
            End Get
        End Property

#End Region

    End Class

End Class

<DefaultEvent("Scroll")> Class FlatTrackBar : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private Val As Integer
    Private Bool As Boolean
    Private Track As Rectangle
    Private Knob As Rectangle
    Private Style_ As _Style

#End Region

#Region " Properties"

#Region " Mouse States"

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Val = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (Width - 11))
            Track = New Rectangle(Val, 0, 10, 20)

            Bool = Track.Contains(e.Location)
        End If
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If Bool AndAlso e.X > -1 AndAlso e.X < (Width + 1) Then
            Value = _Minimum + CInt((_Maximum - _Minimum) * (e.X / Width))
        End If
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        MyBase.OnMouseUp(e) : Bool = False
    End Sub

#End Region

#Region " Styles"

    <Flags> _
    Enum _Style
        Slider
        Knob
    End Enum

    Public Property Style As _Style
        Get
            Return Style_
        End Get
        Set(value As _Style)
            Style_ = value
        End Set
    End Property

#End Region

#Region " Colors"

    <Category("Colors")> _
    Public Property TrackColor As Color
        Get
            Return _TrackColor
        End Get
        Set(value As Color)
            _TrackColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property HatchColor As Color
        Get
            Return _HatchColor
        End Get
        Set(value As Color)
            _HatchColor = value
        End Set
    End Property

#End Region

    Event Scroll(ByVal sender As Object)
    Private _Minimum As Integer
    Public Property Minimum As Integer
        Get
            Return Minimum
        End Get
        Set(value As Integer)
            If value < 0 Then
            End If

            _Minimum = value

            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value
            Invalidate()
        End Set
    End Property
    Private _Maximum As Integer = 10
    Public Property Maximum As Integer
        Get
            Return _Maximum
        End Get
        Set(value As Integer)
            If value < 0 Then
            End If

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value
            Invalidate()
        End Set
    End Property
    Private _Value As Integer
    Public Property Value As Integer
        Get
            Return _Value
        End Get
        Set(value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
            End If

            _Value = value
            Invalidate()
            RaiseEvent Scroll(Me)
        End Set
    End Property
    Private _ShowValue As Boolean = False
    Public Property ShowValue As Boolean
        Get
            Return _ShowValue
        End Get
        Set(value As Boolean)
            _ShowValue = value
        End Set
    End Property

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        MyBase.OnKeyDown(e)
        If e.KeyCode = Keys.Subtract Then
            If Value = 0 Then Exit Sub
            Value -= 1
        ElseIf e.KeyCode = Keys.Add Then
            If Value = _Maximum Then Exit Sub
            Value += 1
        End If
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e) : Invalidate()
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Height = 23
    End Sub

#End Region

#Region " Colors"

    Private BaseColor As Color = Color.FromArgb(60, 60, 60)
    Private _TrackColor As Color = Color.FromArgb(21, 133, 181)
    Private SliderColor As Color = Color.FromArgb(75, 75, 75)
    Private _HatchColor As Color = Color.FromArgb(21, 133, 181)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Height = 18

        BackColor = Color.FromArgb(50, 50, 50)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width - 1 : H = Height - 1

        Dim Base As New Rectangle(1, 6, W - 2, 8)
        Dim GP, GP2 As New GraphicsPath

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BackColor)

            '-- Value
            Val = CInt((_Value - _Minimum) / (_Maximum - _Minimum) * (W - 10))
            Track = New Rectangle(Val, 0, 10, 20)
            Knob = New Rectangle(Val, 4, 11, 14)

            '-- Base
            GP.AddRectangle(Base)
            .SetClip(GP)
            .FillRectangle(New SolidBrush(BaseColor), New Rectangle(0, 7, W, 8))
            .FillRectangle(New SolidBrush(_TrackColor), New Rectangle(0, 7, Track.X + Track.Width, 8))
            .ResetClip()

            '-- Hatch Brush
            Dim HB As New HatchBrush(HatchStyle.Plaid, HatchColor, _TrackColor)
            .FillRectangle(HB, New Rectangle(-10, 7, Track.X + Track.Width, 8))

            '-- Slider/Knob
            Select Case Style
                Case _Style.Slider
                    GP2.AddRectangle(Track)
                    .FillPath(New SolidBrush(SliderColor), GP2)
                Case _Style.Knob
                    GP2.AddEllipse(Knob)
                    .FillPath(New SolidBrush(SliderColor), GP2)
            End Select

            '-- Show the value
            If ShowValue Then
                .DrawString(Value, New Font("Segoe UI", 8), Brushes.White, New Rectangle(1, 6, W, H), New StringFormat() _
                            With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Far})
            End If
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Class FlatStatusBar : Inherits Control

#Region " Variables"

    Private W, H As Integer
    Private _ShowTimeDate As Boolean = False

#End Region

#Region " Properties"

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Dock = DockStyle.Bottom
    End Sub

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e) : Invalidate()
    End Sub

#Region " Colors"

    <Category("Colors")> _
    Public Property BaseColor As Color
        Get
            Return _BaseColor
        End Get
        Set(value As Color)
            _BaseColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property TextColor As Color
        Get
            Return _TextColor
        End Get
        Set(value As Color)
            _TextColor = value
        End Set
    End Property

    <Category("Colors")> _
    Public Property RectColor As Color
        Get
            Return _RectColor
        End Get
        Set(value As Color)
            _RectColor = value
        End Set
    End Property

#End Region

    Public Property ShowTimeDate As Boolean
        Get
            Return _ShowTimeDate
        End Get
        Set(value As Boolean)
            _ShowTimeDate = value
        End Set
    End Property

    Function GetTimeDate() As String
        Return DateTime.Now.Date & " " & DateTime.Now.Hour & ":" & DateTime.Now.Minute
    End Function

#End Region

#Region " Colors"

    Private _BaseColor As Color = Color.FromArgb(50, 50, 50)
    Private _TextColor As Color = Color.White
    Private _RectColor As Color = Color.FromArgb(21, 133, 181)

#End Region

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
        Font = New Font("Segoe UI", 8)
        ForeColor = Color.White
        Size = New Size(Width, 20)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        B = New Bitmap(Width, Height) : G = Graphics.FromImage(B)
        W = Width : H = Height

        Dim Base As New Rectangle(0, 0, W, H)

        With G
            .SmoothingMode = 2
            .PixelOffsetMode = 2
            .TextRenderingHint = 3
            .Clear(BaseColor)

            '-- Base
            .FillRectangle(New SolidBrush(BaseColor), Base)

            '-- Text
            .DrawString(Text, Font, Brushes.White, New Rectangle(10, 4, W, H), NearSF)

            '-- Rectangle
            .FillRectangle(New SolidBrush(_RectColor), New Rectangle(4, 4, 4, 14))

            '-- TimeDate
            If ShowTimeDate Then
                .DrawString(GetTimeDate, Font, New SolidBrush(_TextColor), New Rectangle(-4, 2, W, H), New StringFormat() _
                            With {.Alignment = StringAlignment.Far, .LineAlignment = StringAlignment.Center})
            End If
        End With

        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub
End Class

Class FlatLabel : Inherits Label

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e) : Invalidate()
    End Sub

    Sub New()
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        Font = New Font("Segoe UI", 8)
        ForeColor = Color.White
        BackColor = Color.Transparent
        Text = Text
    End Sub

End Class

