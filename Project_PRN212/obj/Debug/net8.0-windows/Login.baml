   M S B A M L   `   `   `  ����  Project_PRN212    PRN212_Assignment.Login   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=5.1.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  Login��5   	   $	��555��5	   	   $	��400��5
   	    � WindowStartupLocation$ CenterScreen=�5   	   
������  J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5   
      Color$ Black��6      
BlurRadius$ 20Q�6)      ShadowDepth$ 0Q�69   .��5      � .+�5   
   ��    CustomBackgroundBrush#���   6    �� CornerRadius$ 10��5       �� Padding$ 10q�5      ._�5      �  � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $	��19* �6$   �� 5      $	��22* �6$   .+�5!      �� $��Welcome to bookshop��6   $��30(�5"      $
��Bold"�5#      $��Italic$�5$      $��Center=�5%      $��0,0,0,20q�5&      $��0��5'        PrimaryHueDarkBrush#���  5(      $��Segoe UI)�5)      �� 5+      $��
Username: ��6   #���  5,      $��0,16,0,8q�5-      $��1��5.      �� 5/      -   5        	 ��Name$	 UsernameTextBox��5/       ( $MaterialDesignFilledTextFieldTextBox#���  50      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Enter your username��51        CustomInputBrush#���  52      $��0,48,0,3q�53      $��1��54      $��25��55      $��2��6&   �� 57      $��
Password: ��6   #���  58      $��	0,48,0,88q�59      $��5��5:      G� 5;      -   5         G�Name$ PasswordBox��5;       ( $MaterialDesignFilledPasswordFieldBox#���  5<      $
 Password��5=      #���  5>      $��	0,76,0,51q�5?      $��5��5@      $��25��5A      �� 5C      -   5        $��Login��5C        MaterialDesignRaisedButton#��[ 5D      $��0,143,0,153q�5E      $	��204��5G      $��5��5H      $��Center=�5I      $��2��66   �� 5K      $��6��6   $��Center=�5L      $��	0,73,0,73q�69   �� 5M      $�Don't have an account? ��6    �� 5N      -   5        #���  5O       .�6S   .�5P      �� $�Register here.��6   5Q      5R      5S      5T      5U      5V      